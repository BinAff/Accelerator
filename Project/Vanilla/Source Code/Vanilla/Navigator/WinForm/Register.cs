using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Facade.Cache;
using PresLib = BinAff.Presentation.Library;
using UtilFac = Vanilla.Utility.Facade;
using Vanilla.Utility.WinForm.Extender;

namespace Vanilla.Navigator.WinForm
{

    public partial class Register : UserControl
    {
        
        private Facade.Register.FormDto formDto;
        private Facade.Register.Server facade;
        
        private PresLib.ListViewColumnSorter lvwColumnSorter;

        private TreeNode editNode;
        private String sortColumn;
        private SortOrder sortOrder;
        private Boolean isCutAction;
        private Boolean isDocumentFirst;       

        private UtilFac.Artifact.Dto currentArtifact;
        private MenuClickSource menuClickSource;

        private UtilFac.Artifact.Dto cutArtifact;

        List<String> addressList; //This is for back button. This will hold all navigations

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

        public delegate void ChangePath();
        public event ChangePath PathChanged;

        public List<Table> reportCategory = new List<Table>();
        
        public Register()
        {
            InitializeComponent();
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
            this.lvwColumnSorter = new PresLib.ListViewColumnSorter();
            this.sortColumn = this.lsvContainer.Initialize();
            this.InitializeTab();
            this.RemoveAuditInfo();
            this.facade = new Facade.Register.Server(this.formDto = new Facade.Register.FormDto
            {
                ModuleFormDto = new UtilFac.Module.FormDto
                {
                    Dto = new UtilFac.Module.Dto()
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

            //populate reportCategory -- need to code later            
            reportCategory.Add(new Table { Id = 10001, Name = "drpt"});
            reportCategory.Add(new Table { Id = 10002, Name = "wrpt" });
            reportCategory.Add(new Table { Id = 10003, Name = "mrpt" });
            reportCategory.Add(new Table { Id = 10004, Name = "qrpt" });
            reportCategory.Add(new Table { Id = 10005, Name = "yrpt" });
            //--------------
            this.loadPercentage = 100;
        }

        public Int16 GetStatus()
        {
            return (Int16)Math.Abs(this.loadPercentage * 0.8);
        }

        void t_Tick(object sender, EventArgs e)
        {
            this.loadPercentage = this.facade.GetStatus();
        }

        private void LoadModules(String currentTab)
        {
            TreeView current = new TreeView();
            TreeNode[] tree = new TreeNode[this.formDto.Dto.Modules.Count];
            Int16 i = 0;
            foreach (UtilFac.Module.Dto module in this.formDto.Dto.Modules)
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
                //tree[i] = this.CreateTreeNodes(module.Artifact);
                tree[i] = this.trvForm.CreateTreeNodes(module.Artifact);
                

                tree[i++].Tag = module;
            }
            current.Nodes.Clear();
            current.Nodes.AddRange(tree);

        }       

        #region TreeView

        #region Events

        private void trvArtifact_MouseDown(object sender, MouseEventArgs e)
        {
            // Select the clicked node
            TreeView current = sender as TreeView;
            current.SelectedNode = current.GetNodeAt(e.X, e.Y);
            current.Sort(current.SelectedNode);

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

            UtilFac.Artifact.Dto artifactDto = e.Node.Tag as UtilFac.Artifact.Dto;
            String artifactFileName = String.Empty;

            if (e.Label != null && e.Label.Trim().Length == 0)
                e.CancelEdit = true; // Can not be empty text            
            else if ((e.Node.Tag as UtilFac.Artifact.Dto).Id > 0 && e.Label == null) //no text inserted during edit            
                e.CancelEdit = true; // Can not be empty text            
            else if ((e.Node.Tag as UtilFac.Artifact.Dto).Id > 0 && e.Label.Trim() == e.Node.Text.Trim()) //same text inserted during edit            
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
            UtilFac.Artifact.Dto selectedNode = this.GetArtifact((sender as TreeView).SelectedNode.Tag);
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
            this.formDto.ModuleFormDto.Dto = (sender as TreeView).FindRootNode().Tag as UtilFac.Module.Dto;
            this.ShowAuditInfo(selectedNode);
        }

        private void trvReport_MouseDown(object sender, MouseEventArgs e)
        {
            // Select the clicked node
            TreeView current = sender as TreeView;
            current.SelectedNode = current.GetNodeAt(e.X, e.Y);

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
            UtilFac.Artifact.Dto selectedNode = this.GetArtifact((sender as TreeView).SelectedNode.Tag);
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
            //this.formDto1.ModuleFormDto.Dto = this.FindRootNode((sender as TreeView).SelectedNode).Tag as UtilFac.Module.Dto;
            this.formDto.ModuleFormDto.Dto = (sender as TreeView).FindRootNode().Tag as UtilFac.Module.Dto;
            this.ShowAuditInfo(selectedNode);
        }


        private List<Table> AttachExtension()
        {
            List<Table> extension = new List<Table>();
            UtilFac.Artifact.Dto selectedNode = this.currentArtifact;
            if (selectedNode.Children != null && selectedNode.Children.Count > 0)
            {
                foreach (UtilFac.Artifact.Dto artifact in selectedNode.Children)
                {                   
                    if (artifact.Style == UtilFac.Artifact.Type.Document)
                    {
                        if (artifact.Module != null && artifact.Module.GetType().FullName == "Vanilla.Invoice.Facade.Report.Dto")
                        {
                            Vanilla.Invoice.Facade.Report.Dto reportDto = artifact.Module as Vanilla.Invoice.Facade.Report.Dto;
                            Int64 reportCategoryId = reportDto.category == null ? 0 : reportDto.category.Id;
                            if (reportCategoryId > 0)
                            {
                                foreach (Table tbl in this.reportCategory)
                                {
                                    if (tbl.Id == reportCategoryId)
                                    {
                                        extension.Add(new Table
                                        {
                                            Id = artifact.Id,
                                            Name = tbl.Name
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return extension;
        }

        #endregion

        private void PopulateNewArtifact(String fileName, UtilFac.Artifact.Type type, UtilFac.Artifact.Dto currentArtifact)
        {
            currentArtifact.FileName = fileName;

            //below properties are required only during insert
            if (currentArtifact.Id == 0)
            {
                currentArtifact.Style = type;
                currentArtifact.Version = 1;
                currentArtifact.CreatedBy = new Table
                {
                    Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                    Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
                };
                currentArtifact.CreatedAt = DateTime.Now;
                switch (this.tbcCategory.SelectedTab.Text)
                {
                    case "Form":
                        currentArtifact.Category = UtilFac.Artifact.Category.Form;
                        break;
                    case "Catalogue":
                        currentArtifact.Category = UtilFac.Artifact.Category.Catalogue;
                        break;
                    case "Report":
                        currentArtifact.Category = UtilFac.Artifact.Category.Report;
                        break;
                    default:
                        currentArtifact.Category = UtilFac.Artifact.Category.Form;
                        break;
                }
                if (type == UtilFac.Artifact.Type.Folder)
                {
                    currentArtifact.Path += currentArtifact.FileName + this.formDto.Rule.PathSeperator;
                }
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
            UtilFac.Artifact.Dto parentArtifactDto = this.GetArtifact(parentNode.Tag);
            foreach (UtilFac.Artifact.Dto child in parentArtifactDto.Children)
            {
                if (child.Id == (childNode.Tag as UtilFac.Artifact.Dto).Id)
                {
                    parentArtifactDto.Children.Remove(child);
                    break;
                }
            }
        }

        private void RemoveChildDtoFromParentDto(UtilFac.Artifact.Dto parentArtifactDto, UtilFac.Artifact.Dto childArtifactDto)
        {
            foreach (UtilFac.Artifact.Dto child in parentArtifactDto.Children)
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
            UtilFac.Artifact.Dto parentArtifact = this.GetArtifact(parentNode.Tag);
            if (parentArtifact.Children == null)
            {
                parentArtifact.Children = new List<UtilFac.Artifact.Dto>();
            }

            parentArtifact.Children.Add(childNode.Tag as UtilFac.Artifact.Dto);
        }

        private void AddChildDtoToParentDto(UtilFac.Artifact.Dto parentArtifactDto, UtilFac.Artifact.Dto childArtifactDto)
        {
            if (parentArtifactDto.Children == null)
            {
                parentArtifactDto.Children = new List<UtilFac.Artifact.Dto>();
            }

            parentArtifactDto.Children.Add(childArtifactDto);          
            childArtifactDto.Parent =  parentArtifactDto;
        }
        
        private void AttachTagToChildNodes(TreeNode node)
        {
            UtilFac.Artifact.Dto artifactDto = node.Tag as UtilFac.Artifact.Dto;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Tag = artifactDto.Children[i] as UtilFac.Artifact.Dto;
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

        #endregion

        #region ListView

        #region Events

        private void lsvContainer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = true;
            (sender as ListView).LabelEdit = false;
            TreeView trv = this.GetActiveTreeView();

            ListViewItem selectedItem = (sender as ListView).FocusedItem;
            UtilFac.Artifact.Dto selectedArtifact = selectedItem.Tag as UtilFac.Artifact.Dto;
            selectedArtifact.Extension = this.currentArtifact.Extension;

            String documentName = selectedArtifact.FileName + "." + selectedArtifact.Extension;          
            String defaultFileName = selectedArtifact.FileName;
            String artifactFileName = String.Empty;

            //if the selected item text is empty then no operations will be done
            if (e.Label == null || e.Label.Trim().Length == 0)
            {
                //e.CancelEdit = true;

                if (selectedArtifact.Id == 0)
                {
                    artifactFileName = selectedArtifact.FileName;
                }
                else
                {
                    if (selectedArtifact.Style == UtilFac.Artifact.Type.Document)
                    {
                        selectedItem.Text = documentName;
                    }
                    return;
                }
            }

            if (artifactFileName == String.Empty)
            {
                artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? selectedItem.Text.Trim() : e.Label.Trim();
            }
           

            //loop through the list to check for duplicate
            foreach (ListViewItem item in this.lsvContainer.Items)
            {
                UtilFac.Artifact.Dto artifactDto = item.Tag as UtilFac.Artifact.Dto;
                if ((artifactDto.Id != selectedArtifact.Id) && (artifactDto.Style == selectedArtifact.Style))
                {
                    if (String.Compare(artifactDto.FileName.Trim(), artifactFileName.Trim(), true) == 0)
                    {
                        new PresLib.MessageBox
                        {
                            DialogueType = PresLib.MessageBox.Type.Information,
                            Heading = "Navigator",
                        }.Show("Name already exists. Please assign a different name.");

                        //e.CancelEdit = true;

                        if (selectedArtifact.Id != 0)
                        {
                            if (selectedArtifact.Category == UtilFac.Artifact.Category.Report && selectedArtifact.Style == UtilFac.Artifact.Type.Document)
                                selectedItem.Text = documentName;

                            return;
                        }
                        else
                            artifactFileName = selectedArtifact.FileName;
                    }
                }
            }
            
            TreeNode selectedNode = trv.FindNode(selectedArtifact.Style == UtilFac.Artifact.Type.Document ?
                this.currentArtifact :
                selectedArtifact);
         

            //Update TreeNode Text
            if ((selectedArtifact.Style == UtilFac.Artifact.Type.Folder) && (defaultFileName != artifactFileName))
            {
                selectedNode.Text = artifactFileName;
                (selectedNode.Tag as UtilFac.Artifact.Dto).FileName = artifactFileName;
            }

            //e.CancelEdit = true;
            this.SaveArtifact(selectedArtifact, artifactFileName, selectedArtifact.Id != 0);
                        
            //code added to fix issue
            //issue description : if any document is created on root and then double click immediately to open the form in edit mode , was giving error
            //if this block is moved up before save, then a foreign key error will be thrown
            if (selectedArtifact.Style == UtilFac.Artifact.Type.Document)
            {
                if ((selectedNode.Tag.GetType().ToString() == "Vanilla.Utility.Facade.Module.Dto") && (selectedArtifact.Parent == null))
                {
                    (selectedItem.Tag as UtilFac.Artifact.Dto).Parent = selectedNode.Tag as UtilFac.Module.Dto;
                }
            }
          
        }

        private void lsvContainer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ShowHideContextMenuItems(this.lsvContainer.GetItemAt(e.X, e.Y));
                this.cmsExplorer.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (this.lsvContainer.GetItemAt(e.X, e.Y) != null) //Clicked on one item
                {
                    this.ShowAuditInfo(this.lsvContainer.GetItemAt(e.X, e.Y).Tag as UtilFac.Artifact.Dto);
                    if (this.lsvContainer.GetItemAt(e.X, e.Y) == this.lsvContainer.FocusedItem)
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
                this.lsvContainer.EditListViewSelectedItem();
                //String artifactFileName = String.Empty;
                //foreach (ListViewItem item in lsvContainer.SelectedItems)
                //{                    
                //    UtilFac.Artifact.Dto dto = item.Tag as UtilFac.Artifact.Dto;
                //    if (dto.Category == UtilFac.Artifact.Category.Report && dto.Style == UtilFac.Artifact.Type.Document)                    
                //        artifactFileName = dto.FileName;
                //}

                //if (artifactFileName == String.Empty)
                //    this.lsvContainer.EditListViewSelectedItem();
                //else
                //    this.lsvContainer.EditListViewSelectedItem(artifactFileName);
            }
            else
            {
                this.ShowAuditInfo(this.lsvContainer.FocusedItem.Tag as UtilFac.Artifact.Dto);
            }
        }

        private void lsvContainer_DoubleClick(object sender, EventArgs e)
        {
            TreeView trv = this.GetActiveTreeView();

            this.currentArtifact = ((sender as ListView).SelectedItems[0].Tag as UtilFac.Artifact.Dto);
            if (currentArtifact.Style == UtilFac.Artifact.Type.Folder)
            {
                this.lsvContainer.AttachChildren(this.currentArtifact,isDocumentFirst);
                //this.SelectNode(this.currentArtifact.Path);
                this.SelectNode(this.currentArtifact);
                this.txtAddress.Text = this.currentArtifact.Path;
                this.addressList.Add(this.currentArtifact.Path);

                this.btnUp.Enabled = true;
            }
            else
            {
                UtilFac.Artifact.Dto artifactDto = this.GetParent(this.currentArtifact);
                TreeNode parentNode = null;                
                parentNode = trv.FindNode(artifactDto);
                TreeNode rootNode = trv.FindRootNode(parentNode);

                BinAff.Facade.Library.Dto parent = this.currentArtifact.Parent;
                this.currentArtifact = this.ReadDocument(this.currentArtifact);
                this.currentArtifact.Parent = parent;
                Type type;
                if(this.currentArtifact.Category == UtilFac.Artifact.Category.Report)                
                {
                    type = this.GetInvoiceType(this.currentArtifact);
                }
                else
                {
                    type = Type.GetType((rootNode.Tag as UtilFac.Module.Dto).ComponentFormType, true);
                }

                this.currentArtifact.Module.artifactPath = currentArtifact.Path;                
                PresLib.Form form = (PresLib.Form)Activator.CreateInstance(type, currentArtifact.Module);

                form.ShowDialog(this);
                if (form.IsModified)
                {
                    this.SaveArtifact(this.currentArtifact, this.currentArtifact.FileName, true);
                }
            }
        }

        private void lsvContainer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.lsvContainer.Items.Count > 0)
                isDocumentFirst = ((this.lsvContainer.Items[0].Tag as UtilFac.Artifact.Dto).Style == UtilFac.Artifact.Type.Document) ? false : true;

            this.lsvContainer.ResetColumnHeader();
            this.sortColumn = this.lsvContainer.Columns[e.Column].Text;

            //Determine if clicked column is already the column that is being sorted.   
            if (e.Column == this.lvwColumnSorter.SortColumn)
            {
                if (this.lvwColumnSorter.Order == SortOrder.Ascending || this.lvwColumnSorter.Order == SortOrder.None)
                {
                    this.lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    this.lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                this.lvwColumnSorter.SortColumn = e.Column;
                this.lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.lsvContainer.Sort(this.sortColumn, this.lvwColumnSorter, isDocumentFirst);
        }

        #endregion

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
                    return ((listViewItem == null) || (listViewItem.Tag as UtilFac.Artifact.Dto).Style == UtilFac.Artifact.Type.Folder);
                case "newToolStripMenuItem":
                    return listViewItem == null;
                case "cmnuDelete":
                    return listViewItem != null;
                case "cmnuRename":
                    return listViewItem != null;
                case "cmnuCut":
                    return listViewItem != null;
                case "cmnuCopy":
                    return ((listViewItem != null) && ((listViewItem.Tag as UtilFac.Artifact.Dto).Style == UtilFac.Artifact.Type.Folder));
                case "cmnuPaste":
                    {
                        Boolean blnPaste = ((listViewItem != null) && (this.editNode != null) && ((listViewItem.Tag as UtilFac.Artifact.Dto).Style == UtilFac.Artifact.Type.Folder));

                        //// cut document
                        //if (!blnPaste)
                        //{
                        //    if (isCutAction == true && this.cutArtifact != null)
                        //        blnPaste = true;
                        //}

                        return blnPaste;
                    }
                    //return ((listViewItem != null) && (this.editNode != null) && ((listViewItem.Tag as UtilFac.Artifact.Dto).Style == UtilFac.Artifact.Type.Folder));
                case "cmnuSeparator1":
                    return true;
                case "cmnuSeparator2":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Attach parent to new node  and instantiate path with parent path
        /// </summary>
        /// <param name="parent"></param>
        private void AttachNodes(BinAff.Facade.Library.Dto parent, UtilFac.Artifact.Dto child)
        {
            UtilFac.Artifact.Dto parentDto;
            if (parent.GetType().ToString() == "Vanilla.Utility.Facade.Module.Dto") //Adding to module
            {
                parentDto = (parent as UtilFac.Module.Dto).Artifact;
            }
            else
            {
                parentDto = parent as UtilFac.Artifact.Dto;
                child.Parent = parent;
            }
            if (parentDto.Children == null) parentDto.Children = new List<UtilFac.Artifact.Dto>();
            parentDto.Children.Add(child);
            child.Path = parentDto.Path;
        }
        
        #endregion

        #region Address Bar

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.pnlArtifact.Panel2.Controls.Add(this.ucSearchResult);
                this.ucSearchResult.Show();
                this.lsvContainer.Hide();
                this.ucSearchResult.LoadResult(this.txtSearch.Text.Trim());
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

        private TreeNode FindTreeNodeFromPath(String path, TreeNodeCollection treeNodes)
        {
            String text = path.Substring(0, path.IndexOfAny(this.formDto.Rule.PathSeperator.ToCharArray()));
            path = path.Substring(path.IndexOfAny(this.formDto.Rule.PathSeperator.ToCharArray()) + 1);
            foreach (TreeNode node in treeNodes)
            {
                if (node.Text == text)
                {
                    if (String.IsNullOrEmpty(path))
                    {
                        return node;
                    }
                    else if (node.Nodes.Count > 0)
                    {
                        return this.FindTreeNodeFromPath(path, node.Nodes);
                    }
                }
            }
            return null;
        }

        #endregion

        #region Audit

        private void ShowAuditInfo(UtilFac.Artifact.Dto selectedNode)
        {
            if (selectedNode != null)
            {
                this.lblFileName.Text = selectedNode.FileName;
                if (selectedNode.Version > 0)
                {
                    this.lblType.Text = selectedNode.Style.ToString();
                    this.lblVersion.Text = selectedNode.Version.ToString();
                }
                else
                {
                    this.lblType.Text = "Addon";
                }

                if (selectedNode.CreatedBy == null)
                {
                    this.lblCreatedBy.Text = String.Empty;
                    this.lblCreatedAt.Text = String.Empty;
                }
                else
                {
                    this.lblCreatedBy.Text = selectedNode.CreatedBy.Name;
                    this.lblCreatedAt.Text = selectedNode.CreatedAt.ToShortDateString();
                }

                if (selectedNode.ModifiedBy == null)
                {
                    this.lblModifiedBy.Text = String.Empty;
                    this.lblModifiedAt.Text = String.Empty;
                }
                else
                {
                    this.lblModifiedBy.Text = selectedNode.ModifiedBy.Name;
                    this.lblModifiedAt.Text = ((DateTime)selectedNode.ModifiedAt).ToShortDateString();
                }
            }
        }

        private void RemoveAuditInfo()
        {
            this.lblFileName.Text = String.Empty;
            this.lblType.Text = String.Empty;
            this.lblVersion.Text = String.Empty;
            this.lblCreatedBy.Text = String.Empty;
            this.lblCreatedAt.Text = String.Empty;
            this.lblModifiedBy.Text = String.Empty;
            this.lblModifiedAt.Text = String.Empty;
        }

        #endregion

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
                    if ((this.sortColumn == sortItems[i].Text) || (this.lvwColumnSorter.Order.ToString() == sortItems[i].Text))
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
            if (this.menuClickSource.ToString() == MenuClickSource.ListView.ToString())
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

            TreeNode pasteNode = (this.menuClickSource == MenuClickSource.TreeView) ?
                this.trvForm.SelectedNode :
                this.trvForm.FindNode(this.currentArtifact.Style == UtilFac.Artifact.Type.Document ?
                    this.currentArtifact.Parent as UtilFac.Artifact.Dto :
                    this.currentArtifact);

            Int64 newParentId = 0;
            Vanilla.Utility.Facade.Artifact.Dto artifactDto;

            if (pasteNode.Parent != null)
                newParentId = (pasteNode.Tag as Vanilla.Utility.Facade.Artifact.Dto).Id;

            BinAff.Facade.Library.Dto parent = new BinAff.Facade.Library.Dto { Id = newParentId };

            Table currentLoggedInUser = new Table
            {
                Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
            };

            String path = String.Empty;
            if (pasteNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                path = (pasteNode.Tag as Vanilla.Utility.Facade.Module.Dto).Artifact.Path;
            else
                path = (pasteNode.Tag as Vanilla.Utility.Facade.Artifact.Dto).Path;

            if(pasteNode.Parent == null)
                path += ":" + this.formDto.Rule.PathSeperator + this.formDto.Rule.PathSeperator + pasteNode.Text + this.formDto.Rule.PathSeperator;

            //Boolean pasteDirectory = this.cutArtifact == null ? true : false;
            Boolean pasteDirectory = this.cutArtifact.Style == UtilFac.Artifact.Type.Folder ? true : false;


            if (this.isCutAction)
            {
                if (pasteDirectory)
                    artifactDto = new Facade.Container.Server(null).GetArtifactDtoByValue(this.editNode.Tag as Vanilla.Utility.Facade.Artifact.Dto);
                else
                    artifactDto = new Facade.Container.Server(null).GetArtifactDtoByValue(this.cutArtifact);

                artifactDto.Version = artifactDto.Version + 1;
                artifactDto.ModifiedAt = DateTime.Now;
                artifactDto.ModifiedBy = currentLoggedInUser;
            }
            else
            {
                artifactDto = new Facade.Container.Server(null).GetArtifactDtoByValueForCopy(editNode.Tag as Vanilla.Utility.Facade.Artifact.Dto);
                artifactDto.CreatedAt = DateTime.Now;
                artifactDto.CreatedBy = currentLoggedInUser;
            }

            artifactDto.Parent = parent;

            if (pasteDirectory)
                artifactDto.Path = path + artifactDto.FileName + this.formDto.Rule.PathSeperator;
            else
                artifactDto.Path = path + artifactDto.FileName;

            this.formDto.ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto
            {
                Dto = artifactDto,
            };

            this.facade = new Facade.Register.Server(this.formDto) { Category = this.GetActiveCategory() };
            this.facade.Paste(this.isCutAction);

            if (!this.facade.IsError)
            {
                //this.cutArtifact = this.cutArtifact == null ? null : this.formDto.ModuleFormDto.CurrentArtifact.Dto;
                this.RefreshTreeViewAfterPaste();
                this.editNode = null;
                this.cutArtifact = null;
            }
        }

        private Boolean ValidatePaste()
        {

            TreeNode pasteNode = (this.menuClickSource == MenuClickSource.TreeView) ?
               this.trvForm.SelectedNode :
               this.trvForm.FindNode(this.currentArtifact.Style == UtilFac.Artifact.Type.Document ?
                   this.currentArtifact.Parent as UtilFac.Artifact.Dto :
                   this.currentArtifact);

            Boolean pasteDirectory = this.cutArtifact == null ? true : false;
            UtilFac.Artifact.Dto editArtifactDto = new UtilFac.Artifact.Dto();
            if (!pasteDirectory) // not null when pasting a document
            {
                if (this.cutArtifact.Parent.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    editArtifactDto = (this.cutArtifact.Parent as Vanilla.Utility.Facade.Module.Dto).Artifact;
                else
                    editArtifactDto = this.cutArtifact.Parent as UtilFac.Artifact.Dto;
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
                UtilFac.Artifact.Dto artifactDestination = new UtilFac.Artifact.Dto();
                if (pasteNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    artifactDestination = (pasteNode.Tag as Vanilla.Utility.Facade.Module.Dto).Artifact;
                else
                    artifactDestination = pasteNode.Tag as UtilFac.Artifact.Dto;

                if (artifactDestination.Children != null)
                {
                    foreach (UtilFac.Artifact.Dto artifactDto in artifactDestination.Children)
                    {
                        if (artifactDto.Style == UtilFac.Artifact.Type.Document)
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

        private void RefreshTreeViewAfterPaste()
        {
            Boolean pasteDirectory = this.cutArtifact == null ? true : false;

            TreeView trv = GetActiveTreeView();
            TreeNode childNode = this.cutArtifact == null ? null : trv.FindNode(this.cutArtifact);

            UtilFac.Artifact.Dto editArtifactDto = new UtilFac.Artifact.Dto();
            if (!pasteDirectory) // not null when pasting a document
            {
                if (this.cutArtifact.Parent.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    editArtifactDto = (this.cutArtifact.Parent as Vanilla.Utility.Facade.Module.Dto).Artifact;
                else
                    editArtifactDto = this.cutArtifact.Parent as UtilFac.Artifact.Dto;
            }

            TreeNode selectedNode; //this node will be the focussed node
            TreeNode actorNode;

            TreeNode pasteNode = (this.menuClickSource == MenuClickSource.TreeView) ?
               this.trvForm.SelectedNode :
               this.trvForm.FindNode(this.currentArtifact.Style == UtilFac.Artifact.Type.Document ?
                   this.currentArtifact.Parent as UtilFac.Artifact.Dto :
                   this.currentArtifact);

            UtilFac.Artifact.Dto parentArtifact = new UtilFac.Artifact.Dto();
            if (this.cutArtifact.Parent.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                parentArtifact = (this.cutArtifact.Parent as Vanilla.Utility.Facade.Module.Dto).Artifact;
            else
                parentArtifact = this.cutArtifact.Parent as UtilFac.Artifact.Dto;

            if (this.isCutAction)
            {
                actorNode = pasteDirectory ? this.editNode : this.trvForm.FindNode(editArtifactDto);
                selectedNode = actorNode.Parent;

                if (pasteDirectory)
                {
                    //remove child dto from tag
                    this.RemoveChildDtoFromParentDto(actorNode.Parent, actorNode);

                    //remove node from tree
                    this.trvForm.Nodes.Remove(actorNode);
                }
                else
                {
                    //remove child dto from tag
                    this.RemoveChildDtoFromParentDto(parentArtifact, this.cutArtifact);

                    //remove child node from parent node                    
                    TreeNode parentNode = trv.FindNode(parentArtifact);                    
                    parentNode.Nodes.Remove(childNode);
                }
            }
            else
            {
                actorNode = this.editNode.Clone() as TreeNode;
                selectedNode = this.trvForm.FindRootNode(pasteNode as TreeNode);
            }


            if (pasteDirectory)
            {
                (pasteNode as TreeNode).Nodes.Add(actorNode);
                actorNode.Tag = this.formDto.ModuleFormDto.CurrentArtifact.Dto;
                this.AddChildDtoToParentDto(pasteNode, actorNode);
                this.AttachTagToChildNodes(actorNode);
            }
            else
            {
                UtilFac.Artifact.Dto pasteArtifact = new UtilFac.Artifact.Dto();
                if (pasteNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    pasteArtifact = (pasteNode.Tag as Vanilla.Utility.Facade.Module.Dto).Artifact;
                else
                    pasteArtifact = pasteNode.Tag as UtilFac.Artifact.Dto;

                //this.AddChildDtoToParentDto(pasteArtifact, this.cutArtifact);
                this.AddChildDtoToParentDto(pasteArtifact, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

                //add child node from parent node                
                TreeNode parentNode = trv.FindNode(pasteArtifact);                
                parentNode.Nodes.Add(childNode);
                trv.Sort(parentNode);
            }
                        
            this.lsvContainer.AttachChildren(this.currentArtifact, isDocumentFirst);
        }
        
        public void Delete()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Folder/Document?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TreeNode node = null;
                TreeNode selectedNode = null;

                if (this.currentArtifact.Style == UtilFac.Artifact.Type.Document)
                {
                    //node = this.FindTreeNodeFromTag(this.currentArtifact.Parent as UtilFac.Artifact.Dto, this.trvForm.Nodes, node);
                    node = this.trvForm.FindNode(this.GetParent(this.currentArtifact));
                }
                else
                {
                    //selectedNode = this.FindTreeNodeFromTag(this.currentArtifact, this.trvForm.Nodes, node);
                    selectedNode = this.trvForm.FindNode(this.currentArtifact);
                    node = selectedNode.Parent;
                }

                if ((this.menuClickSource == MenuClickSource.ListView) && (this.currentArtifact.Style == UtilFac.Artifact.Type.Document))
                {
                    this.DeleteDocument(this.currentArtifact);
                }
                else
                {
                    Boolean retVal = true;
                    this.DeleteFolder(this.currentArtifact, retVal);
                }
                this.currentArtifact = this.GetArtifact(node.Tag);

                this.lsvContainer.AttachChildren(this.currentArtifact,isDocumentFirst);

                if (selectedNode != null)
                {
                    this.trvForm.SelectedNode = selectedNode.Parent;
                    this.trvForm.Nodes.Remove(selectedNode);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private Boolean DeleteDocument(UtilFac.Artifact.Dto artifact)
        {
            Boolean retVal = true;
            TreeNode parentNode = this.trvForm.FindNode(this.GetParent(artifact));

            if (parentNode != null)
            {
                retVal = this.DeleteItem(artifact, parentNode);
            }

            return retVal;
        }

        private void DeleteFolder(UtilFac.Artifact.Dto artifact, Boolean retVal)
        {
            if (!retVal)
                return;

            //Delete the children
            if (artifact.Children != null)
            {
                while (artifact.Children.Count > 0)
                {
                    if (artifact.Children[0].Style == UtilFac.Artifact.Type.Folder)
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

        private Boolean DeleteItem(UtilFac.Artifact.Dto artifact, TreeNode parentNode)
        {
            this.formDto.ModuleFormDto.CurrentArtifact = new UtilFac.Artifact.FormDto
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
            this.lvwColumnSorter.Order = this.sortOrder;

            this.lsvContainer.Sort(this.sortColumn, this.lvwColumnSorter, isDocumentFirst);
            //this.SortListView(this.sortColumn);
        }

        public void Sort(SortOrder sortOrder)
        {
            this.sortOrder = sortOrder;
            this.lvwColumnSorter.Order = this.sortOrder;

            this.lsvContainer.Sort(this.sortColumn, this.lvwColumnSorter, isDocumentFirst);
            //this.SortListView(this.sortColumn);
        }

        public void Sort(String sortColumn, SortOrder sortOrder)
        {
            this.sortColumn = sortColumn;
            this.sortOrder = sortOrder;
            this.lvwColumnSorter.Order = this.sortOrder;

            this.lsvContainer.Sort(this.sortColumn, this.lvwColumnSorter, isDocumentFirst);
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
        }

        private void cmnuForm_Click(object sender, EventArgs e)
        {
            this.AddDocument(null);
        }

        #endregion

        private void ShowHideContextMenuItems(ListViewItem listViewItem)
        {
            if (listViewItem != null)
            {
                this.currentArtifact = listViewItem.Tag as UtilFac.Artifact.Dto;
            }

            menuClickSource = MenuClickSource.ListView;

            for (int i = 0; i < cmsExplorer.Items.Count; i++)
            {
                if (cmsExplorer.Items[i].Name == "cmnuPaste")
                {
                    //root node
                    if (this.currentArtifact != null && this.currentArtifact.Module == null && this.currentArtifact.Path == "Form")
                        this.currentArtifact.Style = UtilFac.Artifact.Type.Folder;

                    ListViewItem listViewPaste = null;
                    //if (listViewItem == null && this.currentArtifact != null)
                    if (this.currentArtifact != null && this.currentArtifact.Style == UtilFac.Artifact.Type.Folder)                    
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
                if ((cmsExplorer.Items[i].Name == "cmnuSort" && lvwColumnSorter.Order != SortOrder.None) || (cmsExplorer.Items[i].Name == "cmnuView"))
                {
                    this.SetImageInContextMenu((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems, cmsExplorer.Items[i].Name);
                }
                if (cmsExplorer.Items[i].Name == "newToolStripMenuItem")
                {
                    this.ShowHideContextMenuNewItems((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems);
                }
            }
        }

        private void ShowHideContextMenuItems(TreeNode treeNode)
        {
            this.currentArtifact = this.GetArtifact(treeNode.Tag);
            
            menuClickSource = MenuClickSource.TreeView;
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

        #region Tab

        private void tbcCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage currentTab = (sender as TabControl).SelectedTab;
            CategoryStatus currentCategory = (currentTab.Tag as CategoryStatus);
            this.lsvContainer.Items.Clear();
            this.facade.GetCurrentModules((UtilFac.Artifact.Category)(currentCategory.Category));
            if (!currentCategory.IsAlreadyLoaded) this.LoadModules(currentTab.Text);
            currentCategory.IsAlreadyLoaded = true;
            this.txtAddress.Text = currentTab.Text + this.formDto.Rule.ModuleSeperator;
        }

        private void InitializeTab()
        {
            this.tbpForm.Tag = new CategoryStatus
            {
                Category = UtilFac.Artifact.Category.Form,
                IsAlreadyLoaded = true,
            };
            this.tbpCatalogue.Tag = new CategoryStatus
            {
                Category = UtilFac.Artifact.Category.Catalogue,
            };
            this.tbpReport.Tag = new CategoryStatus
            {
                Category = UtilFac.Artifact.Category.Report,
            };
        }

        #endregion

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
            TreeNode currentNode = this.FindTreeNodeFromPath(selectedNodePath, trv.Nodes);
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
                this.currentArtifact = currentNode.Tag as UtilFac.Artifact.Dto;
                //this.trvArtifact_NodeMouseClick(this.trvForm, new TreeNodeMouseClickEventArgs(currentNode, MouseButtons.Left, 1, 0, 0));
                this.trvArtifact_NodeMouseClick(trv, new TreeNodeMouseClickEventArgs(currentNode, MouseButtons.Left, 1, 0, 0));
            }
        }

        private void SelectNode(UtilFac.Artifact.Dto dto)
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
                this.currentArtifact = currentNode.Tag as UtilFac.Artifact.Dto;                
                this.trvArtifact_NodeMouseClick(trv, new TreeNodeMouseClickEventArgs(currentNode, MouseButtons.Left, 1, 0, 0));
            }
        }



        private UtilFac.Artifact.Dto ReadDocument(UtilFac.Artifact.Dto selectedNode)
        {
            return new Facade.Container.Server(null).ReadDocument(selectedNode);
        }

        private UtilFac.Artifact.Dto GetParent(UtilFac.Artifact.Dto artifact)
        {
            return String.Compare(artifact.Parent.GetType().FullName, "Vanilla.Utility.Facade.Module.Dto") == 0 ?
                (artifact.Parent as UtilFac.Module.Dto).Artifact : artifact.Parent as UtilFac.Artifact.Dto;
        }

        private UtilFac.Artifact.Dto GetArtifact(Object tag)
        {
            return tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto" ?
                (tag as UtilFac.Module.Dto).Artifact : tag as UtilFac.Artifact.Dto;
        }

        private String GetFolderName(TreeNode node, UtilFac.Artifact.Type type)
        {
            UtilFac.Artifact.Dto artifactDto = this.GetArtifact(node.Tag);
            
            String fileName = String.Empty;
            String appendText = "New Folder";

            if (type.ToString() == UtilFac.Artifact.Type.Document.ToString())
            {
                appendText = "New " + this.tbcCategory.SelectedTab.Text;
            }

            if (artifactDto.Children == null)
                return appendText;

            Boolean isExists = false;
            for (int i = 0; i <= artifactDto.Children.Count; i++)
            {
                isExists = false;
                fileName = i == 0 ? appendText : appendText + " (" + i + ")";

                foreach (UtilFac.Artifact.Dto childArtifact in artifactDto.Children)
                {
                    if (childArtifact.FileName.ToUpper().Trim() == fileName.ToUpper().Trim())
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
            this.AddArtifact(UtilFac.Artifact.Type.Folder, null, null);
        }

        public void AddDocument()
        {
            this.AddDocument(null);
        }

        private void AddDocument(String componentType)
        {
            TreeView trv = this.GetActiveTreeView();
            UtilFac.Artifact.Category category = this.GetActiveCategory();
            TreeNode selectedNode = null;

            if ((this.menuClickSource == MenuClickSource.ListView) && (this.currentArtifact != null))
            {
                selectedNode = trv.FindNode(this.currentArtifact);
            }
            else if (this.menuClickSource == MenuClickSource.TreeView)
            {
                selectedNode = trv.SelectedNode;
            }
            
            if (selectedNode != null)
            {
                TreeNode rootNode = trv.FindRootNode();                

                //Show Dialogue to capture module data
                BinAff.Facade.Library.Dto moduleFormDto = new UtilFac.Module.Server(null) { Category = category }.InstantiateDto(rootNode.Tag as UtilFac.Module.Dto);

                if (componentType != null)
                {
                    (rootNode.Tag as UtilFac.Module.Dto).ComponentFormType = componentType;
                    
                }
                Type type = Type.GetType((rootNode.Tag as UtilFac.Module.Dto).ComponentFormType, true);

                String fileName = this.GetFolderName(selectedNode, UtilFac.Artifact.Type.Document);
                moduleFormDto.artifactPath = this.currentArtifact.Path + fileName;
                moduleFormDto.fileName = fileName;
                moduleFormDto.trvForm = trv;

                Form form = (Form)Activator.CreateInstance(type, moduleFormDto);
                form.ShowDialog(this);

                if (moduleFormDto != null && moduleFormDto.Id > 0)
                {
                    this.menuClickSource = MenuClickSource.ListView;                    
                    //AddArtifact(UtilFac.Artifact.Type.Document, moduleFormDto);
                    AddArtifact(UtilFac.Artifact.Type.Document, moduleFormDto, new UtilFac.Module.Definition.Dto { Code = (rootNode.Tag as UtilFac.Module.Dto).Code });
                }
            }
        }
        
        private void SaveArtifact(UtilFac.Artifact.Dto artifactDto, String fileName, Boolean isModify)
        {
            TreeView trv = this.GetActiveTreeView();
            UtilFac.Artifact.Category category = this.GetActiveCategory();

            this.formDto.ModuleFormDto.CurrentArtifact = new UtilFac.Artifact.FormDto
            {
                Dto = artifactDto,
            };

            this.PopulateNewArtifact(fileName, artifactDto.Style, this.formDto.ModuleFormDto.CurrentArtifact.Dto);
            this.facade = new Facade.Register.Server(this.formDto) { Category = category };

            TreeNode parentNode = null;
            if (artifactDto.Style == UtilFac.Artifact.Type.Document)
            {
                parentNode = trv.FindNode(this.GetParent(this.currentArtifact));
            }
            else
            {
                TreeNode selectedNode = trv.FindNode(artifactDto);
                parentNode = selectedNode != null ? selectedNode.Parent : null;
            }
            String pathOfParent = this.GetArtifact(parentNode.Tag).Path;
            //-- document should not contain the path separator
            if (artifactDto.Style == UtilFac.Artifact.Type.Document)
            {
                artifactDto.Path = pathOfParent + fileName;
            }
            else
            {
                artifactDto.Path = pathOfParent + fileName + this.formDto.Rule.PathSeperator;
            }

            if (isModify)
            {
                if (parentNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                {
                    if (artifactDto.Parent != null) artifactDto.Parent.Id = 0;
                }

                this.formDto.ModuleFormDto.CurrentArtifact.Dto.Version = this.formDto.ModuleFormDto.CurrentArtifact.Dto.Version + 1;
                this.formDto.ModuleFormDto.CurrentArtifact.Dto.ModifiedAt = DateTime.Now;
                this.formDto.ModuleFormDto.CurrentArtifact.Dto.ModifiedBy = new Table
                {
                    Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                    Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
                };

                this.facade.Change();
            }
            else // new insert
            {
                this.facade.Add();
            }

            this.currentArtifact = this.GetArtifact(parentNode.Tag);

            this.lsvContainer.AttachChildren(this.currentArtifact,isDocumentFirst);

            if (this.facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = PresLib.MessageBox.Type.Error,
                    Heading = "Navigator",
                }.Show(this.facade.DisplayMessageList);
            }
        }

        private void AddArtifact(UtilFac.Artifact.Type type, BinAff.Facade.Library.Dto moduleFormDto, UtilFac.Module.Definition.Dto moduleDefinationDto)
        {
            TreeView trv = this.GetActiveTreeView();
            TreeNode selectedNode = null;

            if ((this.menuClickSource.ToString() == MenuClickSource.ListView.ToString()) && (this.currentArtifact != null))
            {                
                selectedNode = trv.FindNode(this.currentArtifact);
            }
            else if (this.menuClickSource.ToString() == MenuClickSource.TreeView.ToString())
            {
                selectedNode = this.trvForm.SelectedNode;
            }

            if (selectedNode != null)
            {
                Table currentLoggedInUser = new Table
                {
                    Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                    Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
                };

                String fileName = this.GetFolderName(selectedNode, type);

                TreeNode newNode = new TreeNode
                {
                    Text = fileName,
                    Tag = new UtilFac.Artifact.Dto
                    {
                        FileName = fileName,
                        Extension = this.currentArtifact.Extension,
                        Version = 1,
                        Style = type,
                        CreatedBy = currentLoggedInUser,
                        CreatedAt = DateTime.Now,
                        Module = moduleFormDto,
                        ComponentDefinition = moduleDefinationDto == null ? null : new UtilFac.Module.Definition.Dto { Code = moduleDefinationDto.Code }
                    }
                };


                this.formDto.ModuleFormDto.CurrentArtifact = new UtilFac.Artifact.FormDto
                {
                    Dto = newNode.Tag as UtilFac.Artifact.Dto,
                };

                this.AttachNodes(selectedNode.Tag as BinAff.Facade.Library.Dto, this.formDto.ModuleFormDto.CurrentArtifact.Dto);
                if (type.ToString() == UtilFac.Artifact.Type.Folder.ToString())
                    selectedNode.Nodes.Add(newNode);               

                this.currentArtifact = this.GetArtifact(selectedNode.Tag);
                this.lsvContainer.AttachChildren(this.currentArtifact, isDocumentFirst);

                if (this.menuClickSource.ToString() == MenuClickSource.TreeView.ToString())
                {
                    trv.LabelEdit = true;
                    newNode.Parent.Expand();
                    trv.SelectedNode = null;
                    newNode.BeginEdit();
                }
                else
                {
                    this.lsvContainer.LabelEdit = true;
                    foreach (ListViewItem item in this.lsvContainer.Items)
                    {
                        UtilFac.Artifact.Dto dto = item.Tag as UtilFac.Artifact.Dto;
                        if (dto.Style == type && dto.FileName == fileName)
                        {
                            //Remove extension for document
                            if(dto.Style == UtilFac.Artifact.Type.Document) item.Text = item.Text.Remove(item.Text.LastIndexOf('.'));
                            item.BeginEdit();
                            break;
                        }
                    }
                }
            }
        }

        private void PopulateCutCopyNode()
        {
            this.editNode = null;
            TreeNode node = null;

            if (this.menuClickSource == MenuClickSource.TreeView)
            {
                node = this.trvForm.SelectedNode;
            }
            else if (this.currentArtifact.Style == UtilFac.Artifact.Type.Folder)
            {
                node = this.trvForm.FindNode(this.currentArtifact);
            }
            else if (this.currentArtifact.Style == UtilFac.Artifact.Type.Document)
            {
                if (this.currentArtifact.Parent.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    node = this.trvForm.FindNode((this.currentArtifact.Parent as UtilFac.Module.Dto).Artifact);
                else
                    node = this.trvForm.FindNode(this.currentArtifact.Parent as UtilFac.Artifact.Dto);
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
            //    nodeOneArtifactId = (nodeOne.Tag as UtilFac.Module.Dto).Artifact.Id;
            //else
            //    nodeOneArtifactId = (nodeOne.Tag as UtilFac.Artifact.Dto).Id;
            //if (nodeTwo.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
            //    nodeTwoArtifactId = (nodeTwo.Tag as UtilFac.Module.Dto).Artifact.Id;
            //else
            //    nodeTwoArtifactId = (nodeTwo.Tag as UtilFac.Artifact.Dto).Id;

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

        //private void cmnuReport_Click(object sender, EventArgs e)
        //{

        //}

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

        private UtilFac.Artifact.Category GetActiveCategory()
        {
            UtilFac.Artifact.Category category = UtilFac.Artifact.Category.Form;
            switch (this.tbcCategory.SelectedTab.Text)
            {
                case "Form":
                    category = UtilFac.Artifact.Category.Form;
                    break;
                case "Catalogue":
                    category = UtilFac.Artifact.Category.Catalogue;
                    break;
                case "Report":
                    category = UtilFac.Artifact.Category.Report;
                    break;
                default:
                    break;
            }
            return category;
        
        }

        #region Need to Remove

        //private void SelectNode(UtilFac.Artifact.Dto selectedNode)
        //{
        //    this.currentArtifact = selectedNode;

        //    this.lsvContainer.Items.Clear();
        //    if (selectedNode.Children != null && selectedNode.Children.Count > 0)
        //    {
        //        foreach (UtilFac.Artifact.Dto artifact in selectedNode.Children)
        //        {
        //            ListViewItem current = new ListViewItem
        //            {
        //                Text = artifact.FileName,
        //                Tag = artifact,
        //                ImageIndex = artifact.Style == UtilFac.Artifact.Type.Folder ? 0 : 2,
        //            };
        //            current.SubItems.AddRange(this.AddListViewSubItems(current, artifact));
        //            this.lsvContainer.Items.Add(current);
        //        }

        //        //sort list view
        //        this.sortColumn = "Name"; //this name will come from rule
        //        this.lvwColumnSorter.Order = SortOrder.Ascending;
        //        this.ResetColumnOrderInListView();

        //        this.lsvContainer.Sort(sortColumn, this.lvwColumnSorter);
        //        //this.SortListView(sortColumn);
        //    }
        //}

        //private void SortListView(String columnHeaderCaption)
        //{
        //    this.lsvContainer.ResetColumnHeader();
        //    for (int i = 0; i < lsvContainer.Columns.Count; i++)
        //    {
        //        if (this.lsvContainer.Columns[i].Text == columnHeaderCaption)
        //        {
        //            this.lvwColumnSorter.SortColumn = i;

        //            // Reverse the current sort direction for this column.
        //            if (lvwColumnSorter.Order == SortOrder.Ascending)
        //            {
        //                this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Down.gif";
        //            }
        //            else
        //            {
        //                this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Up.gif";
        //            }

        //            // Perform the sort with these new sort options.
        //            this.lsvContainer.Sort();
        //            break;
        //        }
        //    }
        //}

        //private void ResetListViewColumnHeader()
        //{
        //    //clear sort character from column caption
        //    for (int i = 0; i < lsvContainer.Columns.Count; i++)
        //    {
        //        this.lsvContainer.Columns[i].ImageKey = String.Empty;
        //        this.lsvContainer.Columns[i].ImageIndex = -1;
        //        this.lsvContainer.Columns[i].TextAlign = HorizontalAlignment.Left;
        //    }
        //}

        //private Boolean IsNodeTypeEqual(TreeNode destination, TreeNode source)
        //{
        //    if (destination != null && source != null)
        //    {
        //        TreeNode destinationRootNode = this.trvForm.FindRootNode(destination);
        //        TreeNode sourceRootNode = this.trvForm.FindRootNode(source);

        //        return ((destinationRootNode.Tag as UtilFac.Module.Dto).Code == (sourceRootNode.Tag as UtilFac.Module.Dto).Code); 
        //    }

        //    return false;
        //}

        //private TreeNode FindTreeNodeFromTag(UtilFac.Artifact.Dto artifactDto, TreeNodeCollection treeNodes, TreeNode selectedNode)
        //{
        //    foreach (TreeNode node in treeNodes)
        //    {
        //        if (selectedNode != null)
        //            break;

        //        UtilFac.Artifact.Dto tagArtifactDto;

        //        if (node.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
        //            tagArtifactDto = (node.Tag as UtilFac.Module.Dto).Artifact;
        //        else
        //            tagArtifactDto = node.Tag as UtilFac.Artifact.Dto;

        //        if ((tagArtifactDto.Id == artifactDto.Id) && (tagArtifactDto.FileName == artifactDto.FileName))
        //        {
        //            selectedNode = node;
        //            break;
        //        }
        //        else
        //            selectedNode = this.FindTreeNodeFromTag(artifactDto, node.Nodes, selectedNode);
        //    }

        //    return selectedNode;
        //}

        //private ListViewItem CreateNewListViewItem(String name, Int32 imageIndex)
        //{
        //    return new ListViewItem
        //    {
        //        Text = name,
        //        ImageIndex = imageIndex,
        //    };
        //}

        //private TreeNode FindRootNode(TreeNode treeNode)
        //{
        //    while (treeNode.Parent != null)
        //    {
        //        treeNode = treeNode.Parent;
        //    }
        //    return treeNode;
        //}

        #endregion

        private class CategoryStatus
        {
            internal UtilFac.Artifact.Category Category { get; set; }
            internal Boolean IsAlreadyLoaded { get; set; }
        }

        private void cmnuDailyReport_Click(object sender, EventArgs e)
        {
            TreeNode rootNode = this.GetRootNode();
            this.currentArtifact.Extension = "drpt";
            if (rootNode != null)
            {
                if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "CUST")
                    this.AddDocument("AutoTourism.Customer.WinForm.Report.Daily,AutoTourism.Customer.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LRSV")
                    this.AddDocument("AutoTourism.Lodge.WinForm.RoomReservationReport.Daily,AutoTourism.Lodge.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LCHK")
                    this.AddDocument("AutoTourism.Lodge.WinForm.CheckInReport.Daily,AutoTourism.Lodge.WinForm");
                else
                    this.AddDocument("Vanilla.Invoice.WinForm.Report.Daily,Vanilla.Invoice.WinForm");
            }
            
        }

        private void cmnuWeeklyReport_Click(object sender, EventArgs e)
        {           
            //this.AddDocument("Vanilla.Invoice.WinForm.Report.Weekly,Vanilla.Invoice.WinForm");

            this.currentArtifact.Extension = "wrpt";
            TreeNode rootNode = this.GetRootNode();
            if (rootNode != null)
            {
                if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "CUST")
                    this.AddDocument("AutoTourism.Customer.WinForm.Report.Weekly,AutoTourism.Customer.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LRSV")
                    this.AddDocument("AutoTourism.Lodge.WinForm.RoomReservationReport.Weekly,AutoTourism.Lodge.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LCHK")
                    this.AddDocument("AutoTourism.Lodge.WinForm.CheckInReport.Weekly,AutoTourism.Lodge.WinForm");
                else
                    this.AddDocument("Vanilla.Invoice.WinForm.Report.Weekly,Vanilla.Invoice.WinForm");
            }
        }

        private void cmnuMonthlyReport_Click(object sender, EventArgs e)
        {
            this.currentArtifact.Extension = "mrpt";
            TreeNode rootNode = this.GetRootNode();
            if (rootNode != null)
            {
                if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "CUST")
                    this.AddDocument("AutoTourism.Customer.WinForm.Report.Monthly,AutoTourism.Customer.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LRSV")
                    this.AddDocument("AutoTourism.Lodge.WinForm.RoomReservationReport.Monthly,AutoTourism.Lodge.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LCHK")
                    this.AddDocument("AutoTourism.Lodge.WinForm.CheckInReport.Monthly,AutoTourism.Lodge.WinForm");
                else
                    this.AddDocument("Vanilla.Invoice.WinForm.Report.Monthly,Vanilla.Invoice.WinForm");
            }
        }

        private void cmnuQuarterlyReport_Click(object sender, EventArgs e)
        {
            this.currentArtifact.Extension = "qrpt";
            TreeNode rootNode = this.GetRootNode();
            if (rootNode != null)
            {
                if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "CUST")
                    this.AddDocument("AutoTourism.Customer.WinForm.Report.Quarterly,AutoTourism.Customer.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LRSV")
                    this.AddDocument("AutoTourism.Lodge.WinForm.RoomReservationReport.Quarterly,AutoTourism.Lodge.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LCHK")
                    this.AddDocument("AutoTourism.Lodge.WinForm.CheckInReport.Quarterly,AutoTourism.Lodge.WinForm");
                else
                    this.AddDocument("Vanilla.Invoice.WinForm.Report.Quarterly,Vanilla.Invoice.WinForm");
            }
        }

        private void cmnuYearlyReport_Click(object sender, EventArgs e)
        {
            this.currentArtifact.Extension = "yrpt";
            TreeNode rootNode = this.GetRootNode();
            if (rootNode != null)
            {
                if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "CUST")
                    this.AddDocument("AutoTourism.Customer.WinForm.Report.Yearly,AutoTourism.Customer.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LRSV")
                    this.AddDocument("AutoTourism.Lodge.WinForm.RoomReservationReport.Yearly,AutoTourism.Lodge.WinForm");
                else if ((rootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == "LCHK")
                    this.AddDocument("AutoTourism.Lodge.WinForm.CheckInReport.Yearly,AutoTourism.Lodge.WinForm");
                else
                    this.AddDocument("Vanilla.Invoice.WinForm.Report.Yearly,Vanilla.Invoice.WinForm");
            }
        }

        private Type GetInvoiceType(UtilFac.Artifact.Dto artifactDto)
        {
            Int64 reportCategoryId = 0;
            if (artifactDto.ComponentDefinition.Code == "CUST")
            {
                reportCategoryId = (artifactDto.Module as AutoTourism.Customer.Facade.Report.Dto).category.Id;

                if (reportCategoryId == 10001)
                    return Type.GetType("AutoTourism.Customer.WinForm.Report.Daily,AutoTourism.Customer.WinForm", true);
                else if (reportCategoryId == 10002)
                    return Type.GetType("AutoTourism.Customer.WinForm.Report.Weekly,AutoTourism.Customer.WinForm", true);
                else if (reportCategoryId == 10003)
                    return Type.GetType("AutoTourism.Customer.WinForm.Report.Monthly,AutoTourism.Customer.WinForm", true);
                else if (reportCategoryId == 10004)
                    return Type.GetType("AutoTourism.Customer.WinForm.Report.Quarterly,AutoTourism.Customer.WinForm", true);
                else if (reportCategoryId == 10005)
                    return Type.GetType("AutoTourism.Customer.WinForm.Report.Yearly,AutoTourism.Customer.WinForm", true);
            }
            else
            {
                reportCategoryId = (artifactDto.Module as Vanilla.Invoice.Facade.Report.Dto).category.Id;

                if (reportCategoryId == 10001)
                    return Type.GetType("Vanilla.Invoice.WinForm.Report.Daily,Vanilla.Invoice.WinForm", true);
                else if (reportCategoryId == 10002)
                    return Type.GetType("Vanilla.Invoice.WinForm.Report.Weekly,Vanilla.Invoice.WinForm", true);
                else if (reportCategoryId == 10003)
                    return Type.GetType("Vanilla.Invoice.WinForm.Report.Monthly,Vanilla.Invoice.WinForm", true);
                else if (reportCategoryId == 10004)
                    return Type.GetType("Vanilla.Invoice.WinForm.Report.Quarterly,Vanilla.Invoice.WinForm", true);
                else if (reportCategoryId == 10005)
                    return Type.GetType("Vanilla.Invoice.WinForm.Report.Yearly,Vanilla.Invoice.WinForm", true);
            }

            return null;
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
            //this.ucSearchResult.Hide();
            //this.pnlArtifact.Show();
            //this.SelectNode(this.ucSearchResult.FormDto.CurrentArtifact.Style == UtilFac.Artifact.Type.Document ?
            //    this.GetParent(this.ucSearchResult.FormDto.CurrentArtifact).Path :
            //    this.ucSearchResult.FormDto.CurrentArtifact.Path);
            if (this.ucSearchResult.FormDto.CurrentArtifact.Style == UtilFac.Artifact.Type.Document)
            {
                PresLib.Form form = (PresLib.Form)Activator.CreateInstance(Type.GetType(this.ucSearchResult.FormDto.CurrentArtifact.ComponentDefinition.ComponentFormType, true), this.ucSearchResult.FormDto.CurrentArtifact.Module);
                form.ShowDialog(this);
            }
            else
            {
                this.ucSearchResult.Hide();
                this.pnlArtifact.Show();
                this.SelectNode(this.ucSearchResult.FormDto.CurrentArtifact.Style == UtilFac.Artifact.Type.Document ?
                       this.GetParent(this.ucSearchResult.FormDto.CurrentArtifact).Path :
                       this.ucSearchResult.FormDto.CurrentArtifact.Path);
            }
        }
        
    }

    public enum MenuClickSource
    {
        TreeView = 1,
        ListView = 2,
        MenuBar = 3
    }

}
