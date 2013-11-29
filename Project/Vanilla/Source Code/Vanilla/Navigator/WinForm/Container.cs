using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using BinAff.Core;
using PresentationLib = BinAff.Presentation.Library;

namespace Vanilla.Navigator.WinForm
{

    public partial class Container : Form
    {

        private Facade.Container.FormDto formDto;
        private Facade.Container.Server facade;
        Hashtable hashTreeView = new Hashtable();
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
            
            this.DisableControl();
            this.ShowLoginForm();
            this.Resize += Container_Resize;
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

        public TreeNode CreateTreeNodes(Facade.Artifact.Dto node)
        {
            TreeNode treeNode = new TreeNode(node.FileName)
            {
                Tag = node,
            };
            if (node.Children != null && node.Children.Count > 0)
            {
                foreach (Facade.Artifact.Dto child in node.Children)
                {
                    if (child.Style == Facade.Artifact.Type.Directory)
                    {
                        treeNode.Nodes.Add(this.CreateTreeNodes(child));
                    }
                }
            }
            return treeNode;
        }

        private void Container_Resize(object sender, EventArgs e)
        {
            this.PositionLoginForm();
        }

        #region Login Form

        private void ShowLoginForm()
        {
            this.loginForm = new Guardian.WinForm.Login();
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
                this.facade = new Facade.Container.Server(this.formDto = new Facade.Container.FormDto
                {
                    ModuleFormDto = new Facade.Module.FormDto
                    {
                        Dto = new Facade.Module.Dto()
                    },
                });
                this.facade.LoadForm();
                this.LoadModules(tbcCategory.TabPages[0].Text);
                this.EnableControls();
            }
        }

        #endregion

        #region Tab

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

        #endregion

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

        #region ListView Context menu events

        private void lstViewContainer_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null && e.Label.Trim().Length == 0)
                e.CancelEdit = true;

            ListViewItem selectedItem = (sender as ListView).FocusedItem;
            String artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? selectedItem.Text.Trim() : e.Label.Trim();
            this.PopulateNewArtifact(artifactFileName, Facade.Artifact.Type.Document, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

            this.facade = new Facade.Container.Server(this.formDto);
            this.facade.Add();

            selectedItem.Text = this.formDto.ModuleFormDto.CurrentArtifact.Dto.FileName;
            selectedItem.SubItems.AddRange(this.AddListViewSubItems(selectedItem, this.formDto.ModuleFormDto.CurrentArtifact.Dto));

            PresentationLib.MessageBox.Type dialogueType;
            if (this.facade.IsError)
            {
                dialogueType = PresentationLib.MessageBox.Type.Error;
                this.lstViewContainer.Items.Remove(selectedItem);
            }
            else
            {
                dialogueType = PresentationLib.MessageBox.Type.Information;
            }
            new PresentationLib.MessageBox
            {
                DialogueType = dialogueType,
                Heading = "Splash",
            }.Show(this.facade.DisplayMessageList);
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

        private void lstViewContainer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                lstViewContainer.LabelEdit = true;
                foreach (ListViewItem item in lstViewContainer.SelectedItems)
                    item.BeginEdit();
            }
        }

        private void lstViewContainer_DoubleClick(object sender, EventArgs e)
        {
            Facade.Artifact.Dto currentArtifact = ((sender as ListView).SelectedItems[0].Tag as Facade.Artifact.Dto);
            if (currentArtifact.Style == Facade.Artifact.Type.Directory)
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

        private void lstViewContainer_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            //foreach (ListViewItem lstItem in (sender as ListView).Items)
            //{
            //    lstItem.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            //}

            //e.Item.BackColor = System.Drawing.Color.LightBlue;
        }

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

        private ListViewItem.ListViewSubItem[] AddListViewSubItems(ListViewItem node, Facade.Artifact.Dto artifact)
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

        private void SelectNode(Facade.Artifact.Dto selectedNode)
        {
            this.lstViewContainer.Items.Clear();
            if (selectedNode.Children != null && selectedNode.Children.Count > 0)
            {
                foreach (Facade.Artifact.Dto artifact in selectedNode.Children)
                {
                    ListViewItem current = new ListViewItem
                    {
                        Text = artifact.FileName,
                        Tag = artifact,
                        ImageIndex = artifact.Style == Facade.Artifact.Type.Directory ? 0 : 2,
                    };
                    current.SubItems.AddRange(this.AddListViewSubItems(current, artifact));
                    this.lstViewContainer.Items.Add(current);
                }
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
                    {
                        menuItem.DropDownItems[1].Text = tbcCategory.SelectedTab.Text;
                    }
                    else
                    {
                        //add new item in context menu [Form, catalog, report]
                        ToolStripMenuItem newItem = new ToolStripMenuItem
                        {
                            Text = tbcCategory.SelectedTab.Text,
                        };
                        newItem.Click += addDocument_Click;
                        menuItem.DropDownItems.Insert(menuItem.DropDownItems.Count, newItem);
                    }
                    cmsExplorer.Show(current, e.Location);
                }
            }
            else
            {
                //TreeNodeMouseDown(current.SelectedNode);
            }
        }

        private void trvArtifact_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            (sender as TreeView).LabelEdit = false;
            if (e.Label != null && e.Label.Trim().Length == 0)
                e.CancelEdit = true; // Can not be empty text

            String artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? e.Node.Text : e.Label.Trim();
            this.PopulateNewArtifact(artifactFileName, Facade.Artifact.Type.Directory, this.formDto.ModuleFormDto.CurrentArtifact.Dto);
   
            this.facade = new Facade.Container.Server(this.formDto);
            this.facade.Add();

            if (!this.facade.IsError && this.lstViewContainer.Items.Count > 0)
            {
                for (int i = 0; i < this.lstViewContainer.Items.Count; i++)
                {
                    if (this.lstViewContainer.Items[i].Text == e.Node.Text)
                    {
                        this.lstViewContainer.Items[i].Text = this.formDto.ModuleFormDto.CurrentArtifact.Dto.FileName;
                        this.lstViewContainer.Items[i].SubItems.AddRange(this.AddListViewSubItems(this.lstViewContainer.Items[i], this.formDto.ModuleFormDto.CurrentArtifact.Dto));
                        this.lstViewContainer.Items[i].Tag = this.formDto.ModuleFormDto.CurrentArtifact.Dto;
                        break;
                    }
                }
            }
        }

        private void trvArtifact_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.facade.LoadForm();
            this.facade.LoadArtifacts(e.Node.Text);
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

        private void trvForm_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Facade.Artifact.Dto selectedNode = (sender as TreeView).SelectedNode.Tag.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto" ?
                ((sender as TreeView).SelectedNode.Tag as Facade.Module.Dto).Artifact :
                (sender as TreeView).SelectedNode.Tag as Facade.Artifact.Dto;
            this.SelectNode(selectedNode);
            this.txtAddress.Text = selectedNode.Path;
            this.formDto.ModuleFormDto.Dto = this.FindRootNode((sender as TreeView).SelectedNode).Tag as Facade.Module.Dto;
        }

        private void TreeNodeMouseDown(TreeNode node)
        {
            //Vanilla.Navigator.Facade.Artifact.Dto dtoArtifact = node.Tag as Vanilla.Navigator.Facade.Artifact.Dto;
            //String filename = dtoArtifact.FileName;
        }

        private TreeNode FindRootNode(TreeNode treeNode)
        {
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
        }

        #endregion

        #region ContextMenu Events and methods

        private void addDirectory_Click(object sender, EventArgs e)
        {
            this.trvForm.LabelEdit = true;
            TreeNode newNode = new TreeNode
            {
                Text = "New Directory",
                Tag = new Facade.Artifact.Dto(),
            };
            this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
            {
                Dto = newNode.Tag as Facade.Artifact.Dto,
            };
            this.AttachParent(this.trvForm.SelectedNode.Tag as BinAff.Facade.Library.Dto, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

            if (this.trvForm.SelectedNode != null)
            {
                (this.trvForm.SelectedNode as TreeNode).Nodes.Add(newNode);
                newNode.Parent.Expand();

                this.trvForm.SelectedNode = null;
                newNode.BeginEdit();

                ListViewItem newListItem = this.CreateNewListViewItem("New Directory", 0);
                newListItem.Tag = this.formDto.ModuleFormDto.CurrentArtifact.Dto;
                this.lstViewContainer.Items.Add(newListItem);
            }
        }

        private void addDocument_Click(object sender, EventArgs e)
        {
            if (this.trvForm.SelectedNode != null)
            {
                TreeNode rootNode = this.FindRootNode((this.trvForm.SelectedNode as TreeNode));

                //Show Dialogue to capture module data
                BinAff.Facade.Library.Dto moduleFormDto = new Facade.Module.Server(null).InstantiateDto(rootNode.Tag as Facade.Module.Dto);
                Type type = Type.GetType((rootNode.Tag as Facade.Module.Dto).ComponentFormType, true);
                Form form = (Form)Activator.CreateInstance(type, moduleFormDto);
                form.ShowDialog(this);
                //moduleFormDto.Id = 7;// Hard coding. Just to ignore form feeling. Just remove

                if (moduleFormDto.Id > 0)
                {
                    ListViewItem newNode = this.CreateNewListViewItem("New " + sender.ToString(), 2);
                    newNode.Tag = new Facade.Artifact.Dto
                    {
                        Module = moduleFormDto,
                    };
                    this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
                    {
                        Dto = newNode.Tag as Facade.Artifact.Dto,
                    };
                    this.AttachParent(this.trvForm.SelectedNode.Tag as BinAff.Facade.Library.Dto, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

                    this.lstViewContainer.LabelEdit = true;
                    this.lstViewContainer.Items.Add(newNode);
                    newNode.BeginEdit();
                }
            }
        }

        private void deleteArtifact_Click(object sender, EventArgs e)
        {
            if (trvForm.SelectedNode != null)
            {
                this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
                {
                    Dto = (trvForm.SelectedNode as TreeNode).Tag as Facade.Artifact.Dto,
                };

                this.facade = new Facade.Container.Server(this.formDto);
                this.facade.Delete();
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
            this.ShowLoginForm();
        }

        private void mnuRegister_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.Registration registration = new Guardian.WinForm.Registration();
            registration.ShowDialog();
        }

        private void mnuRegisterProfile_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.Info info = new Guardian.WinForm.Info();
            info.ShowDialog();
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

        private void PopulateNewArtifact(String fileName, Facade.Artifact.Type type, Facade.Artifact.Dto currentArtifact)
        {
            currentArtifact.FileName = fileName;
            currentArtifact.Style = type;
            currentArtifact.Version = 1;
            currentArtifact.CreatedBy = new BinAff.Core.Table
            {
                Id = 1 //need to remove hard coding
            };
            currentArtifact.CreatedAt = DateTime.Now;
            switch (this.tbcCategory.SelectedTab.Text)
            {
                case "Form":
                    currentArtifact.Category = Facade.Artifact.Category.Form;
                    break;
                case "Catalogue":
                    currentArtifact.Category = Facade.Artifact.Category.Catalogue;
                    break;
                case "Report":
                    currentArtifact.Category = Facade.Artifact.Category.Report;
                    break;
                default:
                    currentArtifact.Category = Facade.Artifact.Category.Form;
                    break;
            }
            if (type == Facade.Artifact.Type.Directory)
            {
                currentArtifact.Path += currentArtifact.FileName + "\\";
            }
        }

        /// <summary>
        /// Attach parent to new node  and instantiate path with parent path
        /// </summary>
        /// <param name="parent"></param>
        private void AttachParent(BinAff.Facade.Library.Dto parent, Facade.Artifact.Dto child)
        {
            Facade.Artifact.Dto parentDto;
            if (parent.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto") //Adding to module
            {
                parentDto = (parent as Facade.Module.Dto).Artifact;
            }
            else
            {
                parentDto = parent as Facade.Artifact.Dto;
                child.Parent = parent;
            }
            if (parentDto.Children == null) parentDto.Children = new List<Facade.Artifact.Dto>();
            parentDto.Children.Add(child);
            child.Path = parentDto.Path;
        }

        private ListViewItem CreateNewListViewItem(String name, Int32 imageIndex)
        {
            return new ListViewItem
            {
                Text = name,
                ImageIndex = imageIndex,
            };
        }

    }

}
