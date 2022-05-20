namespace GMOD_Server_Tools
{
    partial class FrmGmodServerTools
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGmodServerTools));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAddons = new System.Windows.Forms.Label();
            this.lstAddons = new System.Windows.Forms.CheckedListBox();
            this.txtAddon = new System.Windows.Forms.TextBox();
            this.btnGetAddon = new System.Windows.Forms.Button();
            this.lstServers = new System.Windows.Forms.CheckedListBox();
            this.txtServerFolders = new System.Windows.Forms.TextBox();
            this.btnUpdateInstall = new System.Windows.Forms.Button();
            this.btnInverse = new System.Windows.Forms.Button();
            this.lblServerFolders = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnGetDirectory = new System.Windows.Forms.Button();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 572);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1176, 22);
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1176, 569);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblAddons);
            this.tabPage1.Controls.Add(this.lstAddons);
            this.tabPage1.Controls.Add(this.txtAddon);
            this.tabPage1.Controls.Add(this.btnGetAddon);
            this.tabPage1.Controls.Add(this.lstServers);
            this.tabPage1.Controls.Add(this.txtServerFolders);
            this.tabPage1.Controls.Add(this.btnUpdateInstall);
            this.tabPage1.Controls.Add(this.btnInverse);
            this.tabPage1.Controls.Add(this.lblServerFolders);
            this.tabPage1.Controls.Add(this.btnAll);
            this.tabPage1.Controls.Add(this.btnAddFolder);
            this.tabPage1.Controls.Add(this.btnGetDirectory);
            this.tabPage1.Controls.Add(this.btnRemoveFolder);
            this.tabPage1.Controls.Add(this.btnNone);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1168, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Servers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblAddons
            // 
            this.lblAddons.AutoSize = true;
            this.lblAddons.Location = new System.Drawing.Point(8, 281);
            this.lblAddons.Name = "lblAddons";
            this.lblAddons.Size = new System.Drawing.Size(43, 13);
            this.lblAddons.TabIndex = 44;
            this.lblAddons.Text = "Addons";
            // 
            // lstAddons
            // 
            this.lstAddons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAddons.FormattingEnabled = true;
            this.lstAddons.Location = new System.Drawing.Point(8, 302);
            this.lstAddons.Name = "lstAddons";
            this.lstAddons.Size = new System.Drawing.Size(1140, 229);
            this.lstAddons.Sorted = true;
            this.lstAddons.TabIndex = 43;
            this.lstAddons.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.AddonStateChanged);
            // 
            // txtAddon
            // 
            this.txtAddon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddon.Location = new System.Drawing.Point(57, 275);
            this.txtAddon.Name = "txtAddon";
            this.txtAddon.Size = new System.Drawing.Size(1008, 20);
            this.txtAddon.TabIndex = 42;
            // 
            // btnGetAddon
            // 
            this.btnGetAddon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetAddon.Location = new System.Drawing.Point(1063, 274);
            this.btnGetAddon.Name = "btnGetAddon";
            this.btnGetAddon.Size = new System.Drawing.Size(97, 22);
            this.btnGetAddon.TabIndex = 41;
            this.btnGetAddon.Text = "Get Addon";
            this.btnGetAddon.UseVisualStyleBackColor = true;
            this.btnGetAddon.Click += new System.EventHandler(this.btnGetAddon_Click);
            // 
            // lstServers
            // 
            this.lstServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServers.ColumnWidth = 500;
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(8, 72);
            this.lstServers.MultiColumn = true;
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(1089, 139);
            this.lstServers.TabIndex = 30;
            this.lstServers.ThreeDCheckBoxes = true;
            // 
            // txtServerFolders
            // 
            this.txtServerFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerFolders.Location = new System.Drawing.Point(8, 20);
            this.txtServerFolders.Name = "txtServerFolders";
            this.txtServerFolders.Size = new System.Drawing.Size(1113, 20);
            this.txtServerFolders.TabIndex = 32;
            // 
            // btnUpdateInstall
            // 
            this.btnUpdateInstall.Location = new System.Drawing.Point(8, 217);
            this.btnUpdateInstall.Name = "btnUpdateInstall";
            this.btnUpdateInstall.Size = new System.Drawing.Size(97, 23);
            this.btnUpdateInstall.TabIndex = 36;
            this.btnUpdateInstall.Text = "Update/Install";
            this.btnUpdateInstall.UseVisualStyleBackColor = true;
            this.btnUpdateInstall.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInverse
            // 
            this.btnInverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInverse.Location = new System.Drawing.Point(1103, 101);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(57, 23);
            this.btnInverse.TabIndex = 39;
            this.btnInverse.Text = "Inverse";
            this.btnInverse.UseVisualStyleBackColor = true;
            this.btnInverse.Click += new System.EventHandler(this.btnInverse_Click);
            // 
            // lblServerFolders
            // 
            this.lblServerFolders.AutoSize = true;
            this.lblServerFolders.Location = new System.Drawing.Point(8, 4);
            this.lblServerFolders.Name = "lblServerFolders";
            this.lblServerFolders.Size = new System.Drawing.Size(97, 13);
            this.lblServerFolders.TabIndex = 34;
            this.lblServerFolders.Text = "Add Server Folders";
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.Location = new System.Drawing.Point(1103, 72);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(57, 23);
            this.btnAll.TabIndex = 31;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(8, 43);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(54, 20);
            this.btnAddFolder.TabIndex = 38;
            this.btnAddFolder.Text = "Add";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnGetDirectory
            // 
            this.btnGetDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDirectory.Location = new System.Drawing.Point(1118, 19);
            this.btnGetDirectory.Name = "btnGetDirectory";
            this.btnGetDirectory.Size = new System.Drawing.Size(42, 22);
            this.btnGetDirectory.TabIndex = 37;
            this.btnGetDirectory.Text = "...";
            this.btnGetDirectory.UseVisualStyleBackColor = true;
            this.btnGetDirectory.Click += new System.EventHandler(this.btnGetDirectory_Click);
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFolder.Location = new System.Drawing.Point(1103, 188);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(57, 23);
            this.btnRemoveFolder.TabIndex = 35;
            this.btnRemoveFolder.Text = "Remove";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnNone
            // 
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNone.Location = new System.Drawing.Point(1103, 130);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(57, 23);
            this.btnNone.TabIndex = 33;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1168, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmGMODServerTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 594);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGmodServerTools";
            this.Text = "Landon\'s GMOD Server Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox lstServers;
        private System.Windows.Forms.TextBox txtServerFolders;
        private System.Windows.Forms.Button btnUpdateInstall;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.Label lblServerFolders;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnGetDirectory;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnGetAddon;
        private System.Windows.Forms.TextBox txtAddon;
        private System.Windows.Forms.CheckedListBox lstAddons;
        private System.Windows.Forms.Label lblAddons;
    }
}

