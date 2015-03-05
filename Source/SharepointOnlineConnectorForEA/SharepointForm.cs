using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Xml.Linq;
using System.Threading;

/*  
 *  Copyright 2015 - Allard Brand
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *  
 */

namespace SharepointOnlineConnectorForEA
{
    public partial class SharepointForm : System.Windows.Forms.Form
    {
        private Dictionary<String, String> savedSearches = new Dictionary<string,string>();
        private SharePointOnlineCredentials sharepointCredentials;
        private EA.Repository EARepository;

        public SharepointForm() : this(null) { }
        public SharepointForm(EA.Repository Repository)
        {
            InitializeComponent();
            this.EARepository = Repository;

            // Get current package
            EA.Package CurrentPackage = Repository.GetTreeSelectedPackage();
            IEnumerable<XElement> searches = null;
            bool hasSavedSearches = false;

            // Read configuration file to retrieve saved searches
            var xml = XDocument.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "/Sparx Systems/EA/Search Data/EA_Search.xml");
            searches = from cli in xml.Element("RootSearch").Elements("Search")
                       select cli;

            // Check whether there are any saved searches
            hasSavedSearches = (searches.Count<XElement>() >= 1);

            // List all saved searches if found
            if (hasSavedSearches)
            {
                // Set-up combobox
                cbSavedSearches.Text = "Select query...";

                // List all searches
                foreach (var tmpSearch in searches)
                {
                    string tmpSearchName = ""; 
                    string tmpSearchQuery = ""; 

                    try
                    {
                        // Try to parse file
                        tmpSearchName = tmpSearch.Attribute("Name").Value;
                        tmpSearchQuery = tmpSearch.Element("SrchOn").Element("RootTable").Attribute("Filter").Value.
                            Replace("\n", System.Environment.NewLine);
                    } catch (Exception) {
                        // Do nothing
                    }

                    if (tmpSearchName.Length >= 1 && tmpSearchQuery.Length >= 1)
                    {
                        // Add to combobox and dictionary
                        cbSavedSearches.Items.Add(tmpSearchName);
                        savedSearches.Add(tmpSearchName, tmpSearchQuery);
                    }
                }
            }
            else
            {
                // Disable combobox
                cbSavedSearches.Text = "Not available";
                cbSavedSearches.Enabled = false;
            }          
        }

        // Connect to SharePoint Online in separate thread
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread connectionThread = new Thread(new ThreadStart(connectToSharepoint));
            connectionThread.SetApartmentState(ApartmentState.STA);
            connectionThread.Start();

            while (connectionThread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        // Publish results from selected query to SharePoint Online in separate thread
        private void btnPublish_Click(object sender, EventArgs e)
        {
            Thread publishThread = new Thread(new ThreadStart(publishToSharepoint));
            publishThread.SetApartmentState(ApartmentState.STA);
            publishThread.Start();

            while (publishThread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        // User selects one of the predefined queries ('Saved Searches' within EA Model Search)
        private void cbSavedSearches_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = (string)cbSavedSearches.Items[cbSavedSearches.SelectedIndex];
                tbQuery.Text = savedSearches[selectedItem];
                btnTestQuery.Enabled = true;
                btnPublish.Enabled = (!btnConnect.Enabled && cbLists.SelectedIndex >= 0);
            }
            catch
            {
                // Do nothing
            }
        }

        // Open query in EA search window
        private void btnTestQuery_Click(object sender, EventArgs e)
        {
            this.EARepository.RunModelSearch((string)cbSavedSearches.Items[cbSavedSearches.SelectedIndex], "", "", "");
        }

        // Enable publish button when user selects a SharePoint list  
        private void cbLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPublish.Enabled = btnTestQuery.Enabled;
        }

        // Connect to SharePoint Online
        private void connectToSharepoint()
        {
            // Update progress information
            statusStrip.Invoke((Action)delegate { lblStatus.Text = "Connecting"; });
            statusStrip.Invoke((Action)delegate { progressBar.Value = 20; });

            // Generate secure password
            var password = tbPassword.Text;
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            // Prepare credentials
            this.sharepointCredentials = new SharePointOnlineCredentials(tbUsername.Text, securePassword);

            // Connect to SharePoint Online
            using (ClientContext clientContext = new ClientContext(new Uri(tbSharepointSite.Text)))
            {
                try
                {
                    // Connect to SharePoint (Office365)
                    clientContext.Credentials = this.sharepointCredentials;
                    Web web = clientContext.Web;

                    // Retrieve all lists from the server
                    clientContext.Load(web.Lists,
                                 lists => lists.Include(list => list.Title, // For each list, retrieve Title and Id 
                                                        list => list.Id));

                    // Execute query 
                    clientContext.ExecuteQuery();

                    // Enumerate the web.Lists 
                    foreach (List list in web.Lists)
                    {
                        cbLists.Items.Add(list.Title);
                    }

                    // Update progress information
                    statusStrip.Invoke((Action)delegate { lblStatus.Text = "Lists retrieved succesfully"; });
                    statusStrip.Invoke((Action)delegate { progressBar.Value = 100; });
                    cbLists.Parent.Invoke((Action)delegate { cbLists.Text = "Select ..."; });
                    cbLists.Parent.Invoke((Action)delegate { cbLists.Enabled = true; });
                    btnConnect.Parent.Invoke((Action)delegate { btnConnect.Enabled = false; });
                }
                catch (Exception exception)
                {
                    MessageBox.Show("An error has occured: " +
                        System.Environment.NewLine + System.Environment.NewLine + exception.Message);
                }
            }
        }

        // Publish results from selected query to SharePoint Online
        private void publishToSharepoint()
        {
            // Perform search
            string XMLOutput = this.EARepository.SQLQuery(tbQuery.Text);
            XDocument XMLDoc = XDocument.Parse(XMLOutput);

            // Check whether the query returns any results
            if (XMLDoc.Root.Element("Dataset_0").Element("Data").HasElements)
            {
                // Update progress information
                statusStrip.Invoke((Action)delegate { lblStatus.Text = "Publishing ..."; });
                statusStrip.Invoke((Action)delegate { progressBar.Value = 10; });

                // Connect to SharePoint Online
                using (ClientContext clientContext = new ClientContext(new Uri(tbSharepointSite.Text)))
                {
                    try
                    {
                        // Connect to SharePoint (Office365)
                        clientContext.Credentials = this.sharepointCredentials;
                        Web web = clientContext.Web;

                        // Open list
                        string selectedList = (string)cbLists.Items[cbLists.SelectedIndex];
                        List list = web.Lists.GetByTitle(selectedList);
                        FieldCollection fieldCollection = list.Fields;
                        clientContext.Load(fieldCollection);
                        clientContext.ExecuteQuery();

                        // Retrieve and store list column information
                        Dictionary<string, string> Fields = new Dictionary<string, string>();
                        foreach (Field tmpField in fieldCollection)
                        {
                            if (!Fields.ContainsKey(tmpField.Title)) Fields[tmpField.Title] = tmpField.InternalName;
                        }

                        // Purge (empty) list if this option has been selected
                        if (cbPurgeList.Checked)
                        {
                            // Get all list items
                            ListItemCollection listItems = list.GetItems(CamlQuery.CreateAllItemsQuery());
                            clientContext.Load(listItems, eachItem => eachItem.Include(item => item, item => item["ID"]));
                            clientContext.ExecuteQuery();

                            // Delete all list items
                            var totalListItems = listItems.Count;
                            if (totalListItems > 0)
                            {
                                for (var counter = totalListItems - 1; counter > -1; counter--)
                                {
                                    listItems[counter].DeleteObject();
                                }

                                // Execute query
                                clientContext.ExecuteQuery();
                            }
                        }

                        // Loop through query results
                        foreach (XElement Node in XMLDoc.Root.Element("Dataset_0").Element("Data").Elements())
                        {
                            ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                            ListItem newItem = list.AddItem(itemCreateInfo);

                            foreach (XElement Field in Node.Elements())
                            {
                                if (Fields.ContainsKey(Field.Name.LocalName))
                                {
                                    string tmpInternalName = Fields[Field.Name.LocalName];
                                    newItem[tmpInternalName] = Field.Value;
                                }

                                // Save item
                                newItem.Update();

                                // Update progressbar
                                statusStrip.Invoke((Action)delegate { progressBar.Value += 1; });
                            }
                        }

                        // Execute query
                        clientContext.ExecuteQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("An error has occured: " +
                            System.Environment.NewLine + System.Environment.NewLine + exception.Message);
                    }
                }
            }

            // Update progress information
            statusStrip.Invoke((Action)delegate { lblStatus.Text = "Done"; });
            statusStrip.Invoke((Action)delegate { progressBar.Value = 100; });
        }
    }
}
