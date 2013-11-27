using System;
using System.Windows.Forms;
using System.Collections;

using BinAff.Core;
using PresentationLibrary = BinAff.Presentation.Library;

using VanilaArtifact = Vanilla.Navigator.Facade.Artifact;
using VanilaModule = Vanilla.Navigator.Facade.Module;
using VanilaContainer = Vanilla.Navigator.Facade.Container;
using System.Collections.Generic;


namespace Vanilla.Navigator.WinForm
{

    public partial class Container : Form
    {

        private VanilaContainer.FormDto formDto;
        private VanilaContainer.Server facade;
        Hashtable hashTreeView = new Hashtable();
        VanilaModule.Dto moduleDto;
        Vanilla.Guardian.WinForm.Login loginForm;
       
        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tbcCategory.TabPages.Count; i++)
                hashTreeView.Add(tbcCategory.TabPages[i].Text, null);

            this.InitializeListView();
            this.txtAddress.Text = @"Form:\\"; //Module Seperator is hard coding. Need to change
            this.facade = new VanilaContainer.Server(this.formDto = new VanilaContainer.FormDto
            {
                ModuleFormDto = new VanilaModule.FormDto
                {
                    Dto = new VanilaModule.Dto()
                }
            });
            this.facade.LoadForm();

            this.LoadModules(tbcCategory.TabPages[0].Text);

            this.DisableControl();
            this.ShowLoginForm();
            this.Resize += Container_Resize;
        }

        private void Container_Resize(object sender, EventArgs e)
        {
            this.PositionLoginForm();
        }

        #region Login Form

        private void ShowLoginForm()
        {
            if (loginForm == null) this.loginForm = new Guardian.WinForm.Login();
            this.loginForm.Show();
            this.PositionLoginForm();
            this.loginForm.FormClosed += loginForm_FormClosed;
        }

        private void PositionLoginForm()
        {
            this.loginForm.Top = this.Height / 2 - this.loginForm.Height / 2 + this.Top + 20;
            this.loginForm.Left = this.Width / 2 - this.loginForm.Width / 2 + this.Left;
            this.loginForm.TopMost = true;
        }

        void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Vanilla.Guardian.WinForm.Login).IsAuthenticated)
            {
                this.EnableControls();
            }
        }

        #endregion

        private void tbcCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage currentTab = (sender as TabControl).SelectedTab;

            if (currentTab.Text == "Form")
            {
                if (hashTreeView[currentTab.Text] == null)
                {
                    this.txtAddress.Text = @"Form::";
                    this.facade.GetCurrentModules(Facade.Artifact.Category.Form);
                    this.LoadModules(currentTab.Text);
                    //this.isCatalogueLoaded = true;
                }
                else
                {
                    CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvForm);
                }

                //if (!this.isFormLoaded)
                //{
                //    this.txtAddress.Text = @"Form::";
                //    this.facade.GetCurrentModules(Facade.Category.Form);
                //    this.LoadModules(currentTab.Text);
                //    this.isFormLoaded = true;
                //}
            }
            else if (currentTab.Text == "Catalogue")
            {
                if (hashTreeView[currentTab.Text] == null)
                {
                    this.txtAddress.Text = @"Catalogue::";
                    this.facade.GetCurrentModules(Facade.Artifact.Category.Catalogue);
                    this.LoadModules(currentTab.Text);
                    //this.isCatalogueLoaded = true;
                }
                else
                {
                    CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvCatalogue);
                }
                //if (!this.isCatalogueLoaded)
                //{
                //    this.txtAddress.Text = @"Catalogue::";
                //    this.facade.GetCurrentModules(Facade.Category.Catalogue);
                //    this.LoadModules(currentTab.Text);
                //    this.isCatalogueLoaded = true;
                //}
            }
            else if (currentTab.Text == "Report")
            {
                if (hashTreeView[currentTab.Text] == null)
                {
                    this.txtAddress.Text = @"Report::";
                    this.facade.GetCurrentModules(Facade.Artifact.Category.Report);
                    this.LoadModules(currentTab.Text);
                    //this.isCatalogueLoaded = true;
                }
                else
                {
                    CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvReport);
                }
                //if (!this.isReportLoaded)
                //{
                //    this.txtAddress.Text = @"Report::";
                //    this.facade.GetCurrentModules(Facade.Category.Report);
                //    this.LoadModules(currentTab.Text);
                //    this.isReportLoaded = true;
                //}
            }
        }

        private void tbcCategory_Deselected(object sender, TabControlEventArgs e)
        {
            String tabName = (sender as TabControl).SelectedTab.Text;
            //hashTreeView[tabName] = CopyNodes(trvForm, new TreeView());
            switch (tabName)
            {
                case "Form":
                    hashTreeView[tabName] = CopyNodes(trvForm, new TreeView());
                    break;
                case "Catalogue":
                    hashTreeView[tabName] = CopyNodes(trvCatalogue, new TreeView());
                    break;
                case "Report":
                    hashTreeView[tabName] = CopyNodes(trvReport, new TreeView());
                    break;
                default:
                    break;
            }
        }
        
        private void lstViewContainer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView current = new TreeView();
                ToolStripMenuItem newItem;
                ListViewItem selectedItem = lstViewContainer.GetItemAt(e.X, e.Y);

                //clear all contextStripMenu items
                cmsExplorer.Items.Clear();  

                if (selectedItem == null) //not right clicked on any item
                {
                    newItem = new ToolStripMenuItem { Text = "New" };
                    newItem.DropDownItems.Insert(0, new ToolStripMenuItem { Text = "Folder" });
                    newItem.DropDownItems[0].Click += ListViewFolder_Click;
                    newItem.DropDownItems.Insert(1, new ToolStripMenuItem { Text = tbcCategory.SelectedTab.Text });
                    newItem.DropDownItems[1].Click += ListViewDocument_Click;
                  
                }
                else //right click on list item
                {
                    newItem = new ToolStripMenuItem { Text = "Delete" };
                    newItem.Click += ListViewDelete_Click;
                }

                cmsExplorer.Items.Insert(0, newItem);   
                cmsExplorer.Show(Cursor.Position);
            }
        }                      

        private void trvArtifact_KeyUp(object sender, KeyEventArgs e)
        {
            TreeView current = sender as TreeView;
            if (e.KeyCode == Keys.F2)
            {
                current.LabelEdit = true;
                current.SelectedNode.BeginEdit();
            }
        }
        
        private void lstViewContainer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                lstViewContainer.LabelEdit = true;
                foreach (ListViewItem item in lstViewContainer.SelectedItems)                
                    item.BeginEdit();                
            }
        }

        private void lstViewContainer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null && e.Label.Trim().Length == 0)
                e.CancelEdit = true;

            ListViewItem selectedItem = (sender as ListView).FocusedItem;           
            //Facade.Artifact.Dto dtoArtifact = selectedItem.Tag as Vanilla.Navigator.Facade.Artifact.Dto;
            //dtoArtifact.FileName = (e.Label == null || e.Label.Trim().Length == 0) ? selectedItem.Text.Trim() : e.Label.Trim();
            //dtoArtifact.CreatedAt = DateTime.Now;
            //dtoArtifact.Version = 1;




            this.moduleDto.Artifact = selectedItem.Tag as Facade.Artifact.Dto;
            this.moduleDto.Artifact.FileName = (e.Label == null || e.Label.Trim().Length == 0) ? selectedItem.Text.Trim() : e.Label.Trim();
            this.moduleDto.Artifact.Style = VanilaArtifact.Type.Document;//Hard code
            this.moduleDto.Artifact.CreatedBy = new BinAff.Core.Table
            {
                Id = 1 //need to remove hard coding
            };
            this.moduleDto.Artifact.Path = String.Empty;
            this.moduleDto.Artifact.CreatedAt = DateTime.Now;
            this.moduleDto.Artifact.Parent = (selectedItem.Tag as Facade.Artifact.Dto).Parent;

            if (tbcCategory.SelectedTab.Text == "Form")
                this.moduleDto.Artifact.Category = VanilaArtifact.Category.Form;

            this.formDto = new VanilaContainer.FormDto
            {
                ModuleFormDto = new VanilaModule.FormDto
                {
                    Dto = this.moduleDto,
                },
            };
            this.facade = new VanilaContainer.Server(this.formDto);
            this.facade.Add();
            new PresentationLibrary.MessageBox
            {
                DialogueType = this.facade.IsError ? PresentationLibrary.MessageBox.Type.Error : PresentationLibrary.MessageBox.Type.Information,
                Heading = "Splash",
            }.Show(this.facade.DisplayMessageList);
        }

        private void LoadModules(String currentTab)
        {
            TreeView current = new TreeView();
            TreeNode[] tree = new TreeNode[this.formDto.Dto.Modules.Count];
            Int16 i = 0;
            foreach (Facade.Module.Dto module in this.formDto.Dto.Modules)
            {
                switch (currentTab)
                {
                    case "Form":
                        current = trvForm;
                        break;
                    case "Catalogue":
                        current = trvCatalogue;
                        break;
                    case "Report":
                        current = trvReport;
                        break;
                    default:
                        current = trvForm;
                        break;
                }
                tree[i] = this.CreateTreeNodes(module.Artifact);
                tree[i++].Tag = module;
            }
            current.Nodes.Clear();
            current.Nodes.AddRange(tree);
        }

        private TreeView CopyNodes(TreeView fromTreeView, TreeView toTreeView)
        {            
            TreeNode[] myTreeNodeArray = new TreeNode[fromTreeView.Nodes.Count];

            // Copy the tree nodes to the 'myTreeNodeArray' array.
            fromTreeView.Nodes.CopyTo(myTreeNodeArray, 0);

            // Remove all the tree nodes from the 'myTreeViewBase' TreeView.
            fromTreeView.Nodes.Clear();

            // Add the 'myTreeNodeArray' to the 'myTreeViewCustom' TreeView.
            toTreeView.Nodes.AddRange(myTreeNodeArray);

            return toTreeView;
        }

        private void TreeNodeMouseDown(TreeNode node) 
        { 
            //Vanilla.Navigator.Facade.Artifact.Dto dtoArtifact = node.Tag as Vanilla.Navigator.Facade.Artifact.Dto;
            //String filename = dtoArtifact.FileName;
            
        }
        
        public TreeNode CreateTreeNodes(Facade.Artifact.Dto node)
        {
            TreeNode treeNode = new TreeNode(node.FileName)
            {
                Tag = node,
            };
            if (node.Children != null && node.Children.Count > 0)
            {
                foreach(Facade.Artifact.Dto child in node.Children)
                {
                    if (child.Style == Facade.Artifact.Type.Directory)
                    {
                        treeNode.Nodes.Add(this.CreateTreeNodes(child));
                    }
                }
            }
            return treeNode;
        }

        private void InitializeListView()
        {
            this.lstViewContainer.Columns.Add("Name", 300);
            this.lstViewContainer.Columns.Add("Type", 70);
            this.lstViewContainer.Columns.Add("Version", 50);
            this.lstViewContainer.Columns.Add("Created By", 200);
            this.lstViewContainer.Columns.Add("Created At", 115);
            this.lstViewContainer.Columns.Add("Modified By", 200);
            this.lstViewContainer.Columns.Add("Modified At", 115);
        }

        private void SelectNode(VanilaArtifact.Dto selectedNode)
        {
            this.lstViewContainer.Items.Clear();
            if (selectedNode.Children != null && selectedNode.Children.Count > 0)
            {
                foreach (VanilaArtifact.Dto artifact in selectedNode.Children)
                {
                    ListViewItem current = new ListViewItem
                    {
                        Text = artifact.FileName,
                        Tag = artifact,
                        ImageIndex = artifact.Style == VanilaArtifact.Type.Directory ? 0 : 2,
                    };
                    current.SubItems.AddRange(this.AddListViewSubItems(current,artifact));
                    this.lstViewContainer.Items.Add(current);
                }
            }
        }

        private ListViewItem.ListViewSubItem[] AddListViewSubItems(ListViewItem node, VanilaArtifact.Dto artifact)
        {
            return new ListViewItem.ListViewSubItem[]
            {   
                new ListViewItem.ListViewSubItem(node, "Type")
                {
                    Text = artifact.Style.ToString(),
                },
                new ListViewItem.ListViewSubItem(node, "Version")
                {
                    Text = artifact.Version.ToString(),
                },
                new ListViewItem.ListViewSubItem(node, "Created By")
                {
                    Text = (artifact.CreatedBy as BinAff.Core.Table).Name,
                },
                new ListViewItem.ListViewSubItem(node, "Created At")
                {
                    Text = artifact.CreatedAt.ToString(),
                },
                new ListViewItem.ListViewSubItem(node, "Modified By")
                {
                    Text = artifact.ModifiedBy == null ? String.Empty : (artifact.ModifiedBy as BinAff.Core.Table).Name,
                },
                new ListViewItem.ListViewSubItem(node, "Modified At")
                {
                    Text = artifact.ModifiedAt == DateTime.MinValue? String.Empty : artifact.ModifiedAt.ToString(),
                },
            };
        }

        private void lstViewContainer_DoubleClick(object sender, EventArgs e)
        {
            Vanilla.Navigator.Facade.Artifact.Dto currentArtifact = ((sender as ListView).SelectedItems[0].Tag as Vanilla.Navigator.Facade.Artifact.Dto);
            if (currentArtifact.Style == VanilaArtifact.Type.Directory)
            {
                this.SelectNode(currentArtifact);
                this.txtAddress.Text = currentArtifact.Path;
            }
            else
            {
                //Currently hard coding. Need to change
                //TreeNode rootNode = FindRootNode(selectedNode);
                //Type type = Type.GetType((rootNode.Tag as Facade.Module.Dto).ComponentFormType, true);
                Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm", true);
                Form form = (Form)Activator.CreateInstance(type, currentArtifact.Module);

                form.ShowDialog(this);
            }
        }

        private TreeNode FindRootNode(TreeNode treeNode)
        {
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
        }

        private void trvForm_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            VanilaArtifact.Dto selectedNode = (sender as TreeView).SelectedNode.Tag.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto" ?
                ((sender as TreeView).SelectedNode.Tag as VanilaModule.Dto).Artifact :
                (sender as TreeView).SelectedNode.Tag as VanilaArtifact.Dto;
            this.SelectNode(selectedNode);
            this.txtAddress.Text = selectedNode.Path;
            moduleDto = this.FindRootNode((sender as TreeView).SelectedNode).Tag as VanilaModule.Dto;
        }
              
        private void lstViewContainer_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            //foreach (ListViewItem lstItem in (sender as ListView).Items)
            //{
            //    lstItem.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            //}

            //e.Item.BackColor = System.Drawing.Color.LightBlue;
        }

        #region ListView Context menu events
        private void ListViewFolder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListViewDocument_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ListViewDelete_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = lstViewContainer.SelectedItems[0];
            if (selectedItem != null)
            {
                Facade.Artifact.Dto artifactDto = selectedItem.Tag as Facade.Artifact.Dto;
                
            }
        }
        #endregion

        #region Tree related Events and methods

        private void trvArtifact_MouseDown(object sender, MouseEventArgs e)
        {
            // Select the clicked node
            TreeView current = sender as TreeView;
            current.SelectedNode = current.GetNodeAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem menuItem = cmsExplorer.Items[0] as ToolStripMenuItem;
                if (current.SelectedNode != null) //check whether right click is done on tree node
                {
                    if (menuItem.DropDownItems.Count > 1)
                        menuItem.DropDownItems[1].Text = tbcCategory.SelectedTab.Text;
                    else
                    {
                        //add new item in context menu [Form, catalog, report]
                        ToolStripMenuItem newItem = new ToolStripMenuItem
                        {
                            Text = tbcCategory.SelectedTab.Text,
                        };
                        newItem.Click += newItem_Click;
                        menuItem.DropDownItems.Insert(menuItem.DropDownItems.Count, newItem);
                    }
                    cmsExplorer.Show(current, e.Location);
                }
            }
            else
            {
                TreeNodeMouseDown(current.SelectedNode);
            }
        }

        private void trvArtifact_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeView current = sender as TreeView;
            current.SelectedNode = null;
            current.LabelEdit = true;

            if (e.Label != null && e.Label.Trim().Length == 0)
                e.CancelEdit = true; // Can not be empty text

            //If the Folder name is empty , then application will take the default text as FileName [Eg: New folder]
            String ArtifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? e.Node.Text : e.Label.Trim();
            
            this.moduleDto.Artifact = new Facade.Artifact.Dto();
            this.moduleDto.Artifact.FileName = ArtifactFileName;
            this.moduleDto.Artifact.Style = VanilaArtifact.Type.Directory;
            this.moduleDto.Artifact.CreatedBy = new BinAff.Core.Table
            {
                Id = 1 //need to remove hard coding
            };
            this.moduleDto.Artifact.Path = String.Empty;
            this.moduleDto.Artifact.CreatedAt = DateTime.Now;

            Int64 parentID = ((BinAff.Facade.Library.Dto)((e.Node.Parent).Tag)).Id;
            if (e.Node.Parent.Parent == null)
                this.moduleDto.Artifact.Parent = null;
            else
                this.moduleDto.Artifact.Parent = new BinAff.Facade.Library.Dto { Id = parentID };
               
            if (tbcCategory.SelectedTab.Text == "Form")
                this.moduleDto.Artifact.Category = VanilaArtifact.Category.Form;

            this.formDto = new VanilaContainer.FormDto
            {
                ModuleFormDto = new VanilaModule.FormDto
                {
                    Dto = this.moduleDto,
                },
            };
            this.facade = new VanilaContainer.Server(this.formDto);
            this.facade.Add();

            if (!this.facade.IsError && lstViewContainer.Items.Count > 0)
            {
                for (int i = 0; i < lstViewContainer.Items.Count; i++)
                {
                    if (lstViewContainer.Items[i].Text == e.Node.Text)
                    {
                        lstViewContainer.Items[i].Text = this.moduleDto.Artifact.FileName;
                        break;
                    }
                }

                this.moduleDto.Artifact.Parent = e.Node.Parent.Tag as Facade.Artifact.Dto;

                if ((e.Node.Parent.Tag as Facade.Artifact.Dto).Children == null)
                    (e.Node.Parent.Tag as Facade.Artifact.Dto).Children = new List<VanilaArtifact.Dto>();

                (e.Node.Parent.Tag as Facade.Artifact.Dto).Children.Add(this.moduleDto.Artifact); 
            }
            
        }

        private void trvArtifact_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.facade.LoadForm();
            this.facade.LoadArtifacts(e.Node.Text);
        }

        #endregion

        #region ContextMenu Events and methods

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvForm.LabelEdit = true;
            TreeNode node = new TreeNode { Text = "New folder" };
            
            if (trvForm.SelectedNode != null)
            {
                (trvForm.SelectedNode as TreeNode).Nodes.Add(node);
                node.Parent.Expand();

                trvForm.SelectedNode = null;
                node.BeginEdit();

                //Add folder to listview
                ListViewItem item = new ListViewItem 
                {
                    Text = "New folder", 
                    ImageIndex = 0,
                };
                item.SubItems.Add(VanilaArtifact.Type.Directory.ToString());
                item.SubItems.Add("1");
                item.SubItems.Add("Biraj");
                item.SubItems.Add(DateTime.Now.ToString());

                lstViewContainer.Items.Add(item);
            }
             
        }

        private void newItem_Click(object sender, EventArgs e)
        {
            if (trvForm.SelectedNode != null)
            {
                TreeNode selectedNode = (trvForm.SelectedNode as TreeNode);
                TreeNode rootNode = FindRootNode(selectedNode);

                //Show Dialogue to capture module data
                BinAff.Facade.Library.Dto moduleFormDto = new Facade.Module.Server(null).InstantiateDto(rootNode.Tag as Facade.Module.Dto);
                Type type = Type.GetType((rootNode.Tag as Facade.Module.Dto).ComponentFormType, true);
                Form form = (Form)Activator.CreateInstance(type, moduleFormDto);
                form.ShowDialog(this);

                //Hard coding
                moduleFormDto.Id = 7;

                //if (moduleFormDto.Id > 0)
                //{
                //    Vanilla.Navigator.Facade.Module.Dto moduleDto = rootNode.Tag as Vanilla.Navigator.Facade.Module.Dto;
                //    moduleDto.Artifact = new VanilaArtifact.Dto { Id = moduleFormDto.Id };

                //    Facade.Artifact.Dto artifact = new VanilaArtifact.Dto
                //    {
                //        FileName = "New Form 1", // need to remove hard coding
                //        Style = VanilaArtifact.Type.Document,
                //        Parent = selectedNode.Tag as Facade.Artifact.Dto,
                //        CreatedBy = new BinAff.Core.Table
                //        {
                //            Id = 1 //need to remove hard coding
                //        },
                //        CreatedAt = DateTime.Now,
                //        Module = moduleDto,                       
                //        Path = String.Empty
                //    };

                //    if (tbcCategory.SelectedTab.Text == "Form")
                //        artifact.Category = VanilaArtifact.Category.Form;

                //    VanilaArtifact.Server server = new VanilaArtifact.Server(new VanilaArtifact.FormDto { artifactDto = artifact });
                //    ReturnObject<Boolean> retVal = server.Save();
                //}
                if (moduleFormDto.Id > 0)
                {
                    Facade.Artifact.Dto dtoArtifact = new Facade.Artifact.Dto
                    {
                        Module = moduleFormDto,
                        Style = VanilaArtifact.Type.Document,
                        Parent = selectedNode.Parent == null ? null : selectedNode.Tag as BinAff.Facade.Library.Dto,
                    };
                    ListViewItem item = new ListViewItem
                    {
                        Text = "New " + sender.ToString() + "1",
                        Tag = dtoArtifact,
                    };

                    Facade.Artifact.Dto dto = (selectedNode.Parent == null) ? (selectedNode.Tag as Facade.Module.Dto).Artifact : selectedNode.Tag as Facade.Artifact.Dto;
                    dto.Children.Add(dtoArtifact);
                    //if (tbcCategory.SelectedTab.Text == "Form")
                    //{
                    //    dtoArtifact = trvForm.SelectedNode.Tag as Facade.Artifact.Dto;

                    //    item.Tag = new Facade.Artifact.Dto
                    //    {
                    //        Id = dtoArtifact.Id, //storing the parentId for the current item
                    //        Style = VanilaArtifact.Type.Document
                    //    };
                    //}
                    lstViewContainer.LabelEdit = true;
                    item.SubItems.Add(sender.ToString());
                    lstViewContainer.Items.Add(item);
                    item.BeginEdit();
                }
            }
        }

        #endregion

        #region Menu Management

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            this.DisableControl();
        }

        private void mnuRegister_Click(object sender, EventArgs e)
        {

        }

        private void mnuRegisterProfile_Click(object sender, EventArgs e)
        {

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void EnableControls()
        {
            this.pnlAddress.Visible = true;
            this.pnlMain.Visible = true;

            this.mnuLogin.Visible = false;
            this.mnuLogOut.Visible = true;
            this.mnuNew.Visible = true;
            this.mnuOpen.Visible = true;
            this.mnuFileSeperator2.Visible = true;
            this.mnuEdit.Visible = true;
            this.mnuView.Visible = true;
            this.mnuUserManagement.Visible = true;
        }

        private void DisableControl()
        {
            this.pnlAddress.Visible = false;
            this.pnlMain.Visible = false;

            this.mnuLogin.Visible = true;
            this.mnuLogOut.Visible = false;
            this.mnuNew.Visible = false;
            this.mnuOpen.Visible = false;
            this.mnuFileSeperator2.Visible = false;
            this.mnuEdit.Visible = false;
            this.mnuView.Visible = false;
            this.mnuUserManagement.Visible = false;
        }

    }

}
