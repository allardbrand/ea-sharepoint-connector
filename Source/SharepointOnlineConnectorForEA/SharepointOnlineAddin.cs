using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharepointOnlineConnectorForEA
{
    public class SharepointOnlineAddin
    {
        // Menu settings
        const string menuHeader = "-&SharePoint Online";
        const string menuPublishToSharepoint = "&Publish to SharePoint Online";
        const string menuInformation = "&About";

        // EA calls this operation to validate Add-in correctness
        public String EA_Connect(EA.Repository Repository)
        {
            return "Connection OK";
        }

        // EA calls this operation to determine the menu configuration (for the current add-in)
        public object EA_GetMenuItems(EA.Repository Repository, string Location, string MenuName)
        {
            // Array to configure submenu
            string[] subMenus = { menuPublishToSharepoint, menuInformation };

            // Return menu configuration
            if (MenuName.Length == 0) return menuHeader;
            if (MenuName == menuHeader) return subMenus;

            return "";
        }

        // EA calls this operation to determine each of the menu states
        public void EA_GetMenuState(EA.Repository Repository, string Location, string MenuName, 
                                    string ItemName, ref bool IsEnabled, ref bool IsChecked)
        {
            // If no open project, disable all menu options
            IsEnabled = IsProjectOpen(Repository);
        }

        // Called when user clicks on a menu-item in EA
        public void EA_MenuClick(EA.Repository Repository, string Location, string MenuName, string ItemName)
        {
            switch (ItemName)
            {
                case menuPublishToSharepoint:
                    // Open 'Publish to Sharepoint Online' form
                    SharepointForm SharePointOnlineForm = new SharepointForm(Repository);
                    SharePointOnlineForm.Show();
                break;

                case menuInformation:
                    // Open form with 'About' information
                    AboutBox InformationWindow = new AboutBox();
                    InformationWindow.Show();
                break;
            }
        }

        // Determine whether EA has an active project
        bool IsProjectOpen(EA.Repository Repository)
        {
            try
            {
                // Determine whether the repository has any models
                EA.Collection c = Repository.Models;
                return true;
            }
            catch
            {
                return false;
            }
        }

        // EA calls this operation when closing; can be used to do some cleanup work
        public void EA_Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
