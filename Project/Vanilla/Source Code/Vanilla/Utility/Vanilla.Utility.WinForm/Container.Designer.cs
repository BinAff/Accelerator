namespace Vanilla.Utility.WinForm
{
    partial class Container
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSeperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsCreatedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblModifiedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsModifiedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblModifiedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsModifiedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuTools,
            this.mnuWindows,
            this.mnuHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MdiWindowListItem = this.mnuWindows;
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(792, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuLogout,
            this.mnuFileSeperator1,
            this.mnuNew,
            this.mnuOpen,
            this.mnuFileSeperator2,
            this.mnuRecentFiles,
            this.mnuFileSeperator3,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(132, 22);
            this.mnuLogin.Text = "Login";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(132, 22);
            this.mnuLogout.Text = "Logout";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // mnuFileSeperator1
            // 
            this.mnuFileSeperator1.Name = "mnuFileSeperator1";
            this.mnuFileSeperator1.Size = new System.Drawing.Size(129, 6);
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(132, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(132, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuFileSeperator2
            // 
            this.mnuFileSeperator2.Name = "mnuFileSeperator2";
            this.mnuFileSeperator2.Size = new System.Drawing.Size(129, 6);
            // 
            // mnuRecentFiles
            // 
            this.mnuRecentFiles.Name = "mnuRecentFiles";
            this.mnuRecentFiles.Size = new System.Drawing.Size(132, 22);
            this.mnuRecentFiles.Text = "Recent Files";
            // 
            // mnuFileSeperator3
            // 
            this.mnuFileSeperator3.Name = "mnuFileSeperator3";
            this.mnuFileSeperator3.Size = new System.Drawing.Size(129, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(132, 22);
            this.mnuExit.Text = "Exit";
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(37, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuView
            // 
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(41, 20);
            this.mnuView.Text = "View";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuOptions
            // 
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(111, 22);
            this.mnuOptions.Text = "Options";
            // 
            // mnuWindows
            // 
            this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArrangeIcons,
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.toolStripSeparator2,
            this.mnuCloseAll});
            this.mnuWindows.Name = "mnuWindows";
            this.mnuWindows.Size = new System.Drawing.Size(62, 20);
            this.mnuWindows.Text = "Windows";
            // 
            // mnuArrangeIcons
            // 
            this.mnuArrangeIcons.Name = "mnuArrangeIcons";
            this.mnuArrangeIcons.Size = new System.Drawing.Size(142, 22);
            this.mnuArrangeIcons.Text = "Arrange Icons";
            this.mnuArrangeIcons.Click += new System.EventHandler(this.mnuArrangeIcons_Click);
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(142, 22);
            this.mnuCascade.Text = "Cascade";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
            // 
            // mnuTileHorizontal
            // 
            this.mnuTileHorizontal.Name = "mnuTileHorizontal";
            this.mnuTileHorizontal.Size = new System.Drawing.Size(142, 22);
            this.mnuTileHorizontal.Text = "Tile Horizontal";
            this.mnuTileHorizontal.Click += new System.EventHandler(this.mnuTileHorizontal_Click);
            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(142, 22);
            this.mnuTileVertical.Text = "Tile Vertical";
            this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(142, 22);
            this.mnuCloseAll.Text = "Close All";
            this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAll_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.toolStripSeparator1,
            this.mnuViewHelp});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(139, 22);
            this.mnuAbout.Text = "About";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // mnuViewHelp
            // 
            this.mnuViewHelp.Name = "mnuViewHelp";
            this.mnuViewHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuViewHelp.Size = new System.Drawing.Size(139, 22);
            this.mnuViewHelp.Text = "View Help";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.lblVersion,
            this.tlsVersion,
            this.lblCreatedBy,
            this.tlsCreatedBy,
            this.lblCreatedAt,
            this.tlsCreatedAt,
            this.lblModifiedBy,
            this.tlsModifiedBy,
            this.lblModifiedAt,
            this.tlsModifiedAt,
            this.lblPath,
            this.tlsPath});
            this.statusStrip.Location = new System.Drawing.Point(0, 551);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(792, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(52, 17);
            this.lblVersion.Text = "Version:";
            // 
            // tlsVersion
            // 
            this.tlsVersion.AutoSize = false;
            this.tlsVersion.Name = "tlsVersion";
            this.tlsVersion.Size = new System.Drawing.Size(20, 17);
            this.tlsVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(72, 17);
            this.lblCreatedBy.Text = "Created By:";
            // 
            // tlsCreatedBy
            // 
            this.tlsCreatedBy.AutoSize = false;
            this.tlsCreatedBy.Name = "tlsCreatedBy";
            this.tlsCreatedBy.Size = new System.Drawing.Size(100, 17);
            this.tlsCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(71, 17);
            this.lblCreatedAt.Text = "Created At:";
            // 
            // tlsCreatedAt
            // 
            this.tlsCreatedAt.AutoSize = false;
            this.tlsCreatedAt.Name = "tlsCreatedAt";
            this.tlsCreatedAt.Size = new System.Drawing.Size(110, 17);
            this.tlsCreatedAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedBy
            // 
            this.lblModifiedBy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblModifiedBy.Name = "lblModifiedBy";
            this.lblModifiedBy.Size = new System.Drawing.Size(75, 17);
            this.lblModifiedBy.Text = "Modified By:";
            // 
            // tlsModifiedBy
            // 
            this.tlsModifiedBy.AutoSize = false;
            this.tlsModifiedBy.Name = "tlsModifiedBy";
            this.tlsModifiedBy.Size = new System.Drawing.Size(100, 17);
            this.tlsModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModifiedAt
            // 
            this.lblModifiedAt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblModifiedAt.Name = "lblModifiedAt";
            this.lblModifiedAt.Size = new System.Drawing.Size(74, 17);
            this.lblModifiedAt.Text = "Modified At:";
            // 
            // tlsModifiedAt
            // 
            this.tlsModifiedAt.AutoSize = false;
            this.tlsModifiedAt.Name = "tlsModifiedAt";
            this.tlsModifiedAt.Size = new System.Drawing.Size(110, 17);
            this.tlsModifiedAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPath
            // 
            this.lblPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(33, 13);
            this.lblPath.Text = "Path";
            this.lblPath.Visible = false;
            // 
            // tlsPath
            // 
            this.tlsPath.Name = "tlsPath";
            this.tlsPath.Size = new System.Drawing.Size(0, 0);
            this.tlsPath.Visible = false;
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.Name = "Container";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Container";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Container_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripSeparator mnuFileSeperator1;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripSeparator mnuFileSeperator2;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentFiles;
        private System.Windows.Forms.ToolStripSeparator mnuFileSeperator3;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuArrangeIcons;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuViewHelp;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedBy;
        private System.Windows.Forms.ToolStripStatusLabel tlsCreatedBy;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel tlsCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel lblModifiedBy;
        private System.Windows.Forms.ToolStripStatusLabel tlsModifiedBy;
        private System.Windows.Forms.ToolStripStatusLabel lblModifiedAt;
        private System.Windows.Forms.ToolStripStatusLabel tlsModifiedAt;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel tlsVersion;
        private System.Windows.Forms.ToolStripStatusLabel lblPath;
        private System.Windows.Forms.ToolStripStatusLabel tlsPath;
    }
}