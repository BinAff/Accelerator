using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Facade.Cache;
using FacLib = BinAff.Facade.Library;
using PresLib = BinAff.Presentation.Library;

using Vanilla.Utility.WinForm.Extender;
using UtilFac = Vanilla.Utility.Facade;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ModFac = Vanilla.Utility.Facade.Module;
using ModDefFac = Vanilla.Utility.Facade.Module.Definition;
using AccFac = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Utility.WinForm
{

    public partial class Register : UserControl
    {

        public DialogueMode DialogueMode { get; set; }

        /// <summary>
        /// Selected document or folder
        /// </summary>
        public ArtfFac.Dto CurrentArtifact
        {
            get
            {
                return this.currentArtifact;
            }
        }

        /// <summary>
        /// Parent folder of new node
        /// </summary>
        public ArtfFac.Dto ParentFolder { get; set; }

        private Facade.Register.FormDto formDto;
        private Facade.Register.Server facade;

        List<String> addressList; //This is for back button. This will hold all navigations
        Boolean isRenaming;

        private ArtfFac.Dto cutArtifact;

        private PresLib.ListViewColumnSorter columnSorter;

        private TreeNode editNode;
        private String sortColumn;
        private SortOrder sortOrder;
        private Boolean isCutAction;
        private Boolean isDocumentFirst;

        private ArtfFac.Dto currentArtifact;
        private MenuClickSource menuClickSource;

        /// <summary>
        /// This is for progress bar
        /// </summary>
        private Int16 loadPercentage;

        private String address;
        public String Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (this.address != value)
                {
                    this.address = value;
                    if (PathChanged != null) PathChanged();
                }
            }
        }

        public ArtfFac.Category Category { get; set; }

        #region Exposed events

        public delegate void ChangePath();
        public event ChangePath PathChanged;

        public delegate void OnReportLoad(ArtfFac.Dto currentArtifact);
        public event OnReportLoad ReportLoad;

        public delegate Document OnReportAdded(ArtfFac.Dto currentArtifact, Facade.Register.Server registerFacade, FacLib.Dto moduleFormDto);
        public event OnReportAdded ReportAdded;

        public delegate void OnReportCategoryGet(ArtfFac.Dto currentArtifact, String categoryName);
        public event OnReportCategoryGet ReportCategoryGet;

        public delegate void OnFormLoad(ArtfFac.Dto currentArtifact);
        public event OnFormLoad FormLoad;

        public delegate void OnDocumentShown();
        public event OnDocumentShown DocumentShown;

        public delegate void OnDocumentClicked();
        public event OnDocumentClicked DocumentClicked;

        public delegate void OnArtifactClicked();
        public event OnArtifactClicked ArtifactClicked;

        #endregion

        public Register()
        {
            InitializeComponent();
            this.DialogueMode = DialogueMode.None;
            this.sortOrder = SortOrder.Ascending;
            this.addressList = new List<String>();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.lsvContainer.Dock = DockStyle.Fill;
            this.ucSearchResult.Dock = DockStyle.Fill;
            this.tbcCategory.TabPages.Remove(this.tbpCatalogue);
        }

        public void LoadForm()
        {
            this.loadPercentage = 0;
            Timer t = new Timer { Interval = 10 };
            t.Tick += t_Tick;

            this.cmsExplorer.ImageList = this.imgSmallIcon;
            this.columnSorter = new PresLib.ListViewColumnSorter();
            this.sortColumn = this.lsvContainer.Initialize();
            this.InitializeTab();
            this.facade = new Facade.Register.Server(this.formDto = new Facade.Register.FormDto
            {
                ModuleFormDto = new ModFac.FormDto
                {
                    Dto = new ModFac.Dto()
                },
            });
            this.loadPercentage = 10;
            t.Start();
            this.facade.LoadForm();
            t.Stop();
            this.loadPercentage = 90;
            this.LoadModules(tbcCategory.TabPages[0].Text);
            this.txtAddress.Text = "Form" + this.formDto.Rule.ModuleSeperator;
            this.lsvContainer.Items.Clear();
            this.btnBack.Enabled = false;
            this.btnUp.Enabled = false;

            //Show only proper tab
            if (this.DialogueMode != DialogueMode.None)
            {
                switch (this.Category)
                {
                    case ArtfFac.Category.Form:
                        this.tbcCategory.TabPages.Remove(this.tbpReport);
                        break;
                    case ArtfFac.Category.Report:
                        this.tbcCategory.TabPages.Remove(this.tbpForm);
                        break;
                }
            }
            this.loadPercentage = 100;
        }

        public Boolean IsDocumentExistsInFolder(String name)
        {
            return this.lsvContainer.IsExist(name);
        }

        public void AttachDocument(ArtfFac.Dto document)
        {
            ArtfFac.Dto parentArtifact = this.GetParent(document);
            TreeView currrentTreeView = this.GetActiveTreeView();
            TreeNode parentNode = currrentTreeView.FindNode(parentArtifact);
            this.GetArtifact(parentNode.Tag).Children.Add(document);
            if (currrentTreeView.SelectedNode == parentNode)
            {
                this.lsvContainer.AttachChild(document);
            }
        }

        #region Progressbar

        public Int16 GetStatus()
        {
            return (Int16)Math.Abs(this.loadPercentage * 0.8);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            this.loadPercentage = this.facade.GetStatus();
        }

        #endregion

        #region TreeView

        #region Events

        private void trvArtifact_MouseDown(object sender, MouseEventArgs e)
        {
            this.menuClickSource = MenuClickSource.TreeView;
            // Select the clicked node
            TreeView current = sender as TreeView;
            current.SelectedNode = current.GetNodeAt(e.X, e.Y);
            current.Sort(current.SelectedNode);

            this.currentArtifact = current.SelectedNode == null ? null : current.SelectedNode.Tag as ArtfFac.Dto;

            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem menuItem = cmsExplorer.Items[0] as ToolStripMenuItem;
                //check whether right click is done on tree node
                //Avoiding operations for the Modules
                if (current.SelectedNode != null)
                {
                    this.ShowHideContextMenuItems(current.SelectedNode);
                    this.cmsExplorer.Show(current, e.Location);
                }
            }
        }

        private void trvArtifact_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            (sender as TreeView).LabelEdit = false;

            ArtfFac.Dto artifactDto = e.Node.Tag as ArtfFac.Dto;
            String artifactFileName = String.Empty;

            if (e.Label != null && e.Label.Trim().Length == 0)
                e.CancelEdit = true; // Can not be empty text            
            else if ((e.Node.Tag as ArtfFac.Dto).Id > 0 && e.Label == null) //no text inserted during edit            
                e.CancelEdit = true; // Can not be empty text            
            else if ((e.Node.Tag as ArtfFac.Dto).Id > 0 && e.Label.Trim() == e.Node.Text.Trim()) //same text inserted during edit            
                e.CancelEdit = true; // Can not be empty text

            if (e.CancelEdit)
            {
                artifactFileName = artifactDto.FileName;

                if (artifactDto.Id != 0)
                    return;
            }

            if (artifactFileName == String.Empty)
                artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? e.Node.Text : e.Label.Trim();

            this.SaveArtifact(artifactDto, artifactFileName, artifactDto.Id != 0);

        }

        private void trvArtifact_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //this.facade.LoadForm(); Commented by Arpan, looks unnecessary.
            this.facade.LoadArtifacts(e.Node.Text);
        }

        private void trvArtifact_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.EditTreeViewSelectedNode();
            }
        }

        private void trvArtifact_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.ucSearchResult.Hide();
            this.lsvContainer.Show();
            ArtfFac.Dto selectedNode = this.GetArtifact((sender as TreeView).SelectedNode.Tag);
            this.currentArtifact = selectedNode;
            this.lsvContainer.AttachChildren(this.currentArtifact, isDocumentFirst);
            this.txtAddress.Text = selectedNode.Path;
            this.btnUp.Enabled = true;
            if (this.addressList.Count == 0)
            {
                this.btnBack.Enabled = true;
            }

            if (this.addressList.Count == 0 || this.addressList[this.addressList.Count - 1] != selectedNode.Path)
            {
                this.addressList.Add(selectedNode.Path);
            }
            this.formDto.ModuleFormDto.Dto = (sender as TreeView).FindRootNode().Tag as ModFac.Dto;
            if (this.DialogueMode == DialogueMode.None) this.ArtifactClicked();
        }

        private void trvReport_MouseDown(object sender, MouseEventArgs e)
        {
            this.menuClickSource = MenuClickSource.TreeView;
            TreeView current = sender as TreeView;
            current.SelectedNode = current.GetNodeAt(e.X, e.Y);
            current.Sort(current.SelectedNode);
            this.currentArtifact = current.SelectedNode == null ? null : current.SelectedNode.Tag as ArtfFac.Dto;

            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem menuItem = cmsExplorer.Items[0] as ToolStripMenuItem;
                //check whether right click is done on tree node
                //Avoiding operations for the Modules
                if (current.SelectedNode != null)
                {
                    this.ShowHideContextMenuItems(current.SelectedNode);
                    this.cmsExplorer.Show(current, e.Location);
                }
            }
        }

        private void trvReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //this.facade.LoadArtifacts(e.Node.Text);
        }

        private void trvReport_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.ucSearchResult.Hide();
            this.lsvContainer.Show();
            ArtfFac.Dto selectedNode = this.GetArtifact((sender as TreeView).SelectedNode.Tag);
            this.currentArtifact = selectedNode;

            this.lsvContainer.AttachChildren(this.currentArtifact, isDocumentFirst);

            this.txtAddress.Text = selectedNode.Path;
            this.btnUp.Enabled = true;
            if (this.addressList.Count == 0)
            {
                this.btnBack.Enabled = true;
            }

            if (this.addressList.Count == 0 || this.addressList[this.addressList.Count - 1] != selectedNode.Path)
            {
                this.addressList.Add(selectedNode.Path);
            }
            this.formDto.ModuleFormDto.Dto = (sender as TreeView).FindRootNode().Tag as ModFac.Dto;
            if (this.DialogueMode == DialogueMode.None) this.ArtifactClicked();
        }

        #endregion

        private void SetAuditInfoForNewRecord(ArtfFac.Dto artifact)
        {
            if (artifact.Id == 0)
            {
                artifact.AuditInfo.Version = 1;
                artifact.AuditInfo.CreatedBy = new Table
                {
                    Id = (Server.Current.Cache["User"] as AccFac.Dto).Id,
                    Name = (Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                };
                artifact.AuditInfo.CreatedAt = DateTime.Now;
            }
        }

        private void ResetColumnOrderInListView()
        {
            for (int i = 0; i < this.lsvContainer.Columns.Count; i++)
            {
                this.lsvContainer.Columns[i].DisplayIndex = i;
            }
        }

        private Boolean IsTreeViewItem(String contextMenuName, TreeNode node)
        {
            switch (contextMenuName)
            {
                case "cmnuRefresh":
                    return true;
                case "cmnuSeparator1":
                    return true;
                case "cmnuCut":
                    return (node.Parent != null);
                case "cmnuCopy":
                    return (node.Parent != null);
                case "cmnuPaste":
                    return this.editNode != null;
                case "cmnuSeparator2":
                    return true;
                case "cmnuDelete":
                    return (node.Parent != null);
                case "cmnuRename":
                    return (node.Parent != null);
                case "cmnuSeparator3":
                    return (node.Parent != null);
                case "newToolStripMenuItem":
                    return true;
                default:
                    return false;
            }
        }

        private void RemoveChildDtoFromParentDto(TreeNode parentNode, TreeNode childNode)
        {
            ArtfFac.Dto parentArtifactDto = this.GetArtifact(parentNode.Tag);
            foreach (ArtfFac.Dto child in parentArtifactDto.Children)
            {
                if (child.Id == (childNode.Tag as ArtfFac.Dto).Id)
                {
                    parentArtifactDto.Children.Remove(child);
                    break;
                }
            }
        }

        private void RemoveChildDtoFromParentDto(ArtfFac.Dto parentArtifactDto, ArtfFac.Dto childArtifactDto)
        {
            foreach (ArtfFac.Dto child in parentArtifactDto.Children)
            {
                if (child.Id == childArtifactDto.Id)
                {
                    parentArtifactDto.Children.Remove(child);
                    break;
                }
            }
        }

        private void AddChildDtoToParentDto(TreeNode parentNode, TreeNode childNode)
        {
            ArtfFac.Dto parentArtifact = this.GetArtifact(parentNode.Tag);
            if (parentArtifact.Children == null)
            {
                parentArtifact.Children = new List<ArtfFac.Dto>();
            }

            parentArtifact.Children.Add(childNode.Tag as ArtfFac.Dto);
        }

        private void AddChildDtoToParentDto(ArtfFac.Dto parentArtifactDto, ArtfFac.Dto childArtifactDto)
        {
            if (parentArtifactDto.Children == null)
            {
                parentArtifactDto.Children = new List<ArtfFac.Dto>();
            }

            parentArtifactDto.Children.Add(childArtifactDto);
            childArtifactDto.Parent = parentArtifactDto;
        }

        private void AttachTagToChildNodes(TreeNode node)
        {
            ArtfFac.Dto artifactDto = node.Tag as ArtfFac.Dto;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Tag = artifactDto.Children[i] as ArtfFac.Dto;
                if (node.Nodes[i].Nodes != null && node.Nodes[i].Nodes.Count > 0)
                {
                    this.AttachTagToChildNodes(node.Nodes[i]);
                }
            }
        }

        private void EditTreeViewSelectedNode()
        {
            TreeView current = new TreeView();

            if (tbcCategory.SelectedTab.Text == "Form")
                current = trvForm as TreeView;
            else if (tbcCategory.SelectedTab.Text == "Catalogue")
                current = trvCatalogue as TreeView;
            else if (tbcCategory.SelectedTab.Text == "Report")
                current = trvReport as TreeView;

            current.LabelEdit = true;
            current.SelectedNode.BeginEdit();
        }

        private void ShowHideContextMenuItems(TreeNode treeNode)
        {
            this.currentArtifact = this.GetArtifact(treeNode.Tag);

            for (int i = 0; i < cmsExplorer.Items.Count; i++)
            {
                if (cmsExplorer.Items[i].Name == "cmnuPaste")
                {
                    cmsExplorer.Items[i].Enabled = IsTreeViewItem(cmsExplorer.Items[i].Name, treeNode);
                }
                else
                {
                    cmsExplorer.Items[i].Visible = IsTreeViewItem(cmsExplorer.Items[i].Name, treeNode);
                }

                if (cmsExplorer.Items[i].Name == "newToolStripMenuItem")
                {
                    this.ShowHideContextMenuNewItems((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems);
                }
            }
        }

        #endregion

        #region ListView

        #region Events

        private void lsvContainer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = true;
            (sender as ListView).LabelEdit = false;
            TreeView trv = this.GetActiveTreeView();

            ListViewItem selectedItem = (sender as ListView).FocusedItem;
            ArtfFac.Dto selectedArtifact = selectedItem.Tag as ArtfFac.Dto;

            String documentName = selectedArtifact.FullFileName;
            String defaultFileName = selectedArtifact.FileName;
            String artifactFileName = String.Empty;

            //validate if label name is not empty
            if (e.Label == null || e.Label.Trim().Length == 0)
            {
                artifactFileName = selectedArtifact.FileName;
                if (selectedArtifact.Id != 0)
                {
                    if (selectedArtifact.Style == ArtfFac.Type.Document)
                    {
                        selectedItem.Text = documentName;
                    }
                    return;
                }
            }

            if (String.IsNullOrEmpty(artifactFileName))
            {
                artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? selectedItem.Text.Trim() : e.Label.Trim();
            }

            //check if the name is duplicate
            if (this.IsListViewItemDuplicate(this.lsvContainer.Items, selectedArtifact, artifactFileName))
            {
                if (selectedArtifact.Style == ArtfFac.Type.Document)
                {
                    selectedItem.Text = documentName;
                }
                return;
            }
            this.SaveArtifact(selectedArtifact, artifactFileName, selectedArtifact.Id != 0);
            this.RefreshTreeAfterLabelEdit(trv, selectedArtifact);
            if (this.currentArtifact.Category == ArtfFac.Category.Report)
            {
                this.ReportLoad(this.formDto.ModuleFormDto.CurrentArtifact.Dto);
            }
            else
            {
                if (this.formDto.ModuleFormDto.CurrentArtifact.Dto.Style == ArtfFac.Type.Document && !this.isRenaming)
                {
                    this.FormLoad(this.formDto.ModuleFormDto.CurrentArtifact.Dto);
                }
            }
            this.isRenaming = false; //Rename done
            this.lsvContainer.Sort("Name", new PresLib.ListViewColumnSorter
            {
                Order = SortOrder.Ascending
            }, false);
        }

        private void RefreshTreeAfterLabelEdit(TreeView trv, ArtfFac.Dto selectedArtifact)
        {
            //Update TreeNode Text
            if (selectedArtifact.Style == ArtfFac.Type.Folder)
            {
                TreeNode selectedNode = trv.FindNode(selectedArtifact);

                selectedNode.Text = selectedArtifact.FileName;
                (selectedNode.Tag as ArtfFac.Dto).FileName = selectedArtifact.FileName;
            }


            //code added to fix issue
            //issue description : if any document is created on root and then double click immediately to open the form in edit mode , was giving error
            //if this block is moved up before save, then a foreign key error will be thrown
            //if (selectedArtifact.Style == ArtfFac.Type.Document)
            //{
            //    if ((selectedNode.Tag.GetType().ToString() == "ModFac.Dto") && (selectedArtifact.Parent == null))
            //    {
            //        (selectedItem.Tag as ArtfFac.Dto).Parent = selectedNode.Tag as ModFac.Dto;
            //    }
            //}
        }

        private Boolean IsListViewItemDuplicate(ListView.ListViewItemCollection lstViewItems, ArtfFac.Dto selectedArtifact, String artifactFileName)
        {
            //loop through the list to check for duplicate
            foreach (ListViewItem item in lstViewItems)
            {
                ArtfFac.Dto artifactDto = item.Tag as ArtfFac.Dto;
                if ((artifactDto.Id != selectedArtifact.Id) && (artifactDto.Style == selectedArtifact.Style))
                {
                    if (String.Compare(artifactDto.FileName.Trim(), artifactFileName.Trim(), true) == 0)
                    {
                        new PresLib.MessageBox
                        {
                            DialogueType = PresLib.MessageBox.Type.Information,
                            Heading = "Navigator",
                        }.Show("Name already exists. Please assign a different name.");

                        if (selectedArtifact.Id != 0)
                        {
                            //if (selectedArtifact.Category == ArtfFac.Category.Report && selectedArtifact.Style == ArtfFac.Type.Document)
                            //{
                            //    selectedItem.Text = documentName;
                            //}

                            //if (selectedArtifact.Style == ArtfFac.Type.Document)
                            //    selectedItem.Text = selectedArtifact.FullFileName;
                            return true;
                        }
                        //else
                        //{
                        //    artifactFileName = selectedArtifact.FileName;
                        //}
                    }
                }
            }

            return false;
        }

        private void lsvContainer_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem selected = this.lsvContainer.GetItemAt(e.X, e.Y);

            //-- check for null
            TreeView trv = this.GetActiveTreeView();
            if (selected == null && trv == null)
                return;

            this.currentArtifact = selected == null ?
                this.GetActiveTreeView().SelectedNode.Tag as ArtfFac.Dto : selected.Tag as ArtfFac.Dto;
            this.menuClickSource = MenuClickSource.ListView;
            if (e.Button == MouseButtons.Right)
            {
                this.ShowHideContextMenuItems(selected);
                this.cmsExplorer.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (this.lsvContainer.GetItemAt(e.X, e.Y) != null) //Clicked on one item
                {
                    if (selected == this.lsvContainer.FocusedItem)
                    {
                        //TO DO :: Edit like F2
                    }
                }
            }
        }

        private void lsvContainer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.isRenaming = true;
                this.lsvContainer.EditListViewSelectedItem();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.OpenArtifact();
            }
        }

        private void lsvContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentArtifact = this.lsvContainer.FocusedItem.Tag as ArtfFac.Dto;//Any impact?
            if (this.DialogueMode != DialogueMode.None)
            {
                if (this.currentArtifact.Style == ArtfFac.Type.Document) this.DocumentClicked();
            }
            else
            {
                this.ArtifactClicked();
            }
        }

        private void lsvContainer_DoubleClick(object sender, EventArgs e)
        {
            this.OpenArtifact();
        }

        private void lsvContainer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.lsvContainer.Items.Count > 0)
                isDocumentFirst = ((this.lsvContainer.Items[0].Tag as ArtfFac.Dto).Style == ArtfFac.Type.Document) ? false : true;

            this.lsvContainer.ResetColumnHeader();
            this.sortColumn = this.lsvContainer.Columns[e.Column].Text;

            //Determine if clicked column is already the column that is being sorted.   
            if (e.Column == this.columnSorter.SortColumn)
            {
                if (this.columnSorter.Order == SortOrder.Ascending || this.columnSorter.Order == SortOrder.None)
                {
                    this.columnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    this.columnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                this.columnSorter.SortColumn = e.Column;
                this.columnSorter.Order = SortOrder.Ascending;
            }

            this.lsvContainer.Sort(this.sortColumn, this.columnSorter, isDocumentFirst);
        }

        #endregion

        /// <summary>
        /// Open folder or show document depending on current document
        /// </summary>
        private void OpenArtifact()
        {
            switch (this.DialogueMode)
            {
                case DialogueMode.None:
                case DialogueMode.Open:
                    if (currentArtifact.Style == ArtfFac.Type.Folder)
                    {
                        this.OpenFolder();
                    }
                    else
                    {
                        this.ShowDocument();
                    }
                    break;
                case DialogueMode.Save:
                    if (currentArtifact.Style == ArtfFac.Type.Folder)
                    {
                        this.OpenFolder();
                    }
                    break;
                case DialogueMode.New:
                    //
                    break;
            }
        }

        private void OpenFolder()
        {
            this.lsvContainer.AttachChildren(this.currentArtifact, isDocumentFirst);
            this.SelectNode(this.currentArtifact);
            this.txtAddress.Text = this.currentArtifact.Path;
            this.addressList.Add(this.currentArtifact.Path);
            this.btnUp.Enabled = true;
        }

        public void ShowDocument()
        {
            this.currentArtifact = this.ReadDocument(this.currentArtifact);
            if (this.currentArtifact.Category == ArtfFac.Category.Report)
            {
                this.ReportLoad(this.currentArtifact);
            }
            else
            {
                this.FormLoad(this.currentArtifact);
            }
            if (this.DialogueMode == DialogueMode.Open)
            {
                this.DocumentShown();
            }
        }

        private Boolean IsListViewItem(String contextMenuName, ListViewItem listViewItem)
        {
            switch (contextMenuName)
            {
                case "cmnuOpen":
                    return listViewItem != null;
                case "cmnuView":
                    return listViewItem == null;
                case "cmnuSort":
                    return listViewItem == null;
                case "cmnuRefresh":
                    return ((listViewItem == null) || (listViewItem.Tag as ArtfFac.Dto).Style == ArtfFac.Type.Folder);
                case "newToolStripMenuItem":
                    return listViewItem == null;
                case "cmnuDelete":
                    return listViewItem != null;
                case "cmnuRename":
                    return listViewItem != null;
                case "cmnuCut":
                    return listViewItem != null;
                case "cmnuCopy":
                    return ((listViewItem != null) && ((listViewItem.Tag as ArtfFac.Dto).Style == ArtfFac.Type.Folder));
                case "cmnuPaste":
                    {
                        Boolean blnPaste = ((listViewItem != null) && (this.editNode != null) && ((listViewItem.Tag as ArtfFac.Dto).Style == ArtfFac.Type.Folder));

                        //// cut document
                        //if (!blnPaste)
                        //{
                        //    if (isCutAction == true && this.cutArtifact != null)
                        //        blnPaste = true;
                        //}

                        return blnPaste;
                    }
                //return ((listViewItem != null) && (this.editNode != null) && ((listViewItem.Tag as ArtfFac.Dto).Style == ArtfFac.Type.Folder));
                case "cmnuSeparator1":
                    return true;
                case "cmnuSeparator2":
                    return true;
                default:
                    return false;
            }
        }
        
        private void ShowHideContextMenuItems(ListViewItem listViewItem)
        {
            if (listViewItem != null)
            {
                this.currentArtifact = listViewItem.Tag as ArtfFac.Dto;
            }
            for (int i = 0; i < cmsExplorer.Items.Count; i++)
            {
                if (cmsExplorer.Items[i].Name == "cmnuPaste")
                {
                    //root node
                    if (this.currentArtifact != null && this.currentArtifact.Module == null && this.currentArtifact.Path == "Form")
                        this.currentArtifact.Style = ArtfFac.Type.Folder;

                    ListViewItem listViewPaste = null;
                    //if (listViewItem == null && this.currentArtifact != null)
                    if (this.currentArtifact != null && this.currentArtifact.Style == ArtfFac.Type.Folder)
                    {
                        listViewPaste = new ListViewItem
                        {
                            Tag = this.currentArtifact
                        };
                    }
                    cmsExplorer.Items[i].Enabled = this.IsListViewItem(cmsExplorer.Items[i].Name, listViewPaste);
                }
                else
                    cmsExplorer.Items[i].Visible = this.IsListViewItem(cmsExplorer.Items[i].Name, listViewItem);

                //attach image to context menu
                if ((cmsExplorer.Items[i].Name == "cmnuSort" && columnSorter.Order != SortOrder.None) || (cmsExplorer.Items[i].Name == "cmnuView"))
                {
                    this.SetImageInContextMenu((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems, cmsExplorer.Items[i].Name);
                }
                if (cmsExplorer.Items[i].Name == "newToolStripMenuItem")
                {
                    this.ShowHideContextMenuNewItems((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems);
                }
            }
        }

        private void SetImageInContextMenu(ToolStripItemCollection sortItems, String menuName)
        {
            //clear images
            for (int i = 0; i < sortItems.Count; i++)
            {
                sortItems[i].Image = null;
            }

            //set image in list context menu
            for (int i = 0; i < sortItems.Count; i++)
            {
                if (menuName == "cmnuSort")
                {
                    if ((this.sortColumn == sortItems[i].Text) || (this.columnSorter.Order.ToString() == sortItems[i].Text))
                    {
                        sortItems[i].Image = this.imgMisc.Images["Dot.gif"];
                    }
                }
                else if (menuName == "cmnuView")
                {
                    String view = String.Empty;

                    if (sortItems[i].Text == "Large Icon")
                        view = "LargeIcon";
                    else if (sortItems[i].Text == "Small Icon")
                        view = "SmallIcon";
                    else
                        view = sortItems[i].Text;

                    if (view == this.lsvContainer.View.ToString())
                        sortItems[i].Image = this.imgMisc.Images["Dot.gif"];
                }
            }
        }

        #endregion

        private void ShowHideContextMenuNewItems(ToolStripItemCollection newItems)
        {
            //starting from 2nd item, since the 1st item Folder will always be visible
            for (int i = 1; i < newItems.Count; i++)
            {
                switch (tbcCategory.SelectedTab.Text)
                {
                    case "Form":
                        newItems[i].Visible = newItems[i].Text == tbcCategory.SelectedTab.Text;
                        break;
                    case "Report":
                        newItems[i].Visible = (newItems[i].Text == "Catalogue" || newItems[i].Text == "Form") ? false : true;
                        break;
                    case "Catalogue":
                        newItems[i].Visible = newItems[i].Text == tbcCategory.SelectedTab.Text;
                        break;
                    default:
                        newItems[i].Visible = false;
                        break;
                }

            }
        }

        #region Address Bar

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (String.Compare(this.txtSearch.Text, "Search...") == 0)
            {
                this.txtSearch.Text = String.Empty;
                this.txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtSearch.Text))
            {
                this.txtSearch.Text = "Search...";
                this.txtSearch.ForeColor = Color.Gray;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.txtAddress.Text = this.txtAddress.Text.Trim();
            this.SelectNode(this.txtAddress.Text);
            this.addressList.Add(this.currentArtifact.Path);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.addressList.Count > 0)
            {
                this.addressList.RemoveAt(this.addressList.Count - 1);
                if (this.addressList.Count == 0)
                {
                    this.btnBack.Enabled = false;
                    this.txtAddress.Text = "Form" + this.formDto.Rule.ModuleSeperator;
                    this.btnUp.Enabled = false;
                }
                else
                {
                    this.SelectNode(this.addressList[this.addressList.Count - 1]);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            String path = this.currentArtifact.Path;

            path = path.Remove(path.Length - 1);
            path = path.Substring(0, path.LastIndexOf('\\')) + "\\";
            if (path.EndsWith("\\\\"))
            {
                path = path.Remove(path.Length - 2);
                this.btnUp.Enabled = false;
            }
            this.SelectNode(path);
        }

        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNode(this.txtAddress.Text.Trim());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void Search()
        {
            this.pnlArtifact.Panel2.Controls.Add(this.ucSearchResult);
            this.ucSearchResult.Show();
            this.lsvContainer.Hide();
            this.ucSearchResult.LoadResult(this.txtSearch.Text.Trim());
        }

        #endregion

        #region Context Menu

        #region Event

        private void cmnuCut_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void cmnuCopy_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void cmnuPaste_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void cmnuDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void cmnuRename_Click(object sender, EventArgs e)
        {
            //List view Rename is clicked
            if (this.menuClickSource == MenuClickSource.ListView)
            {
                this.lsvContainer.EditListViewSelectedItem();
            }
            else
            {
                this.EditTreeViewSelectedNode();
            }
        }

        private void cmnuOpen_Click(object sender, EventArgs e)
        {
            this.lsvContainer_DoubleClick(this.lsvContainer, e);
        }

        private void cmnuRefresh_Click(object sender, EventArgs e)
        {
            this.SelectNode(this.addressList[this.addressList.Count - 1]);
        }

        #endregion

        public void Cut()
        {
            this.isCutAction = true;
            this.cutArtifact = this.currentArtifact;
            this.PopulateCutCopyNode();
        }

        public void Copy()
        {
            this.isCutAction = false;
            this.PopulateCutCopyNode();
        }

        public void Paste()
        {
            if (!this.ValidatePaste())
                return;

            TreeView trv = this.GetActiveTreeView();
            TreeNode pasteNode = (this.menuClickSource == MenuClickSource.TreeView) ?
                trv.SelectedNode :
                trv.FindNode(this.currentArtifact.Style == ArtfFac.Type.Document ?
                    this.currentArtifact.Parent as ArtfFac.Dto :
                    this.currentArtifact);

            Int64 newParentId = 0;
            ArtfFac.Dto artifactDto = null;

            if (pasteNode.Parent != null)
                newParentId = (pasteNode.Tag as ArtfFac.Dto).Id;

            FacLib.Dto parent = new FacLib.Dto { Id = newParentId };

            Table currentLoggedInUser = new Table
            {
                Id = (Server.Current.Cache["User"] as AccFac.Dto).Id,
                Name = (Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
            };

            String path = String.Empty;
            if (pasteNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                path = (pasteNode.Tag as ModFac.Dto).Artifact.Path;
            else
                path = (pasteNode.Tag as ArtfFac.Dto).Path;

            if (pasteNode.Parent == null)
                path += this.formDto.Rule.ModuleSeperator + this.formDto.Rule.PathSeperator + this.formDto.Rule.PathSeperator + pasteNode.Text + this.formDto.Rule.PathSeperator;

            Boolean pasteDirectory = true;
            if (this.cutArtifact != null)
                pasteDirectory = this.cutArtifact.Style == ArtfFac.Type.Folder;


            if (this.isCutAction)
            {
                if (pasteDirectory)
                    artifactDto = new Facade.Register.Server(null).GetArtifactDtoByValue(this.editNode.Tag as ArtfFac.Dto);
                else
                    artifactDto = new Facade.Register.Server(null).GetArtifactDtoByValue(this.cutArtifact);

                artifactDto.AuditInfo.Version++;
                artifactDto.AuditInfo.ModifiedAt = DateTime.Now;
                artifactDto.AuditInfo.ModifiedBy = currentLoggedInUser;
            }
            else
            {
                artifactDto = new Facade.Register.Server(null).GetArtifactDtoByValueForCopy(editNode.Tag as ArtfFac.Dto);
                artifactDto.AuditInfo.CreatedAt = DateTime.Now;
                artifactDto.AuditInfo.CreatedBy = currentLoggedInUser;
            }

            artifactDto.Parent = parent;

            if (pasteDirectory)
                artifactDto.Path = path + artifactDto.FileName + this.formDto.Rule.PathSeperator;
            else
                artifactDto.Path = path + artifactDto.FileName;

            this.formDto.ModuleFormDto.CurrentArtifact = new ArtfFac.FormDto
            {
                Dto = artifactDto,
            };

            this.facade = new Facade.Register.Server(this.formDto) { Category = this.currentArtifact.Category };
            this.facade.Paste(this.isCutAction);

            if (!this.facade.IsError)
            {
                this.RefreshTreeViewAfterPaste(trv, pasteNode, this.editNode, pasteDirectory, artifactDto);

                this.editNode = null;
                this.cutArtifact = null;
            }
        }

        private Boolean ValidatePaste()
        {

            TreeNode pasteNode = (this.menuClickSource == MenuClickSource.TreeView) ?
               this.trvForm.SelectedNode :
               this.trvForm.FindNode(this.currentArtifact.Style == ArtfFac.Type.Document ?
                   this.currentArtifact.Parent as ArtfFac.Dto :
                   this.currentArtifact);

            Boolean pasteDirectory = true;
            if (this.cutArtifact != null)
                pasteDirectory = this.cutArtifact.Style == ArtfFac.Type.Folder;

            ArtfFac.Dto editArtifactDto = new ArtfFac.Dto();
            if (!pasteDirectory) // not null when pasting a document
            {
                if (this.cutArtifact.Parent.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    editArtifactDto = (this.cutArtifact.Parent as ModFac.Dto).Artifact;
                else
                    editArtifactDto = this.cutArtifact.Parent as ArtfFac.Dto;
            }

            TreeNode editNode = pasteDirectory ? this.editNode : this.trvForm.FindNode(editArtifactDto);

            if (pasteNode == null || editNode == null)
                return false;

            //condition : equal when both node are same [Customer to Customer Or Invoice to Invoice and so on]
            if (!this.trvForm.IsNodeTypeEqual(pasteNode, editNode))
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Splash"
                }.Show("Destination folder type and the Source folder type cannot be same.");

                return false;
            }


            //Validation applicable only for folder            
            if (pasteDirectory)
            {
                //check where destination folder is a sub folder of the source folder
                if (this.CompareNode(pasteNode, editNode))
                {
                    new PresLib.MessageBox
                    {
                        DialogueType = PresLib.MessageBox.Type.Error,
                        Heading = "Splash"
                    }.Show("The destination folder is a subfolder of the source folder.");

                    return false;
                }

                //Check whether any directory of same name exists
                foreach (TreeNode node in pasteNode.Nodes)
                {
                    if (node.Text.Trim() == editNode.Text.Trim())
                    {
                        new PresLib.MessageBox
                        {
                            DialogueType = PresLib.MessageBox.Type.Error,
                            Heading = "Splash"
                        }.Show("Duplicate node exists. Cannot do the paste operation.");

                        return false;
                    }
                }
            }

            if (!pasteDirectory)
            {
                //Check whether any document of same name exists
                ArtfFac.Dto artifactDestination = new ArtfFac.Dto();
                if (pasteNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    artifactDestination = (pasteNode.Tag as ModFac.Dto).Artifact;
                else
                    artifactDestination = pasteNode.Tag as ArtfFac.Dto;

                if (artifactDestination.Children != null)
                {
                    foreach (ArtfFac.Dto artifactDto in artifactDestination.Children)
                    {
                        if (artifactDto.Style == ArtfFac.Type.Document)
                        {
                            if (artifactDto.FileName.ToUpper() == this.cutArtifact.FileName.ToUpper())
                            {
                                new PresLib.MessageBox
                                {
                                    DialogueType = PresLib.MessageBox.Type.Error,
                                    Heading = "Splash"
                                }.Show("Duplicate document exists. Cannot do the paste operation.");

                                return false;
                            }
                        }
                    }
                }
            }


            return true;
        }

        private void RefreshTreeViewAfterPaste(TreeView trv, TreeNode pasteNode, TreeNode editNode, Boolean pasteDirectory, ArtfFac.Dto artifactDto)
        {
            if (pasteDirectory)
            {
                TreeNode childNodeClone = editNode.Clone() as TreeNode;
                childNodeClone.Tag = artifactDto;

                //if Cut
                if (this.isCutAction)
                {
                    trv.RemoveNode(editNode);
                }

                trv.AddNode(pasteNode, childNodeClone, this.formDto.Rule.PathSeperator, this.formDto.Rule.ModuleSeperator);
            }
            else
            {
                trv.AddArtifact(pasteNode, this.cutArtifact, this.formDto.Rule.PathSeperator, this.formDto.Rule.ModuleSeperator);
            }


            this.lsvContainer.AttachChildren(this.currentArtifact, isDocumentFirst);
        }

        public void Delete()
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Folder/Document?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TreeView trv = this.GetActiveTreeView();

                TreeNode node = null;
                TreeNode selectedNode = null;

                if (this.currentArtifact.Style == ArtfFac.Type.Document)
                {
                    node = trv.FindNode(this.GetParent(this.currentArtifact));
                }
                else
                {
                    selectedNode = trv.FindNode(this.currentArtifact);
                    node = selectedNode.Parent;
                }

                if ((this.menuClickSource == MenuClickSource.ListView) && (this.currentArtifact.Style == ArtfFac.Type.Document))
                {
                    this.DeleteDocument(this.currentArtifact);
                }
                else
                {
                    Boolean retVal = true;
                    this.DeleteFolder(this.currentArtifact, retVal);
                }
                this.currentArtifact = this.GetArtifact(node.Tag);

                this.lsvContainer.AttachChildren(this.currentArtifact, isDocumentFirst);

                if (selectedNode != null)
                {
                    trv.SelectedNode = selectedNode.Parent;
                    trv.Nodes.Remove(selectedNode);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private Boolean DeleteDocument(ArtfFac.Dto artifact)
        {
            Boolean retVal = true;
            TreeNode parentNode = this.trvForm.FindNode(this.GetParent(artifact));

            if (parentNode != null)
            {
                retVal = this.DeleteItem(artifact, parentNode);
            }

            return retVal;
        }

        private void DeleteFolder(ArtfFac.Dto artifact, Boolean retVal)
        {
            if (!retVal)
                return;

            //Delete the children
            if (artifact.Children != null)
            {
                while (artifact.Children.Count > 0)
                {
                    if (artifact.Children[0].Style == ArtfFac.Type.Folder)
                        this.DeleteFolder(artifact.Children[0], retVal);
                    else
                    {
                        retVal = this.DeleteDocument(artifact.Children[0]);
                        if (!retVal)
                            break;
                    }
                }
            }


            //Delete Own
            TreeNode node = null;
            //node = this.FindTreeNodeFromTag(artifact, this.trvForm.Nodes, node);
            node = this.trvForm.FindNode(artifact);
            retVal = this.DeleteItem(artifact, node.Parent);

        }

        private Boolean DeleteItem(ArtfFac.Dto artifact, TreeNode parentNode)
        {
            this.formDto.ModuleFormDto.CurrentArtifact = new ArtfFac.FormDto
            {
                Dto = artifact,
            };

            this.facade = new Facade.Register.Server(this.formDto);
            this.facade.Delete();

            if (!this.facade.IsError)
            {
                this.GetParent(artifact).Children.Remove(artifact);
            }
            else
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Splash",
                }.Show("Document contains transactional information. Cannot be deleted.");

                return false;
            }

            return true;
        }

        public void SelectAll()
        {
            foreach (ListViewItem item in this.lsvContainer.Items)
            {
                item.Selected = true;
            }
            this.lsvContainer.Focus();
        }

        public void InvertSelection()
        {
            foreach (ListViewItem item in this.lsvContainer.Items)
            {
                item.Selected = !item.Selected;
            }
        }

        #region Sort

        private void cmnuCreatedAt_Click(object sender, EventArgs e)
        {
            this.Sort("Created At");
        }

        private void cmnuCreatedBy_Click(object sender, EventArgs e)
        {
            this.Sort("Created By");
        }

        private void cmnuModifiedAt_Click(object sender, EventArgs e)
        {
            this.Sort("Modified At");
        }

        private void cmnuModifiedBy_Click(object sender, EventArgs e)
        {
            this.Sort("Modified By");
        }

        private void cmnuName_Click(object sender, EventArgs e)
        {
            this.Sort("Name");
        }

        private void cmnuType_Click(object sender, EventArgs e)
        {
            this.Sort("Type");
        }

        private void cmnuVersion_Click(object sender, EventArgs e)
        {
            this.Sort("Version");
        }

        private void cmnuAscending_Click(object sender, EventArgs e)
        {
            this.Sort(SortOrder.Ascending);
        }

        private void cmnuDescending_Click(object sender, EventArgs e)
        {
            this.Sort(SortOrder.Descending);
        }

        public void Sort(String sortColumn)
        {
            this.sortColumn = sortColumn;
            this.columnSorter.Order = this.sortOrder;

            this.lsvContainer.Sort(this.sortColumn, this.columnSorter, isDocumentFirst);
            //this.SortListView(this.sortColumn);
        }

        public void Sort(SortOrder sortOrder)
        {
            this.sortOrder = sortOrder;
            this.columnSorter.Order = this.sortOrder;

            this.lsvContainer.Sort(this.sortColumn, this.columnSorter, isDocumentFirst);
            //this.SortListView(this.sortColumn);
        }

        public void Sort(String sortColumn, SortOrder sortOrder)
        {
            this.sortColumn = sortColumn;
            this.sortOrder = sortOrder;
            this.columnSorter.Order = this.sortOrder;

            this.lsvContainer.Sort(this.sortColumn, this.columnSorter, isDocumentFirst);
            //this.SortListView(this.sortColumn);
        }

        #endregion

        #region View

        private void cmnuLargeIcon_Click(object sender, EventArgs e)
        {
            this.SetViewForList(View.LargeIcon);
        }

        private void cmnuSmallIcon_Click(object sender, EventArgs e)
        {
            this.SetViewForList(View.SmallIcon);
        }

        private void cmnuList_Click(object sender, EventArgs e)
        {
            this.SetViewForList(View.List);
        }

        private void cmnuDetail_Click(object sender, EventArgs e)
        {
            this.SetViewForList(View.Details);
        }

        private void cmnuTile_Click(object sender, EventArgs e)
        {
            this.SetViewForList(View.Tile);
        }

        public void SetViewForList(View view)
        {
            this.lsvContainer.View = view;
        }

        #endregion

        #region New

        private void cmnuFolder_Click(object sender, EventArgs e)
        {
            this.AddFolder();
            switch(this.menuClickSource)
            {
                case MenuClickSource.TreeView:
                    TreeView trv = this.GetActiveTreeView();
                    trv.LabelEdit = true;
                    trv.SelectedNode.Expand();
                    trv.SelectedNode.Nodes[trv.SelectedNode.Nodes.Count - 1].BeginEdit();
                    break;
                case MenuClickSource.ListView:
                    this.lsvContainer.LabelEdit = true;
                    this.lsvContainer.Items[this.lsvContainer.Items.Count - 1].BeginEdit();
                    //ListViewItem currentItem = null;
                    //foreach (ListViewItem item in this.lsvContainer.Items)
                    //{
                    //    if ((item.Tag as ArtfFac.Dto).Style == ArtfFac.Type.Document) break;
                    //    currentItem = item;
                    //}
                    //if (currentItem != null) currentItem.BeginEdit();
                    break;
            }
        }

        private void cmnuForm_Click(object sender, EventArgs e)
        {
            this.AddDocument(null);
            this.lsvContainer.LabelEdit = true;
            this.lsvContainer.Items[this.lsvContainer.Items.Count - 1].BeginEdit();
        }

        #endregion

        #region Report

        private void cmnuDailyReport_Click(object sender, EventArgs e)
        {
            this.CreateReport("Daily");
        }

        private void cmnuWeeklyReport_Click(object sender, EventArgs e)
        {
            this.CreateReport("Weekly");
        }

        private void cmnuMonthlyReport_Click(object sender, EventArgs e)
        {
            this.CreateReport("Monthly");
        }

        private void cmnuQuarterlyReport_Click(object sender, EventArgs e)
        {
            this.CreateReport("Quarterly");
        }

        private void cmnuYearlyReport_Click(object sender, EventArgs e)
        {
            this.CreateReport("Yearly");
        }

        private void CreateReport(String categoryName)
        {
            TreeNode rootNode = this.GetRootNode();
            this.ReportCategoryGet(this.currentArtifact, categoryName);
            this.AddDocument();
        }

        #endregion

        #endregion

        #region Tab

        private void tbcCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage currentTab = (sender as TabControl).SelectedTab;
            CategoryStatus currentCategory = (currentTab.Tag as CategoryStatus);
            this.lsvContainer.Items.Clear();
            this.facade.GetCurrentModules((ArtfFac.Category)(currentCategory.Category));
            if (!currentCategory.IsAlreadyLoaded) this.LoadModules(currentTab.Text);
            currentCategory.IsAlreadyLoaded = true;
            this.txtAddress.Text = currentTab.Text + this.formDto.Rule.ModuleSeperator;
        }

        private void InitializeTab()
        {
            this.tbpForm.Tag = new CategoryStatus
            {
                Category = ArtfFac.Category.Form,
                IsAlreadyLoaded = true,
            };
            this.tbpCatalogue.Tag = new CategoryStatus
            {
                Category = ArtfFac.Category.Catalogue,
            };
            this.tbpReport.Tag = new CategoryStatus
            {
                Category = ArtfFac.Category.Report,
            };
        }

        #endregion      

        private void LoadModules(String currentTab)
        {
            TreeView current = new TreeView();
            TreeNode[] tree = new TreeNode[this.formDto.Dto.Modules.Count];
            Int16 i = 0;
            foreach (ModFac.Dto module in this.formDto.Dto.Modules)
            {
                switch (currentTab)
                {
                    case "Form": current = this.trvForm;
                        break;
                    case "Catalogue": current = this.trvCatalogue;
                        break;
                    case "Report": current = this.trvReport;
                        break;
                    default: current = this.trvForm;
                        break;
                }
                tree[i] = this.trvForm.CreateTreeNodes(module.Artifact);
                tree[i++].Tag = module;
            }
            current.Nodes.Clear();
            current.Nodes.AddRange(tree);
        }

        private void SelectNode(String selectedNodePath)
        {
            TreeView trv = this.GetActiveTreeView();

            this.txtAddress.Text = selectedNodePath;
            if (String.IsNullOrEmpty(selectedNodePath))
            {
                //this.LoadForm();
                return;
            }
            this.currentArtifact = null;
            if (String.Compare(selectedNodePath, "Form:") == 0)
            {
                this.tbcCategory.SelectedTab = this.tbpForm;
                return;
            }
            if (String.Compare(selectedNodePath, "Catalogue:") == 0)
            {
                this.tbcCategory.SelectedTab = this.tbpCatalogue;
                return;
            }
            if (String.Compare(selectedNodePath, "Report:") == 0)
            {
                this.tbcCategory.SelectedTab = this.tbpReport;
                return;
            }

            if (!selectedNodePath.EndsWith("\\")) selectedNodePath += "\\";
            this.txtAddress.Text = selectedNodePath;
            selectedNodePath = selectedNodePath.Substring(selectedNodePath.IndexOf(this.formDto.Rule.ModuleSeperator) + 3);
            //TreeNode currentNode = this.FindTreeNodeFromPath(selectedNodePath, this.trvForm.Nodes);
            //TreeNode currentNode = trv.FindTreeNodeFromPath(selectedNodePath, trv.Nodes);
            TreeNode currentNode = trv.FindTreeNodeFromPath(trv.Nodes, selectedNodePath, this.formDto.Rule.PathSeperator);
            if (currentNode == null)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Navigator",
                }.Show(new List<BinAff.Core.Message> { { new BinAff.Core.Message("Path not found.", BinAff.Core.Message.Type.Error) } });
                //this.LoadForm();
            }
            else
            {
                //this.trvForm.SelectedNode = currentNode;
                trv.SelectedNode = currentNode;
                currentNode.Expand();
                this.currentArtifact = currentNode.Tag as ArtfFac.Dto;
                //this.trvArtifact_NodeMouseClick(this.trvForm, new TreeNodeMouseClickEventArgs(currentNode, MouseButtons.Left, 1, 0, 0));
                this.trvArtifact_NodeMouseClick(trv, new TreeNodeMouseClickEventArgs(currentNode, MouseButtons.Left, 1, 0, 0));
            }
        }

        private void SelectNode(ArtfFac.Dto dto)
        {
            TreeView trv = this.GetActiveTreeView();
            TreeNode currentNode = trv.FindNode(dto);
            if (currentNode == null)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Navigator",
                }.Show(new List<BinAff.Core.Message> { { new BinAff.Core.Message("Path not found.", BinAff.Core.Message.Type.Error) } });
            }
            else
            {
                trv.SelectedNode = currentNode;
                currentNode.Expand();
                this.currentArtifact = currentNode.Tag as ArtfFac.Dto;
                this.trvArtifact_NodeMouseClick(trv, new TreeNodeMouseClickEventArgs(currentNode, MouseButtons.Left, 1, 0, 0));
            }
        }

        private ArtfFac.Dto ReadDocument(ArtfFac.Dto selectedNode)
        {
            return new Facade.Register.Server(null).ReadDocument(selectedNode);
        }

        private ArtfFac.Dto GetParent(ArtfFac.Dto artifact)
        {
            return String.Compare(artifact.Parent.GetType().FullName, "Vanilla.Utility.Facade.Module.Dto") == 0 ?
                (artifact.Parent as ModFac.Dto).Artifact : artifact.Parent as ArtfFac.Dto;
        }

        private ArtfFac.Dto GetArtifact(Object aritfact)
        {
            return aritfact.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto" ?
                (aritfact as ModFac.Dto).Artifact : aritfact as ArtfFac.Dto;
        }

        private ArtfFac.Dto GetArtifact(FacLib.Dto aritfact)
        {
            return aritfact.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto" ?
                (aritfact as ModFac.Dto).Artifact : aritfact as ArtfFac.Dto;
        }

        private String GetArtifactName(TreeNode node, ArtfFac.Type type)
        {
            ArtfFac.Dto artifactDto = this.GetArtifact(node.Tag);

            String fileName = type == ArtfFac.Type.Document?
                "New " + this.tbcCategory.SelectedTab.Text : "New Folder";

            if (artifactDto.Children == null) return fileName;

            Boolean isExists = false;
            for (int i = 0; i <= artifactDto.Children.Count; i++)
            {
                isExists = false;
                if (i > 0)
                {
                    fileName += " (" + i + ")";
                }

                //Find duplicate name
                foreach (ArtfFac.Dto childArtifact in artifactDto.Children)
                {
                    if (String.Compare(childArtifact.FileName, fileName, true) == 0)
                    {
                        isExists = true;
                        break;
                    }
                }

                if (!isExists) break;
            }

            return fileName;
        }

        public void AddFolder()
        {
            String fileName = this.GetArtifactName(this.GetActiveTreeView().SelectedNode, ArtfFac.Type.Folder);
            this.AddArtifact(ArtfFac.Type.Folder, fileName, null, null);
        }

        public void AddDocument()
        {
            this.AddDocument(null);
        }

        private void AddDocument(String componentType)
        {
            TreeView trv = this.GetActiveTreeView();
            this.facade.SetCategory(this.tbcCategory.SelectedTab.Text);
            TreeNode selectedNode = trv.SelectedNode;

            if (selectedNode != null)
            {
                TreeNode rootNode = trv.FindRootNode();

                //Show Dialogue to capture module data
                FacLib.Dto component = new ModFac.Server(null)
                {
                    Category = this.facade.Category
                }.InstantiateDto(rootNode.Tag as ModFac.Dto);

                if (componentType != null)
                {
                    (rootNode.Tag as ModFac.Dto).ComponentFormType = componentType;
                }

                String fileName = this.GetArtifactName(selectedNode, ArtfFac.Type.Document);
                //component.artifactPath = this.currentArtifact.Path + fileName;
                component.fileName = fileName;
                component.trvForm = trv;

                this.AddArtifact(ArtfFac.Type.Document, fileName, component, new ModDefFac.Dto
                {
                    Code = (rootNode.Tag as ModFac.Dto).Code
                });
            }
        }

        private void SaveArtifact(ArtfFac.Dto artifactDto, String fileName, Boolean isModify)
        {
            TreeView trv = this.GetActiveTreeView();
            this.formDto.ModuleFormDto.CurrentArtifact = new ArtfFac.FormDto
            {
                Dto = artifactDto,
            };
            artifactDto.FileName = fileName;
            artifactDto.Category = this.facade.SetCategory(this.tbcCategory.SelectedTab.Text);
            artifactDto.Extension = this.facade.GetExtension(artifactDto.Category, artifactDto.Style);
            this.SetAuditInfoForNewRecord(artifactDto);

            artifactDto.Path = new ArtfFac.Server(null).GetParentArtifactPath(artifactDto) + artifactDto.FileName;
            if (artifactDto.Style == ArtfFac.Type.Folder) artifactDto.Path += this.formDto.Rule.PathSeperator;
            ////Set path
            //if (artifactDto.Style == ArtfFac.Type.Folder)
            //{
            //    if (artifactDto.Parent == null)
            //    {
            //        artifactDto.Path += this.formDto.Rule.ModuleSeperator + this.formDto.Rule.PathSeperator + this.formDto.Rule.PathSeperator;
            //    }
            //    artifactDto.Path += artifactDto.FileName + this.formDto.Rule.PathSeperator;
            //}
            //else if (artifactDto.Style == ArtfFac.Type.Document)
            //{
            //    //artifactDto.Path += artifactDto.FileName;
            //    artifactDto.Path = new ArtfFac.Server(null).GetParentArtifactPath(artifactDto) + artifactDto.FileName;
            //}

            //this.facade = new Facade.Register.Server(this.formDto) { Category = artifactDto.Category };

            TreeNode parentNode = null;
            if (artifactDto.Style == ArtfFac.Type.Document)
            {
                parentNode = trv.FindNode(this.currentArtifact.Style == ArtfFac.Type.Document ? new ArtfFac.Server(null).GetParentArtifact(this.currentArtifact) : this.currentArtifact);
            }
            else
            {
                TreeNode selectedNode = trv.FindNode(artifactDto);
                parentNode = selectedNode != null ? selectedNode.Parent : null;
            }
            //String pathOfParent = this.GetArtifact(parentNode.Tag).Path;


            //-- document should not contain the path separator
            //if (artifactDto.Style == ArtfFac.Type.Document)
            //{
            //    artifactDto.Path = pathOfParent + fileName;
            //}
            //else
            //{
            //    artifactDto.Path = pathOfParent + fileName + this.formDto.Rule.PathSeperator;
            //}

            if (isModify)
            {
                if (parentNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                {
                    if (artifactDto.Parent != null) artifactDto.Parent.Id = 0;
                }
                artifactDto.AuditInfo.Version++;
                artifactDto.AuditInfo.ModifiedAt = DateTime.Now;
                artifactDto.AuditInfo.ModifiedBy = new Table
                {
                    Id = (Server.Current.Cache["User"] as AccFac.Dto).Id,
                    Name = (Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                };
                this.facade.Change();
                if (this.formDto.ModuleFormDto.CurrentArtifact.Dto.Style == ArtfFac.Type.Document)
                {
                    if (this.facade.DisplayMessageList == null || this.facade.DisplayMessageList.Count == 0)
                    {
                        new PresLib.MessageBox
                        {
                            DialogueType = PresLib.MessageBox.Type.Information,
                            Heading = "Navigator",
                        }.Show("Document saved successfully.");
                    }
                    else
                    {
                        new PresLib.MessageBox
                        {
                            DialogueType = PresLib.MessageBox.Type.Information,
                            Heading = "Navigator",
                        }.Show(this.facade.DisplayMessageList);
                    }
                }
            }
            else //New record
            {
                this.facade.Add();
            }

            //this.currentArtifact = this.GetArtifact(parentNode.Tag);
            this.lsvContainer.AttachChildren(this.GetArtifact(parentNode.Tag), isDocumentFirst);
            if (this.facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Navigator",
                }.Show(this.facade.DisplayMessageList);
            }
        }

        private void AddArtifact(ArtfFac.Type type, String fileName, FacLib.Dto component, ModDefFac.Dto componentDef)
        {
            TreeView trv = this.GetActiveTreeView();
            TreeNode parentNode = ReadSelectedNode(trv);
            this.ParentFolder = this.GetArtifact(parentNode.Tag);

            if (parentNode != null)
            {
                TreeNode newNode = this.GetNewNode(this.ParentFolder, fileName, type, component, componentDef);

                this.formDto.ModuleFormDto.CurrentArtifact = new ArtfFac.FormDto
                {
                    Dto = newNode.Tag as ArtfFac.Dto,
                };

                this.UpdateParentArtifactWithChildArtifactAndAddChildPath(this.ParentFolder, this.formDto.ModuleFormDto.CurrentArtifact.Dto);
                if (type == ArtfFac.Type.Folder)
                {
                    parentNode.Nodes.Add(newNode);
                }

                this.lsvContainer.AttachChild(this.formDto.ModuleFormDto.CurrentArtifact.Dto);
            }
        }

        private TreeNode GetNewNode(ArtfFac.Dto parent, String fileName, ArtfFac.Type type, FacLib.Dto component, ModDefFac.Dto componentDef)
        {
            return new TreeNode
            {
                Text = fileName,
                Tag = new ArtfFac.Dto
                {
                    FileName = fileName,
                    Style = type,
                    AuditInfo = new ArtfFac.Audit.Dto
                    {
                        Version = 1,
                        CreatedBy = new Table
                        {
                            Id = (Server.Current.Cache["User"] as AccFac.Dto).Id,
                            Name = (Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                        },
                        CreatedAt = DateTime.Now,
                    },
                    Module = component,
                    ComponentDefinition = componentDef == null ? null : new ModDefFac.Dto { Code = componentDef.Code },
                    Parent = parent,
                }
            };
        }

        private void MakeNodeEditable(ArtfFac.Type type)
        {
            //TreeView trv = this.GetActiveTreeView();
            //if (this.DialogueMode == WinForm.DialogueMode.None)
            //{
            //    if (this.menuClickSource.ToString() == MenuClickSource.TreeView.ToString())
            //    {
            //        trv.LabelEdit = true;
            //        newNode.Parent.Expand();
            //        trv.SelectedNode = null;
            //        newNode.BeginEdit();
            //    }
            //    else
            //    {
            //        this.lsvContainer.LabelEdit = true;
            //        foreach (ListViewItem item in this.lsvContainer.Items)
            //        {
            //            ArtfFac.Dto dto = item.Tag as ArtfFac.Dto;
            //            if (dto.Style == type && dto.FileName == fileName)
            //            {
            //                //Remove extension for document
            //                if (dto.Style == ArtfFac.Type.Document) item.Text = item.Text.Remove(item.Text.LastIndexOf('.'));
            //                item.BeginEdit();
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Attach parent to new node  and instantiate path with parent path
        /// </summary>
        /// <param name="parent"></param>
        private void UpdateParentArtifactWithChildArtifactAndAddChildPath(FacLib.Dto parent, ArtfFac.Dto child)
        {
            ArtfFac.Dto parentDto;
            if (parent.GetType().ToString() == "Vanilla.Utility.Facade.Module.Dto") //Adding to module
            {
                parentDto = (parent as ModFac.Dto).Artifact;
            }
            else
            {
                parentDto = parent as ArtfFac.Dto;
                child.Parent = parent;
            }
            if (parentDto.Children == null) parentDto.Children = new List<ArtfFac.Dto>();
            parentDto.Children.Add(child);

            String pathOfParent = String.Empty;
            if (parentDto.Parent == null)
                pathOfParent += parentDto.Path + this.formDto.Rule.ModuleSeperator + this.formDto.Rule.PathSeperator + this.formDto.Rule.PathSeperator + parentDto.FileName + this.formDto.Rule.PathSeperator;
            else
                pathOfParent += parentDto.Path;

            child.Path += pathOfParent;
        }

        public void ChangeForFormChange(Document document)
        {
            ArtfFac.Dto parent = this.GetParent(document.Artifact);
            if (parent == null) return;
            TreeNode affectedParentFolder = this.trvForm.FindNode(parent);
            this.UpdateForDocumentChange(affectedParentFolder, document);
        }

        public void ChangeForReportChange(Document document)
        {
            TreeNode affectedParentFolder = this.trvReport.FindNode(this.GetParent(document.Artifact));
            this.UpdateForDocumentChange(affectedParentFolder, document);
        }

        private void UpdateForDocumentChange(TreeNode affectedParentFolder, Document document)
        {
            ArtfFac.Dto affectedArtifact = GetArtifact(affectedParentFolder.Tag).Children.FindLast((p) =>
            {
                return p.Id == document.Artifact.Id;
            });
            affectedArtifact.AuditInfo.Version = document.Artifact.AuditInfo.Version;
            affectedArtifact.AuditInfo.CreatedAt = document.Artifact.AuditInfo.CreatedAt;
            affectedArtifact.AuditInfo.CreatedBy = document.Artifact.AuditInfo.CreatedBy;
            affectedArtifact.AuditInfo.ModifiedAt = document.Artifact.AuditInfo.ModifiedAt;
            affectedArtifact.AuditInfo.ModifiedBy = document.Artifact.AuditInfo.ModifiedBy;

            if (this.trvForm.SelectedNode == affectedParentFolder)
            {
                ListViewItem affectedNode = this.lsvContainer.FindNode(document.Artifact);
                affectedNode.ChangeListViewSubItems(document.Artifact);
                //if (this.lsvContainer.SelectedItems[0] == affectedNode)
                if (this.lsvContainer.FocusedItem == affectedNode)
                {
                    this.ArtifactClicked();
                }
            }
        }

        private TreeNode ReadSelectedNode(TreeView trv)
        {
            TreeNode selectedNode = null;

            if ((this.menuClickSource == MenuClickSource.ListView))
            {
                selectedNode = this.currentArtifact == null || this.currentArtifact.Style == ArtfFac.Type.Document ? 
                    trv.SelectedNode : trv.FindNode(this.currentArtifact);
            }
            else if (this.menuClickSource == MenuClickSource.TreeView)
            {
                selectedNode = trv.SelectedNode;
            }

            return selectedNode;
        }

        private void PopulateCutCopyNode()
        {
            this.editNode = null;
            TreeNode node = null;

            if (this.menuClickSource == MenuClickSource.TreeView)
            {
                node = this.trvForm.SelectedNode;
            }
            else if (this.currentArtifact.Style == ArtfFac.Type.Folder)
            {
                node = this.trvForm.FindNode(this.currentArtifact);
            }
            else if (this.currentArtifact.Style == ArtfFac.Type.Document)
            {
                if (this.currentArtifact.Parent.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    node = this.trvForm.FindNode((this.currentArtifact.Parent as ModFac.Dto).Artifact);
                else
                    node = this.trvForm.FindNode(this.currentArtifact.Parent as ArtfFac.Dto);
            }

            if (node != null)
            {
                this.editNode = node;
            }
        }

        private Boolean CompareNode(TreeNode nodeOne, TreeNode nodeTwo)
        {
            //Int64 nodeOneArtifactId = 0;
            //Int64 nodeTwoArtifactId = 0;
            //if (nodeOne.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
            //    nodeOneArtifactId = (nodeOne.Tag as ModFac.Dto).Artifact.Id;
            //else
            //    nodeOneArtifactId = (nodeOne.Tag as ArtfFac.Dto).Id;
            //if (nodeTwo.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
            //    nodeTwoArtifactId = (nodeTwo.Tag as ModFac.Dto).Artifact.Id;
            //else
            //    nodeTwoArtifactId = (nodeTwo.Tag as ArtfFac.Dto).Id;

            //return nodeOneArtifactId == nodeTwoArtifactId;
            return this.GetArtifact(nodeOne.Tag).Id == this.GetArtifact(nodeTwo.Tag).Id;
        }

        private void tbpForm_Click(object sender, EventArgs e)
        {

        }

        private void tbpCatalogue_Click(object sender, EventArgs e)
        {

        }

        private void trvCatalogue_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tbpReport_Click(object sender, EventArgs e)
        {

        }

        private void Modification_Click(object sender, EventArgs e)
        {

        }

        private void mnuNewWindow_Click(object sender, EventArgs e)
        {

        }

        private void cmnuCatalog_Click(object sender, EventArgs e)
        {

        }

        private TreeView GetActiveTreeView()
        {
            TreeView trv = new TreeView();
            switch (this.tbcCategory.SelectedTab.Text)
            {
                case "Form":
                    trv = this.trvForm;
                    break;
                case "Catalogue":
                    trv = this.trvCatalogue;
                    break;
                case "Report":
                    trv = this.trvReport;
                    break;
                default:
                    break;
            }
            return trv;
        }

        private TreeNode GetRootNode()
        {
            TreeView trv = this.GetActiveTreeView();
            TreeNode selectedNode = null;
            TreeNode rootNode = null;

            if ((this.menuClickSource == MenuClickSource.ListView) && (this.currentArtifact != null))
                selectedNode = trv.FindNode(this.currentArtifact);
            else if (this.menuClickSource == MenuClickSource.TreeView)
                selectedNode = trv.SelectedNode;

            if (selectedNode != null)
                rootNode = trv.FindRootNode();

            return rootNode;
        }

        private void ucSearchResult_DoubleClick(object sender, EventArgs e)
        {
            this.currentArtifact = this.ucSearchResult.FormDto.CurrentArtifact;
            if (this.currentArtifact.Style == ArtfFac.Type.Document)
            {
                //Need to add parent
                //this.currentArtifact.Parent = this.GetParent(this.currentArtifact);
                switch (this.currentArtifact.Category)
                {
                    case ArtfFac.Category.Form:
                        this.FormLoad(this.currentArtifact);
                        break;
                    case ArtfFac.Category.Report:
                        this.ReportLoad(this.currentArtifact);
                        break;
                }
            }
            else
            {
                this.ucSearchResult.Hide();
                this.pnlArtifact.Show();
                this.SelectNode(this.currentArtifact.Path);
            }
        }

        #region Drag-Drop

        private void lsvContainer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.currentArtifact.Style == ArtfFac.Type.Document)
            {
                this.lsvContainer.DoDragDrop(this.lsvContainer.FocusedItem, DragDropEffects.Move);
            }
            else
            {
                this.lsvContainer.DoDragDrop(this.lsvContainer.FocusedItem, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void lsvContainer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = this.DragEnterToControl();
        }

        private void lsvContainer_DragDrop(object sender, DragEventArgs e)
        {
            ListView current = sender as ListView;
            ListViewItem Item = current.HitTest(current.PointToClient(new Point(e.X, e.Y))).Item;
            if (Item != null)
            {
                this.Drop(Item.Tag as ArtfFac.Dto, new Point(e.X, e.Y));
            }
        }

        private void tsmDragDropCopy_Click(object sender, EventArgs e)
        {
            this.Copy();
            this.currentArtifact = this.cmsDragDrop.Tag as ArtfFac.Dto;
            this.Paste();
        }

        private void tsmDragDropMove_Click(object sender, EventArgs e)
        {
            this.Cut();
            this.currentArtifact = this.cmsDragDrop.Tag as ArtfFac.Dto;
            this.Paste();
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            if (this.currentArtifact.Style == ArtfFac.Type.Document)
            {
                treeView.DoDragDrop(treeView.SelectedNode, DragDropEffects.Move);
            }
            else
            {
                treeView.DoDragDrop(treeView.SelectedNode, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = this.DragEnterToControl();
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode item = e.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
            if (item == null)
            {
                ListViewItem artf = e.Data.GetData("System.Windows.Forms.ListViewItem") as ListViewItem;
                if (artf != null)
                {
                    this.currentArtifact = artf.Tag as ArtfFac.Dto;
                }
            }
            else
            {
                this.currentArtifact = item.Tag as ArtfFac.Dto;
            }

            TreeView currentTreeView = sender as TreeView;
            TreeNode dropOver = currentTreeView.HitTest(currentTreeView.PointToClient(new Point(e.X, e.Y))).Node;
            if (dropOver != null)
            {
                this.Drop(this.GetArtifact(dropOver.Tag), new Point(e.X, e.Y));
            }
        }

        private DragDropEffects DragEnterToControl()
        {
            if (this.currentArtifact.Style == ArtfFac.Type.Document)
            {
                return DragDropEffects.Move;
            }
            else
            {
                return DragDropEffects.Copy | DragDropEffects.Move;
            }
        }

        private void Drop(ArtfFac.Dto dropOver, Point location)
        {
            if (dropOver.Style == ArtfFac.Type.Document)
            {
                return;
            }
            else
            {
                if (this.currentArtifact.Style == ArtfFac.Type.Document)
                {
                    this.Cut();
                    this.currentArtifact = dropOver;
                    this.Paste();
                }
                else
                {
                    this.cmsDragDrop.Tag = dropOver; //Attaching the target artifact
                    this.cmsDragDrop.Show(location);
                }
            }
        }

        #endregion

        private class CategoryStatus
        {
            internal ArtfFac.Category Category { get; set; }
            internal Boolean IsAlreadyLoaded { get; set; }
        }

    }

    public enum MenuClickSource
    {
        TreeView = 1,
        ListView = 2,
        MenuBar = 3
    }

    public enum DialogueMode
    {
        None = 0,
        Open = 1,
        New = 2,
        Save = 3,
    }

}