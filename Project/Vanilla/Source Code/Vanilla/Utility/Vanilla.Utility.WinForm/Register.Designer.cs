namespace Vanilla.Utility.WinForm
{
    partial class Register
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.pnlArtifact = new System.Windows.Forms.SplitContainer();
            this.tbcCategory = new System.Windows.Forms.TabControl();
            this.tbpForm = new System.Windows.Forms.TabPage();
            this.trvForm = new System.Windows.Forms.TreeView();
            this.imgMediumIcons = new System.Windows.Forms.ImageList(this.components);
            this.tbpCatalogue = new System.Windows.Forms.TabPage();
            this.trvCatalogue = new System.Windows.Forms.TreeView();
            this.tbpReport = new System.Windows.Forms.TabPage();
            this.trvReport = new System.Windows.Forms.TreeView();
            this.ucSearchResult = new Vanilla.Utility.WinForm.SearchResult();
            this.lsvContainer = new System.Windows.Forms.ListView();
            this.imgLargeIcon = new System.Windows.Forms.ImageList(this.components);
            this.imgSmallIcon = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmsExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuList = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSort = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCreatedAt = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCreatedBy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuModifiedAt = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuModifiedBy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuName = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuType = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSortSepaerator = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDailyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuWeeklyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuMonthlyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuQuarterlyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuYearlyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.imgMisc = new System.Windows.Forms.ImageList(this.components);
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlArtifact)).BeginInit();
            this.pnlArtifact.Panel1.SuspendLayout();
            this.pnlArtifact.Panel2.SuspendLayout();
            this.pnlArtifact.SuspendLayout();
            this.tbcCategory.SuspendLayout();
            this.tbpForm.SuspendLayout();
            this.tbpCatalogue.SuspendLayout();
            this.tbpReport.SuspendLayout();
            this.cmsExplorer.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlArtifact
            // 
            this.pnlArtifact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArtifact.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlArtifact.Location = new System.Drawing.Point(0, 20);
            this.pnlArtifact.Name = "pnlArtifact";
            // 
            // pnlArtifact.Panel1
            // 
            this.pnlArtifact.Panel1.Controls.Add(this.tbcCategory);
            // 
            // pnlArtifact.Panel2
            // 
            this.pnlArtifact.Panel2.Controls.Add(this.ucSearchResult);
            this.pnlArtifact.Panel2.Controls.Add(this.lsvContainer);
            this.pnlArtifact.Size = new System.Drawing.Size(698, 410);
            this.pnlArtifact.SplitterDistance = 217;
            this.pnlArtifact.TabIndex = 0;
            // 
            // tbcCategory
            // 
            this.tbcCategory.Controls.Add(this.tbpForm);
            this.tbcCategory.Controls.Add(this.tbpCatalogue);
            this.tbcCategory.Controls.Add(this.tbpReport);
            this.tbcCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcCategory.Location = new System.Drawing.Point(0, 0);
            this.tbcCategory.Name = "tbcCategory";
            this.tbcCategory.SelectedIndex = 0;
            this.tbcCategory.Size = new System.Drawing.Size(217, 410);
            this.tbcCategory.TabIndex = 3;
            this.tbcCategory.SelectedIndexChanged += new System.EventHandler(this.tbcCategory_SelectedIndexChanged);
            // 
            // tbpForm
            // 
            this.tbpForm.Controls.Add(this.trvForm);
            this.tbpForm.Location = new System.Drawing.Point(4, 22);
            this.tbpForm.Name = "tbpForm";
            this.tbpForm.Padding = new System.Windows.Forms.Padding(3);
            this.tbpForm.Size = new System.Drawing.Size(209, 384);
            this.tbpForm.TabIndex = 0;
            this.tbpForm.Text = "Form";
            this.tbpForm.UseVisualStyleBackColor = true;
            this.tbpForm.Click += new System.EventHandler(this.tbpForm_Click);
            // 
            // trvForm
            // 
            this.trvForm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvForm.ImageKey = "Folder";
            this.trvForm.ImageList = this.imgMediumIcons;
            this.trvForm.Location = new System.Drawing.Point(3, 3);
            this.trvForm.Name = "trvForm";
            this.trvForm.SelectedImageKey = "Open Folder";
            this.trvForm.ShowRootLines = false;
            this.trvForm.Size = new System.Drawing.Size(203, 378);
            this.trvForm.StateImageList = this.imgMediumIcons;
            this.trvForm.TabIndex = 6;
            this.trvForm.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.trvArtifact_AfterLabelEdit);
            this.trvForm.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvArtifact_AfterSelect);
            this.trvForm.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvArtifact_NodeMouseClick);
            this.trvForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trvArtifact_KeyUp);
            this.trvForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvArtifact_MouseDown);
            // 
            // imgMediumIcons
            // 
            this.imgMediumIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMediumIcons.ImageStream")));
            this.imgMediumIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMediumIcons.Images.SetKeyName(0, "Folder");
            this.imgMediumIcons.Images.SetKeyName(1, "Open Folder");
            this.imgMediumIcons.Images.SetKeyName(2, "Document");
            this.imgMediumIcons.Images.SetKeyName(3, "Down");
            this.imgMediumIcons.Images.SetKeyName(4, "Up");
            // 
            // tbpCatalogue
            // 
            this.tbpCatalogue.Controls.Add(this.trvCatalogue);
            this.tbpCatalogue.Location = new System.Drawing.Point(4, 22);
            this.tbpCatalogue.Name = "tbpCatalogue";
            this.tbpCatalogue.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCatalogue.Size = new System.Drawing.Size(209, 384);
            this.tbpCatalogue.TabIndex = 1;
            this.tbpCatalogue.Text = "Catalogue";
            this.tbpCatalogue.UseVisualStyleBackColor = true;
            this.tbpCatalogue.Click += new System.EventHandler(this.tbpCatalogue_Click);
            // 
            // trvCatalogue
            // 
            this.trvCatalogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvCatalogue.Location = new System.Drawing.Point(3, 3);
            this.trvCatalogue.Name = "trvCatalogue";
            this.trvCatalogue.ShowRootLines = false;
            this.trvCatalogue.Size = new System.Drawing.Size(203, 378);
            this.trvCatalogue.TabIndex = 0;
            this.trvCatalogue.Visible = false;
            this.trvCatalogue.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCatalogue_AfterSelect);
            // 
            // tbpReport
            // 
            this.tbpReport.Controls.Add(this.trvReport);
            this.tbpReport.Location = new System.Drawing.Point(4, 22);
            this.tbpReport.Name = "tbpReport";
            this.tbpReport.Padding = new System.Windows.Forms.Padding(3);
            this.tbpReport.Size = new System.Drawing.Size(209, 384);
            this.tbpReport.TabIndex = 2;
            this.tbpReport.Text = "Report";
            this.tbpReport.UseVisualStyleBackColor = true;
            this.tbpReport.Click += new System.EventHandler(this.tbpReport_Click);
            // 
            // trvReport
            // 
            this.trvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvReport.ImageIndex = 0;
            this.trvReport.ImageList = this.imgMediumIcons;
            this.trvReport.Location = new System.Drawing.Point(3, 3);
            this.trvReport.Name = "trvReport";
            this.trvReport.SelectedImageIndex = 1;
            this.trvReport.ShowRootLines = false;
            this.trvReport.Size = new System.Drawing.Size(203, 378);
            this.trvReport.TabIndex = 0;
            this.trvReport.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvReport_AfterSelect);
            this.trvReport.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvReport_NodeMouseClick);
            this.trvReport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvReport_MouseDown);
            // 
            // ucSearchResult
            // 
            this.ucSearchResult.Location = new System.Drawing.Point(67, 25);
            this.ucSearchResult.Name = "ucSearchResult";
            this.ucSearchResult.Size = new System.Drawing.Size(152, 103);
            this.ucSearchResult.TabIndex = 16;
            this.ucSearchResult.Visible = false;
            this.ucSearchResult.DoubleClick += new System.EventHandler(this.ucSearchResult_DoubleClick);
            // 
            // lsvContainer
            // 
            this.lsvContainer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvContainer.FullRowSelect = true;
            this.lsvContainer.LargeImageList = this.imgLargeIcon;
            this.lsvContainer.Location = new System.Drawing.Point(111, 165);
            this.lsvContainer.Name = "lsvContainer";
            this.lsvContainer.Size = new System.Drawing.Size(176, 101);
            this.lsvContainer.SmallImageList = this.imgMediumIcons;
            this.lsvContainer.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvContainer.TabIndex = 2;
            this.lsvContainer.UseCompatibleStateImageBehavior = false;
            this.lsvContainer.View = System.Windows.Forms.View.Details;
            this.lsvContainer.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lsvContainer_AfterLabelEdit);
            this.lsvContainer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvContainer_ColumnClick);
            this.lsvContainer.SelectedIndexChanged += new System.EventHandler(this.lsvContainer_SelectedIndexChanged);
            this.lsvContainer.DoubleClick += new System.EventHandler(this.lsvContainer_DoubleClick);
            this.lsvContainer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lsvContainer_KeyUp);
            this.lsvContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsvContainer_MouseDown);
            // 
            // imgLargeIcon
            // 
            this.imgLargeIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLargeIcon.ImageStream")));
            this.imgLargeIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLargeIcon.Images.SetKeyName(0, "Folder");
            this.imgLargeIcon.Images.SetKeyName(1, "Open Folder");
            this.imgLargeIcon.Images.SetKeyName(2, "Document");
            this.imgLargeIcon.Images.SetKeyName(3, "Down");
            this.imgLargeIcon.Images.SetKeyName(4, "Up");
            // 
            // imgSmallIcon
            // 
            this.imgSmallIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmallIcon.ImageStream")));
            this.imgSmallIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSmallIcon.Images.SetKeyName(0, "Folder");
            this.imgSmallIcon.Images.SetKeyName(1, "Open Folder");
            this.imgSmallIcon.Images.SetKeyName(2, "Document");
            this.imgSmallIcon.Images.SetKeyName(3, "Down");
            this.imgSmallIcon.Images.SetKeyName(4, "Up");
            // 
            // cmsExplorer
            // 
            this.cmsExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOpen,
            this.cmnuView,
            this.cmnuSort,
            this.cmnuRefresh,
            this.mnuNewWindow,
            this.cmnuSeparator1,
            this.cmnuCut,
            this.cmnuCopy,
            this.cmnuPaste,
            this.cmnuSeparator2,
            this.cmnuDelete,
            this.cmnuRename,
            this.cmnuSeparator3,
            this.newToolStripMenuItem});
            this.cmsExplorer.Name = "cmsExplorer";
            this.cmsExplorer.Size = new System.Drawing.Size(186, 264);
            // 
            // cmnuOpen
            // 
            this.cmnuOpen.Name = "cmnuOpen";
            this.cmnuOpen.Size = new System.Drawing.Size(185, 22);
            this.cmnuOpen.Text = "Open";
            this.cmnuOpen.Click += new System.EventHandler(this.cmnuOpen_Click);
            // 
            // cmnuView
            // 
            this.cmnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuLargeIcon,
            this.cmnuSmallIcon,
            this.cmnuList,
            this.cmnuDetail,
            this.cmnuTile});
            this.cmnuView.Name = "cmnuView";
            this.cmnuView.Size = new System.Drawing.Size(185, 22);
            this.cmnuView.Text = "View";
            // 
            // cmnuLargeIcon
            // 
            this.cmnuLargeIcon.Name = "cmnuLargeIcon";
            this.cmnuLargeIcon.Size = new System.Drawing.Size(125, 22);
            this.cmnuLargeIcon.Text = "Large Icon";
            this.cmnuLargeIcon.Click += new System.EventHandler(this.cmnuLargeIcon_Click);
            // 
            // cmnuSmallIcon
            // 
            this.cmnuSmallIcon.Name = "cmnuSmallIcon";
            this.cmnuSmallIcon.Size = new System.Drawing.Size(125, 22);
            this.cmnuSmallIcon.Text = "Small Icon";
            this.cmnuSmallIcon.Click += new System.EventHandler(this.cmnuSmallIcon_Click);
            // 
            // cmnuList
            // 
            this.cmnuList.Name = "cmnuList";
            this.cmnuList.Size = new System.Drawing.Size(125, 22);
            this.cmnuList.Text = "List";
            this.cmnuList.Click += new System.EventHandler(this.cmnuList_Click);
            // 
            // cmnuDetail
            // 
            this.cmnuDetail.Name = "cmnuDetail";
            this.cmnuDetail.Size = new System.Drawing.Size(125, 22);
            this.cmnuDetail.Text = "Details";
            this.cmnuDetail.Click += new System.EventHandler(this.cmnuDetail_Click);
            // 
            // cmnuTile
            // 
            this.cmnuTile.Name = "cmnuTile";
            this.cmnuTile.Size = new System.Drawing.Size(125, 22);
            this.cmnuTile.Text = "Tile";
            this.cmnuTile.Click += new System.EventHandler(this.cmnuTile_Click);
            // 
            // cmnuSort
            // 
            this.cmnuSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuCreatedAt,
            this.cmnuCreatedBy,
            this.cmnuModifiedAt,
            this.cmnuModifiedBy,
            this.cmnuName,
            this.cmnuType,
            this.cmnuVersion,
            this.cmnuSortSepaerator,
            this.cmnuAscending,
            this.cmnuDescending});
            this.cmnuSort.Name = "cmnuSort";
            this.cmnuSort.Size = new System.Drawing.Size(185, 22);
            this.cmnuSort.Text = "Sort By";
            // 
            // cmnuCreatedAt
            // 
            this.cmnuCreatedAt.Name = "cmnuCreatedAt";
            this.cmnuCreatedAt.Size = new System.Drawing.Size(129, 22);
            this.cmnuCreatedAt.Text = "Created At";
            this.cmnuCreatedAt.Click += new System.EventHandler(this.cmnuCreatedAt_Click);
            // 
            // cmnuCreatedBy
            // 
            this.cmnuCreatedBy.Name = "cmnuCreatedBy";
            this.cmnuCreatedBy.Size = new System.Drawing.Size(129, 22);
            this.cmnuCreatedBy.Text = "Created By";
            this.cmnuCreatedBy.Click += new System.EventHandler(this.cmnuCreatedBy_Click);
            // 
            // cmnuModifiedAt
            // 
            this.cmnuModifiedAt.Name = "cmnuModifiedAt";
            this.cmnuModifiedAt.Size = new System.Drawing.Size(129, 22);
            this.cmnuModifiedAt.Text = "Modified At";
            this.cmnuModifiedAt.Click += new System.EventHandler(this.cmnuModifiedAt_Click);
            // 
            // cmnuModifiedBy
            // 
            this.cmnuModifiedBy.Name = "cmnuModifiedBy";
            this.cmnuModifiedBy.Size = new System.Drawing.Size(129, 22);
            this.cmnuModifiedBy.Text = "Modified By";
            this.cmnuModifiedBy.Click += new System.EventHandler(this.cmnuModifiedBy_Click);
            // 
            // cmnuName
            // 
            this.cmnuName.Name = "cmnuName";
            this.cmnuName.Size = new System.Drawing.Size(129, 22);
            this.cmnuName.Text = "Name";
            this.cmnuName.Click += new System.EventHandler(this.cmnuName_Click);
            // 
            // cmnuType
            // 
            this.cmnuType.Name = "cmnuType";
            this.cmnuType.Size = new System.Drawing.Size(129, 22);
            this.cmnuType.Text = "Type";
            this.cmnuType.Click += new System.EventHandler(this.cmnuType_Click);
            // 
            // cmnuVersion
            // 
            this.cmnuVersion.Name = "cmnuVersion";
            this.cmnuVersion.Size = new System.Drawing.Size(129, 22);
            this.cmnuVersion.Text = "Version";
            this.cmnuVersion.Click += new System.EventHandler(this.cmnuVersion_Click);
            // 
            // cmnuSortSepaerator
            // 
            this.cmnuSortSepaerator.Name = "cmnuSortSepaerator";
            this.cmnuSortSepaerator.Size = new System.Drawing.Size(126, 6);
            // 
            // cmnuAscending
            // 
            this.cmnuAscending.Name = "cmnuAscending";
            this.cmnuAscending.Size = new System.Drawing.Size(129, 22);
            this.cmnuAscending.Text = "Ascending";
            this.cmnuAscending.Click += new System.EventHandler(this.cmnuAscending_Click);
            // 
            // cmnuDescending
            // 
            this.cmnuDescending.Name = "cmnuDescending";
            this.cmnuDescending.Size = new System.Drawing.Size(129, 22);
            this.cmnuDescending.Text = "Descending";
            this.cmnuDescending.Click += new System.EventHandler(this.cmnuDescending_Click);
            // 
            // cmnuRefresh
            // 
            this.cmnuRefresh.Name = "cmnuRefresh";
            this.cmnuRefresh.Size = new System.Drawing.Size(185, 22);
            this.cmnuRefresh.Text = "Refresh";
            this.cmnuRefresh.Click += new System.EventHandler(this.cmnuRefresh_Click);
            // 
            // mnuNewWindow
            // 
            this.mnuNewWindow.Name = "mnuNewWindow";
            this.mnuNewWindow.Size = new System.Drawing.Size(185, 22);
            this.mnuNewWindow.Text = "Open in a New Window";
            this.mnuNewWindow.Click += new System.EventHandler(this.mnuNewWindow_Click);
            // 
            // cmnuSeparator1
            // 
            this.cmnuSeparator1.Name = "cmnuSeparator1";
            this.cmnuSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // cmnuCut
            // 
            this.cmnuCut.Name = "cmnuCut";
            this.cmnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cmnuCut.Size = new System.Drawing.Size(185, 22);
            this.cmnuCut.Text = "Cut";
            this.cmnuCut.Click += new System.EventHandler(this.cmnuCut_Click);
            // 
            // cmnuCopy
            // 
            this.cmnuCopy.Name = "cmnuCopy";
            this.cmnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cmnuCopy.Size = new System.Drawing.Size(185, 22);
            this.cmnuCopy.Text = "Copy Folder";
            this.cmnuCopy.Click += new System.EventHandler(this.cmnuCopy_Click);
            // 
            // cmnuPaste
            // 
            this.cmnuPaste.Name = "cmnuPaste";
            this.cmnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.cmnuPaste.Size = new System.Drawing.Size(185, 22);
            this.cmnuPaste.Text = "Paste";
            this.cmnuPaste.Click += new System.EventHandler(this.cmnuPaste_Click);
            // 
            // cmnuSeparator2
            // 
            this.cmnuSeparator2.Name = "cmnuSeparator2";
            this.cmnuSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // cmnuDelete
            // 
            this.cmnuDelete.Name = "cmnuDelete";
            this.cmnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.cmnuDelete.Size = new System.Drawing.Size(185, 22);
            this.cmnuDelete.Text = "Delete";
            this.cmnuDelete.Click += new System.EventHandler(this.cmnuDelete_Click);
            // 
            // cmnuRename
            // 
            this.cmnuRename.Name = "cmnuRename";
            this.cmnuRename.Size = new System.Drawing.Size(185, 22);
            this.cmnuRename.Text = "Rename";
            this.cmnuRename.Click += new System.EventHandler(this.cmnuRename_Click);
            // 
            // cmnuSeparator3
            // 
            this.cmnuSeparator3.Name = "cmnuSeparator3";
            this.cmnuSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuDirectory,
            this.cmnuForm,
            this.cmnuCatalog,
            this.cmnuDailyReport,
            this.cmnuWeeklyReport,
            this.cmnuMonthlyReport,
            this.cmnuQuarterlyReport,
            this.cmnuYearlyReport});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // cmnuDirectory
            // 
            this.cmnuDirectory.Name = "cmnuDirectory";
            this.cmnuDirectory.Size = new System.Drawing.Size(123, 22);
            this.cmnuDirectory.Text = "Folder";
            this.cmnuDirectory.Click += new System.EventHandler(this.cmnuFolder_Click);
            // 
            // cmnuForm
            // 
            this.cmnuForm.Name = "cmnuForm";
            this.cmnuForm.Size = new System.Drawing.Size(123, 22);
            this.cmnuForm.Text = "Form";
            this.cmnuForm.Click += new System.EventHandler(this.cmnuForm_Click);
            // 
            // cmnuCatalog
            // 
            this.cmnuCatalog.Name = "cmnuCatalog";
            this.cmnuCatalog.Size = new System.Drawing.Size(123, 22);
            this.cmnuCatalog.Text = "Catalogue";
            this.cmnuCatalog.Click += new System.EventHandler(this.cmnuCatalog_Click);
            // 
            // cmnuDailyReport
            // 
            this.cmnuDailyReport.Name = "cmnuDailyReport";
            this.cmnuDailyReport.Size = new System.Drawing.Size(123, 22);
            this.cmnuDailyReport.Text = "Daily";
            this.cmnuDailyReport.Click += new System.EventHandler(this.cmnuDailyReport_Click);
            // 
            // cmnuWeeklyReport
            // 
            this.cmnuWeeklyReport.Name = "cmnuWeeklyReport";
            this.cmnuWeeklyReport.Size = new System.Drawing.Size(123, 22);
            this.cmnuWeeklyReport.Text = "Weekly";
            this.cmnuWeeklyReport.Click += new System.EventHandler(this.cmnuWeeklyReport_Click);
            // 
            // cmnuMonthlyReport
            // 
            this.cmnuMonthlyReport.Name = "cmnuMonthlyReport";
            this.cmnuMonthlyReport.Size = new System.Drawing.Size(123, 22);
            this.cmnuMonthlyReport.Text = "Monthly";
            this.cmnuMonthlyReport.Click += new System.EventHandler(this.cmnuMonthlyReport_Click);
            // 
            // cmnuQuarterlyReport
            // 
            this.cmnuQuarterlyReport.Name = "cmnuQuarterlyReport";
            this.cmnuQuarterlyReport.Size = new System.Drawing.Size(123, 22);
            this.cmnuQuarterlyReport.Text = "Quarterly";
            this.cmnuQuarterlyReport.Click += new System.EventHandler(this.cmnuQuarterlyReport_Click);
            // 
            // cmnuYearlyReport
            // 
            this.cmnuYearlyReport.Name = "cmnuYearlyReport";
            this.cmnuYearlyReport.Size = new System.Drawing.Size(123, 22);
            this.cmnuYearlyReport.Text = "Yearly";
            this.cmnuYearlyReport.Click += new System.EventHandler(this.cmnuYearlyReport_Click);
            // 
            // imgMisc
            // 
            this.imgMisc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMisc.ImageStream")));
            this.imgMisc.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMisc.Images.SetKeyName(0, "Dot.gif");
            // 
            // pnlAddress
            // 
            this.pnlAddress.Controls.Add(this.txtAddress);
            this.pnlAddress.Controls.Add(this.btnEnter);
            this.pnlAddress.Controls.Add(this.btnBack);
            this.pnlAddress.Controls.Add(this.btnUp);
            this.pnlAddress.Controls.Add(this.txtSearch);
            this.pnlAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAddress.Location = new System.Drawing.Point(0, 0);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(698, 20);
            this.pnlAddress.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(40, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(428, 20);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyUp);
            // 
            // btnEnter
            // 
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnEnter.Location = new System.Drawing.Point(468, 0);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(23, 20);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Æ";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBack.Location = new System.Drawing.Point(20, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(20, 20);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Å";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnUp.Location = new System.Drawing.Point(0, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(20, 20);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "Ç";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.Location = new System.Drawing.Point(491, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(207, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Search...";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlArtifact);
            this.Controls.Add(this.pnlAddress);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(698, 430);
            this.Load += new System.EventHandler(this.Register_Load);
            this.pnlArtifact.Panel1.ResumeLayout(false);
            this.pnlArtifact.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlArtifact)).EndInit();
            this.pnlArtifact.ResumeLayout(false);
            this.tbcCategory.ResumeLayout(false);
            this.tbpForm.ResumeLayout(false);
            this.tbpCatalogue.ResumeLayout(false);
            this.tbpReport.ResumeLayout(false);
            this.cmsExplorer.ResumeLayout(false);
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer pnlArtifact;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip cmsExplorer;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpen;
        private System.Windows.Forms.ToolStripMenuItem cmnuView;
        private System.Windows.Forms.ToolStripMenuItem cmnuLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem cmnuSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem cmnuList;
        private System.Windows.Forms.ToolStripMenuItem cmnuDetail;
        private System.Windows.Forms.ToolStripMenuItem cmnuSort;
        private System.Windows.Forms.ToolStripMenuItem cmnuCreatedAt;
        private System.Windows.Forms.ToolStripMenuItem cmnuCreatedBy;
        private System.Windows.Forms.ToolStripMenuItem cmnuModifiedAt;
        private System.Windows.Forms.ToolStripMenuItem cmnuModifiedBy;
        private System.Windows.Forms.ToolStripMenuItem cmnuName;
        private System.Windows.Forms.ToolStripMenuItem cmnuType;
        private System.Windows.Forms.ToolStripMenuItem cmnuVersion;
        private System.Windows.Forms.ToolStripSeparator cmnuSortSepaerator;
        private System.Windows.Forms.ToolStripMenuItem cmnuAscending;
        private System.Windows.Forms.ToolStripMenuItem cmnuDescending;
        private System.Windows.Forms.ToolStripMenuItem cmnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuNewWindow;
        private System.Windows.Forms.ToolStripSeparator cmnuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmnuCut;
        private System.Windows.Forms.ToolStripMenuItem cmnuCopy;
        private System.Windows.Forms.ToolStripMenuItem cmnuPaste;
        private System.Windows.Forms.ToolStripSeparator cmnuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmnuDelete;
        private System.Windows.Forms.ToolStripMenuItem cmnuRename;
        private System.Windows.Forms.ToolStripSeparator cmnuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmnuDirectory;
        private System.Windows.Forms.ToolStripMenuItem cmnuForm;
        private System.Windows.Forms.ToolStripMenuItem cmnuCatalog;
        private System.Windows.Forms.ImageList imgMediumIcons;
        private System.Windows.Forms.ImageList imgLargeIcon;
        private System.Windows.Forms.ImageList imgMisc;
        private System.Windows.Forms.TabControl tbcCategory;
        private System.Windows.Forms.TabPage tbpForm;
        private System.Windows.Forms.TreeView trvForm;
        private System.Windows.Forms.TabPage tbpReport;
        private System.Windows.Forms.TreeView trvReport;
        private System.Windows.Forms.ListView lsvContainer;
        private System.Windows.Forms.ImageList imgSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem cmnuTile;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TextBox txtSearch;
        private SearchResult ucSearchResult;
        private System.Windows.Forms.ToolStripMenuItem cmnuDailyReport;
        private System.Windows.Forms.ToolStripMenuItem cmnuWeeklyReport;
        private System.Windows.Forms.ToolStripMenuItem cmnuMonthlyReport;
        private System.Windows.Forms.ToolStripMenuItem cmnuQuarterlyReport;
        private System.Windows.Forms.ToolStripMenuItem cmnuYearlyReport;
        private System.Windows.Forms.TabPage tbpCatalogue;
        private System.Windows.Forms.TreeView trvCatalogue;
    }
}
