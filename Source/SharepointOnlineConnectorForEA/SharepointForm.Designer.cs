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
    partial class SharepointForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharepointForm));
            this.logoSharepoint = new System.Windows.Forms.PictureBox();
            this.tbSharepointSite = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblSharepointURL = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbLists = new System.Windows.Forms.ComboBox();
            this.lblSelectList = new System.Windows.Forms.Label();
            this.gbTarget = new System.Windows.Forms.GroupBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.btnTestQuery = new System.Windows.Forms.Button();
            this.cbSavedSearches = new System.Windows.Forms.ComboBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.lblSelectQuery = new System.Windows.Forms.Label();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.lblOptions = new System.Windows.Forms.Label();
            this.cbPurgeList = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoSharepoint)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.gbTarget.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoSharepoint
            // 
            this.logoSharepoint.Image = ((System.Drawing.Image)(resources.GetObject("logoSharepoint.Image")));
            this.logoSharepoint.Location = new System.Drawing.Point(790, 21);
            this.logoSharepoint.Name = "logoSharepoint";
            this.logoSharepoint.Size = new System.Drawing.Size(234, 79);
            this.logoSharepoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoSharepoint.TabIndex = 0;
            this.logoSharepoint.TabStop = false;
            // 
            // tbSharepointSite
            // 
            this.tbSharepointSite.Location = new System.Drawing.Point(149, 30);
            this.tbSharepointSite.Name = "tbSharepointSite";
            this.tbSharepointSite.Size = new System.Drawing.Size(590, 22);
            this.tbSharepointSite.TabIndex = 1;
            this.tbSharepointSite.Text = "https://example.sharepoint.com/";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(149, 59);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(253, 22);
            this.tbUsername.TabIndex = 2;
            this.tbUsername.Text = "username@domain.com";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(550, 61);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(189, 22);
            this.tbPassword.TabIndex = 3;
            // 
            // lblSharepointURL
            // 
            this.lblSharepointURL.AutoSize = true;
            this.lblSharepointURL.Location = new System.Drawing.Point(16, 33);
            this.lblSharepointURL.Name = "lblSharepointURL";
            this.lblSharepointURL.Size = new System.Drawing.Size(114, 17);
            this.lblSharepointURL.TabIndex = 4;
            this.lblSharepointURL.Text = "SharePoint URL:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 61);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 17);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(426, 61);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(790, 106);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(234, 27);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 548);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1067, 25);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 19);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 20);
            this.lblStatus.Text = "Ready";
            // 
            // cbLists
            // 
            this.cbLists.Enabled = false;
            this.cbLists.FormattingEnabled = true;
            this.cbLists.Location = new System.Drawing.Point(149, 109);
            this.cbLists.Name = "cbLists";
            this.cbLists.Size = new System.Drawing.Size(590, 24);
            this.cbLists.TabIndex = 10;
            this.cbLists.Text = "Not available (not connected to SharePoint; please connect first)";
            this.cbLists.SelectedIndexChanged += new System.EventHandler(this.cbLists_SelectedIndexChanged);
            // 
            // lblSelectList
            // 
            this.lblSelectList.AutoSize = true;
            this.lblSelectList.Location = new System.Drawing.Point(16, 110);
            this.lblSelectList.Name = "lblSelectList";
            this.lblSelectList.Size = new System.Drawing.Size(72, 17);
            this.lblSelectList.TabIndex = 11;
            this.lblSelectList.Text = "Select list:";
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.cbPurgeList);
            this.gbTarget.Controls.Add(this.lblOptions);
            this.gbTarget.Controls.Add(this.logoSharepoint);
            this.gbTarget.Controls.Add(this.btnPublish);
            this.gbTarget.Controls.Add(this.cbLists);
            this.gbTarget.Controls.Add(this.lblSharepointURL);
            this.gbTarget.Controls.Add(this.tbSharepointSite);
            this.gbTarget.Controls.Add(this.lblSelectList);
            this.gbTarget.Controls.Add(this.tbUsername);
            this.gbTarget.Controls.Add(this.btnConnect);
            this.gbTarget.Controls.Add(this.tbPassword);
            this.gbTarget.Controls.Add(this.lblPassword);
            this.gbTarget.Controls.Add(this.lblUsername);
            this.gbTarget.Location = new System.Drawing.Point(12, 351);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Size = new System.Drawing.Size(1043, 183);
            this.gbTarget.TabIndex = 12;
            this.gbTarget.TabStop = false;
            this.gbTarget.Text = "Target";
            // 
            // btnPublish
            // 
            this.btnPublish.Enabled = false;
            this.btnPublish.Location = new System.Drawing.Point(790, 139);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(234, 27);
            this.btnPublish.TabIndex = 14;
            this.btnPublish.Text = "Publish to SharePoint Online";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.btnTestQuery);
            this.gbSource.Controls.Add(this.cbSavedSearches);
            this.gbSource.Controls.Add(this.lblQuery);
            this.gbSource.Controls.Add(this.lblSelectQuery);
            this.gbSource.Controls.Add(this.tbQuery);
            this.gbSource.Location = new System.Drawing.Point(12, 12);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(1043, 333);
            this.gbSource.TabIndex = 15;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source";
            // 
            // btnTestQuery
            // 
            this.btnTestQuery.Enabled = false;
            this.btnTestQuery.Location = new System.Drawing.Point(790, 24);
            this.btnTestQuery.Name = "btnTestQuery";
            this.btnTestQuery.Size = new System.Drawing.Size(234, 27);
            this.btnTestQuery.TabIndex = 15;
            this.btnTestQuery.Text = "Preview in Query Browser";
            this.btnTestQuery.UseVisualStyleBackColor = true;
            this.btnTestQuery.Click += new System.EventHandler(this.btnTestQuery_Click);
            // 
            // cbSavedSearches
            // 
            this.cbSavedSearches.FormattingEnabled = true;
            this.cbSavedSearches.Location = new System.Drawing.Point(149, 26);
            this.cbSavedSearches.Name = "cbSavedSearches";
            this.cbSavedSearches.Size = new System.Drawing.Size(635, 24);
            this.cbSavedSearches.TabIndex = 14;
            this.cbSavedSearches.SelectedIndexChanged += new System.EventHandler(this.cbSavedSearches_SelectedIndexChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(7, 59);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(51, 17);
            this.lblQuery.TabIndex = 13;
            this.lblQuery.Text = "Query:";
            // 
            // lblSelectQuery
            // 
            this.lblSelectQuery.AutoSize = true;
            this.lblSelectQuery.Location = new System.Drawing.Point(7, 29);
            this.lblSelectQuery.Name = "lblSelectQuery";
            this.lblSelectQuery.Size = new System.Drawing.Size(91, 17);
            this.lblSelectQuery.TabIndex = 4;
            this.lblSelectQuery.Text = "Select query:";
            // 
            // tbQuery
            // 
            this.tbQuery.AcceptsReturn = true;
            this.tbQuery.BackColor = System.Drawing.SystemColors.Window;
            this.tbQuery.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbQuery.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbQuery.Location = new System.Drawing.Point(149, 56);
            this.tbQuery.Multiline = true;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(875, 258);
            this.tbQuery.TabIndex = 3;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(16, 142);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(61, 17);
            this.lblOptions.TabIndex = 15;
            this.lblOptions.Text = "Options:";
            // 
            // cbPurgeList
            // 
            this.cbPurgeList.AutoSize = true;
            this.cbPurgeList.Location = new System.Drawing.Point(149, 141);
            this.cbPurgeList.Name = "cbPurgeList";
            this.cbPurgeList.Size = new System.Drawing.Size(203, 21);
            this.cbPurgeList.TabIndex = 16;
            this.cbPurgeList.Text = "Empty list before publishing";
            this.cbPurgeList.UseVisualStyleBackColor = true;
            // 
            // SharepointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 573);
            this.Controls.Add(this.gbSource);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbTarget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SharepointForm";
            this.ShowIcon = false;
            this.Text = "Publish to SharePoint Online";
            ((System.ComponentModel.ISupportInitialize)(this.logoSharepoint)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbTarget.ResumeLayout(false);
            this.gbTarget.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoSharepoint;
        private System.Windows.Forms.TextBox tbSharepointSite;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblSharepointURL;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ComboBox cbLists;
        private System.Windows.Forms.Label lblSelectList;
        private System.Windows.Forms.GroupBox gbTarget;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.Label lblSelectQuery;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.ComboBox cbSavedSearches;
        private System.Windows.Forms.Button btnTestQuery;
        private System.Windows.Forms.CheckBox cbPurgeList;
        private System.Windows.Forms.Label lblOptions;
    }
}