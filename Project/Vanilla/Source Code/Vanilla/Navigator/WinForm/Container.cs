﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Facade.Cache;
using PresentationLib = BinAff.Presentation.Library;

using Vanilla.Tool.WinfForm;
using VanAcc = Vanilla.Guardian.Facade.Account;
using VanRole = Vanilla.Guardian.Facade.Role;

namespace Vanilla.Navigator.WinForm
{

    public partial class Container : Form
    {

        private Facade.Container.FormDto formDto;
        private Facade.Container.Server facade;
        private Hashtable hashTreeView;
        private Vanilla.Guardian.WinForm.Login loginForm;
        private Boolean isLoggedIn;
        private String selectedNodePath;
        private TreeNode editNode;
        private Boolean isCutAction;

        private String sortColumn;
        private ListViewColumnSorter lvwColumnSorter;

        public Container()
        {
            InitializeComponent();
            this.hashTreeView = new Hashtable();
        }

        public Container(String selectedNodePath)
            : this()
        {
            this.isLoggedIn = true;
            this.selectedNodePath = selectedNodePath;
        }

        private void Container_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tbcCategory.TabPages.Count; i++)
                hashTreeView.Add(tbcCategory.TabPages[i].Text, null);

            this.cmsExplorer.ImageList = this.imgSmallIcon;
            this.InitializeListView();
            this.DockContainers();
            this.HideControl();
            if (this.isLoggedIn)
            {
                this.LoadForm();
                this.SelectNode(this.selectedNodePath);
                this.txtAddress.Text = "Form" + this.formDto.Rule.ModuleSeperator;
            }
            else
            {
                this.ShowLoginForm();
            }
            this.Resize += Container_Resize;
        }

        private void DockContainers()
        {
            this.pnlArtifact.Dock = DockStyle.Fill;
            this.pnlNote.Dock = DockStyle.Fill;
            this.ucConfiguration.Dock = DockStyle.Fill;
        }

        private void SelectNode(String selectedNodePath)
        {
            selectedNodePath = selectedNodePath.Substring(selectedNodePath.IndexOf(this.formDto.Rule.ModuleSeperator) + 3);
            TreeNode currentNode = this.FindTreeNodeFromPath(selectedNodePath, this.trvForm.Nodes);
            this.trvForm.SelectedNode = currentNode;
            currentNode.Expand();
            this.trvForm_NodeMouseClick(this.trvForm, new TreeNodeMouseClickEventArgs(currentNode, MouseButtons.Left, 1, 0, 0));
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

        private void InitializeListView()
        {
            this.lsvContainer.Columns.Add("Name", 300);
            this.lsvContainer.Columns.Add("Type", 70);
            this.lsvContainer.Columns.Add("Version", 50);
            this.lsvContainer.Columns.Add("Created By", 200);
            this.lsvContainer.Columns.Add("Created At", 115);
            this.lsvContainer.Columns.Add("Modified By", 200);
            this.lsvContainer.Columns.Add("Modified At", 115);

            lvwColumnSorter = new ListViewColumnSorter();
            this.lsvContainer.ListViewItemSorter = lvwColumnSorter;

            this.sortColumn = "Name"; //this name will come from rule
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
                    case "Form": current = trvForm;
                        break;
                    case "Catalogue": current = trvCatalogue;
                        break;
                    case "Report": current = trvReport;
                        break;
                    default: current = trvForm;
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
            this.SetControlInMiddleOfForm(this.pnlLoginFormContainer);
        }

        #region Login Form

        private void ShowLoginForm()
        {
            this.loginForm = new Guardian.WinForm.Login
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
            };
            this.pnlLoginFormContainer.Show();
            this.pnlLoginFormContainer.Height = this.loginForm.Height;
            this.pnlLoginFormContainer.Width = this.loginForm.Width;
            this.SetControlInMiddleOfForm(this.pnlLoginFormContainer);
            this.pnlLoginFormContainer.Controls.Add(this.loginForm);

            this.loginForm.Show();
            this.loginForm.FormClosed += loginForm_FormClosed;
        }

        private void SetControlInMiddleOfForm(Control control)
        {
            control.Top = this.Height / 2 - control.Height / 2;
            control.Left = this.Width / 2 - control.Width / 2;
        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Vanilla.Guardian.WinForm.Login).IsAuthenticated)
            {
                this.LoadForm();
                this.pnlLoginFormContainer.Hide();
                this.txtAddress.Text = "Form" + this.formDto.Rule.ModuleSeperator;
            }
        }

        private void LoadForm()
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
            this.ShowControls();
            this.HideAndShowMenuForRole();
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
                this.lsvContainer.Items.Remove(selectedItem);
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
                ListViewItem selectedItem = lsvContainer.GetItemAt(e.X, e.Y);
                ShowHideContextMenuItems(true, null, selectedItem);
                cmsExplorer.Show(Cursor.Position);
            }
        }

        private void lstViewContainer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                lsvContainer.LabelEdit = true;
                foreach (ListViewItem item in lsvContainer.SelectedItems)
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
            ListViewItem selectedItem = lsvContainer.SelectedItems[0];
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
            this.lsvContainer.Items.Clear();
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
                    this.lsvContainer.Items.Add(current);
                }

                //sort list view
                this.sortColumn = "Name"; //this name will come from rule
                this.lvwColumnSorter.Order = SortOrder.Ascending;
                this.ResetColumnOrderInListView();

                this.SortListView(sortColumn);

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
                    ShowHideContextMenuItems(false, current.SelectedNode, null);
                    cmsExplorer.Show(current, e.Location);
                }
            }
           
        }

        private void trvArtifact_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            (sender as TreeView).LabelEdit = false;

            if (e.Label != null && e.Label.Trim().Length == 0)
            {
                e.CancelEdit = true; // Can not be empty text
                return;
            }
            //no text inserted during edit
            else if ((e.Node.Tag as Facade.Artifact.Dto).Id > 0 && e.Label == null)
            {
                e.CancelEdit = true; // Can not be empty text
                return;
            }
            //same text inserted during edit
            else if ((e.Node.Tag as Facade.Artifact.Dto).Id > 0 && e.Label.Trim() == e.Node.Text.Trim())
            {
                e.CancelEdit = true; // Can not be empty text
                return;
            }

            String artifactFileName = (e.Label == null || e.Label.Trim().Length == 0) ? e.Node.Text : e.Label.Trim();

            if (this.formDto.ModuleFormDto.CurrentArtifact == null)
            {
                this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
                {
                    Dto = e.Node.Tag as Facade.Artifact.Dto,
                };
            }
            this.PopulateNewArtifact(artifactFileName, Facade.Artifact.Type.Directory, this.formDto.ModuleFormDto.CurrentArtifact.Dto);
            this.facade = new Facade.Container.Server(this.formDto);

            //update
            if ((e.Node.Tag as BinAff.Facade.Library.Dto).Id > 0)
            {
                this.formDto.ModuleFormDto.CurrentArtifact.Dto.Version = this.formDto.ModuleFormDto.CurrentArtifact.Dto.Version + 1;
                this.formDto.ModuleFormDto.CurrentArtifact.Dto.ModifiedAt = DateTime.Now;
                this.formDto.ModuleFormDto.CurrentArtifact.Dto.ModifiedBy = new Table
                {
                    Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                    Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
                };

                this.facade.Change();
            }
            else    // new insert   
            {
                this.facade.Add();
                if (!this.facade.IsError)
                {
                    //root node
                    if (e.Node.Parent.Parent == null)
                    {
                        this.SelectNode((e.Node.Parent.Tag as Facade.Module.Dto).Artifact);
                    }
                    else
                    {
                        this.SelectNode(e.Node.Parent.Tag as Facade.Artifact.Dto);
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
            this.AttachNodes(this.trvForm.SelectedNode.Tag as BinAff.Facade.Library.Dto, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

            if (this.trvForm.SelectedNode != null)
            {
                (this.trvForm.SelectedNode as TreeNode).Nodes.Add(newNode);
                newNode.Parent.Expand();

                this.trvForm.SelectedNode = null;
                newNode.BeginEdit();

                ListViewItem newListItem = this.CreateNewListViewItem("New Directory", 0);
                newListItem.Tag = this.formDto.ModuleFormDto.CurrentArtifact.Dto;
                this.lsvContainer.Items.Add(newListItem);
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
                    this.AttachNodes(this.trvForm.SelectedNode.Tag as BinAff.Facade.Library.Dto, this.formDto.ModuleFormDto.CurrentArtifact.Dto);

                    this.lsvContainer.LabelEdit = true;
                    this.lsvContainer.Items.Add(newNode);
                    newNode.BeginEdit();
                }
            }
        }

        #endregion

        #region Menu Management

        #region File

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            this.ShowLoginForm();
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            this.HideControl();
            this.ShowLoginForm();
        }

        private void mnuNewWindow_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.trvForm.SelectedNode;

            Facade.Artifact.Dto currentDto;
            if (selectedNode.Tag.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto")
            {
                currentDto = (selectedNode.Tag as Facade.Module.Dto).Artifact;
            }
            else
            {
                currentDto = selectedNode.Tag as Facade.Artifact.Dto;
            }
            new System.Threading.Thread(new System.Threading.ThreadStart(delegate()
            {
                Application.Run(new Container(currentDto.Path));
            })).Start();
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            //Clear recent file list
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Edit

        private void mnuCut_Click(object sender, EventArgs e)
        {
            this.editNode = null;

            if (this.trvForm.SelectedNode != null && this.trvForm.SelectedNode.Parent != null)
            {
                this.editNode = this.trvForm.SelectedNode;
                this.isCutAction = true;
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            this.editNode = null;

            if (this.trvForm.SelectedNode != null && this.trvForm.SelectedNode.Parent != null)
            {
                this.editNode = this.trvForm.SelectedNode;
                this.isCutAction = false;
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (this.trvForm.SelectedNode != null && this.editNode != null)
            {                
                Int64 newParentId = 0;                

                foreach (TreeNode node in this.trvForm.SelectedNode.Nodes)
                {
                    if (node.Text.Trim() == this.editNode.Text.Trim())
                    {
                        new PresentationLib.MessageBox
                        {
                            DialogueType = PresentationLib.MessageBox.Type.Error,
                            Heading = "Splash"
                        }.Show("Duplicate node exists. Cannot do the paste operation.");
                        return;
                    }
                }              


                if (this.trvForm.SelectedNode.Parent != null)               
                    newParentId = (this.trvForm.SelectedNode.Tag as Facade.Artifact.Dto).Id;               
                            
                Facade.Artifact.Dto artifactDto;

                Table currentLoggedInUser = new Table
                {
                    Id = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Id,
                    Name = (Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto).Profile.Name
                };

                BinAff.Facade.Library.Dto parent = new BinAff.Facade.Library.Dto { Id = newParentId };

                String path = String.Empty;
                if (this.trvForm.SelectedNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
                    path = (this.trvForm.SelectedNode.Tag as Facade.Module.Dto).Artifact.Path;
                else
                    path = (this.trvForm.SelectedNode.Tag as Facade.Artifact.Dto).Path;

                if (this.isCutAction)
                {
                    artifactDto = new Facade.Container.Server(null).GetArtifactDtoByValue(editNode.Tag as Facade.Artifact.Dto);
                    artifactDto.Version = artifactDto.Version + 1;
                    artifactDto.ModifiedAt = DateTime.Now;
                    artifactDto.ModifiedBy = currentLoggedInUser;
                }
                else
                {
                    artifactDto = new Facade.Container.Server(null).GetArtifactDtoByValueForCopy(editNode.Tag as Facade.Artifact.Dto);
                    artifactDto.CreatedAt = DateTime.Now;
                    artifactDto.CreatedBy = currentLoggedInUser;
                }

                artifactDto.Parent = parent;
                artifactDto.Path = path + artifactDto.FileName + this.formDto.Rule.PathSeperator;

                this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
                {
                    Dto = artifactDto,
                };

                this.facade = new Facade.Container.Server(this.formDto);
                this.facade.Paste(this.isCutAction);

                if (!this.facade.IsError)
                {
                    TreeNode selectNode; //this node will be the focussed node
                    TreeNode actorNode;

                    if (this.isCutAction)
                    {
                        actorNode = this.editNode;
                        selectNode = actorNode.Parent;

                        //remove child dto from tag
                        this.RemoveChildDtoFromParentDto(actorNode.Parent, actorNode);

                        //remove node from tree
                        this.trvForm.Nodes.Remove(actorNode);
                    }
                    else
                    {
                        actorNode = this.editNode.Clone() as TreeNode;
                        selectNode = this.FindRootNode(this.trvForm.SelectedNode as TreeNode);
                    }

                    (this.trvForm.SelectedNode as TreeNode).Nodes.Add(actorNode);
                    actorNode.Tag = this.formDto.ModuleFormDto.CurrentArtifact.Dto;
                    this.AddChildDtoToParentDto(this.trvForm.SelectedNode, actorNode);
                    this.AttachTagToChildNodes(actorNode);

                    this.trvForm.SelectedNode = selectNode;

                    //Adding items to listView for the selected node
                    if (selectNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
                        this.SelectNode((selectNode.Tag as Facade.Module.Dto).Artifact);
                    else
                        this.SelectNode(selectNode.Tag as Facade.Artifact.Dto);
                }               
            }
            this.editNode = null;
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (this.trvForm.SelectedNode != null)
            {
                //donot delete the root node
                if (this.trvForm.SelectedNode.Parent == null)
                {
                    return;
                }

                this.formDto.ModuleFormDto.CurrentArtifact = new Facade.Artifact.FormDto
                {
                    Dto = (this.trvForm.SelectedNode as TreeNode).Tag as Facade.Artifact.Dto,
                };

                this.facade = new Facade.Container.Server(this.formDto);
                this.facade.Delete();

                if (!this.facade.IsError)
                {
                    Boolean isFirstLevelNode = false;
                    Facade.Artifact.Dto parentNode;

                    //Removing node from Parent Tag
                    if (this.trvForm.SelectedNode.Parent.Parent == null) //First level nodes [nodes whose parent id is null]      
                    {
                        isFirstLevelNode = true;
                        parentNode = (this.trvForm.SelectedNode.Parent.Tag as Facade.Module.Dto).Artifact;
                    }
                    else
                    {
                        parentNode = this.trvForm.SelectedNode.Parent.Tag as Facade.Artifact.Dto;
                    }

                    foreach (Facade.Artifact.Dto child in parentNode.Children)
                    {
                        if (child.Id == (this.trvForm.SelectedNode.Tag as Facade.Artifact.Dto).Id)
                        {
                            parentNode.Children.Remove(child);
                            break;
                        }
                    }

                    TreeNode node = this.trvForm.SelectedNode.Parent;
                    this.trvForm.SelectedNode.Remove();
                    this.trvForm.SelectedNode = node;

                    //populating the path
                    if (isFirstLevelNode)
                    {
                        //populating list view for the selected node
                        this.SelectNode((node.Tag as Facade.Module.Dto).Artifact);
                        this.txtAddress.Text = (node.Tag as Facade.Module.Dto).Artifact.Path;
                    }
                    else
                    {
                        this.SelectNode(node.Tag as Facade.Artifact.Dto);
                        this.txtAddress.Text = (node.Tag as Facade.Artifact.Dto).Path;
                    }

                    this.formDto.ModuleFormDto.Dto = this.FindRootNode(node).Tag as Facade.Module.Dto;
                }
            }
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lsvContainer.Items)
            {
                item.Selected = true;
            }
            this.lsvContainer.Focus();
        }

        private void mnuInvertSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lsvContainer.Items)
            {
                item.Selected = !item.Selected;
            }
        }

        #endregion

        #region View

        private void mnuRegister_Click(object sender, EventArgs e)
        {
            this.ShowRegister();
        }

        private void mnuConfiguration_Click(object sender, EventArgs e)
        {
            this.ShowConfiguration();
        }

        private void mnuStickyNote_Click(object sender, EventArgs e)
        {
            this.ShowNote();
        }

        private void mnuCalender_Click(object sender, EventArgs e)
        {
            this.ShowCalender();
        }

        private void mnuEmail_Click(object sender, EventArgs e)
        {
            this.ShowEmail();
        }

        private void mnuSMS_Click(object sender, EventArgs e)
        {
            this.ShowSms();
        }

        #endregion

        #region Tool

        private void mnuRegisterUser_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.Registration form = new Guardian.WinForm.Registration();
            form.ShowDialog();
        }

        private void mnuChangeOwnProfile_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.MyAccount form = new Guardian.WinForm.MyAccount();
            form.ShowDialog();
        }

        private void mnuChangeAccount_Click(object sender, EventArgs e)
        {
            Guardian.WinForm.Info form = new Guardian.WinForm.Info();
            form.ShowDialog();
        }

        #endregion

        #region Help

        private void mnuAbout_Click(object sender, EventArgs e)
        {

        }

        private void mnuViewHelp_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Sort
        private void cmnuSortCreatedAt_Click(object sender, EventArgs e)
        {         
            this.sortColumn = "Created At"; 
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortCreatedBy_Click(object sender, EventArgs e)
        {
            this.sortColumn = "Created By";
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortModifiedAt_Click(object sender, EventArgs e)
        {
            this.sortColumn = "Modified At";
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortModifiedBy_Click(object sender, EventArgs e)
        {
            this.sortColumn = "Modified By";
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortName_Click(object sender, EventArgs e)
        {
            this.sortColumn = "Name";
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortType_Click(object sender, EventArgs e)
        {
            this.sortColumn = "Type";
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortVersion_Click(object sender, EventArgs e)
        {
            this.sortColumn = "Version";
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortAscending_Click(object sender, EventArgs e)
        {
            this.lvwColumnSorter.Order = SortOrder.Ascending;
            this.SortListView(sortColumn);
        }

        private void cmnuSortDescending_Click(object sender, EventArgs e)
        {
            this.lvwColumnSorter.Order = SortOrder.Descending;
            this.SortListView(sortColumn);
        }
        #endregion

        #region View-Listview Display
        private void cmnuViewLargeIcon_Click(object sender, EventArgs e)
        {
            this.lsvContainer.View = View.LargeIcon;
        }

        private void cmnuViewSmallIcon_Click(object sender, EventArgs e)
        {
            this.lsvContainer.View = View.SmallIcon;
        }

        private void cmnuViewList_Click(object sender, EventArgs e)
        {
            this.lsvContainer.View = View.List;
        }

        private void cmnuDetail_Click(object sender, EventArgs e)
        {
            this.lsvContainer.View = View.Details;
        }
        #endregion

        #endregion

        private void ShowControls()
        {
            this.pnlAddress.Show();
            this.pnlArtifact.Show();
            this.pnlTool.Show();

            this.mnuLogin.Visible = false;
            this.mnuLogOut.Visible = true;
            this.mnuNew.Visible = true;
            this.mnuOpen.Visible = true;
            this.mnuFileSeperator2.Visible = true;
            this.mnuRecentFile.Visible = true;
            this.mnuFileSeperator3.Visible = true;
            this.mnuEdit.Visible = true;
            this.mnuView.Visible = true;
            this.mnuUserManagement.Visible = true;
        }

        private void HideControl()
        {
            this.pnlAddress.Hide();
            this.pnlTool.Hide();
            this.pnlArtifact.Hide();
            this.pnlNote.Hide();
            this.ucConfiguration.Hide();

            this.mnuLogin.Visible = true;
            this.mnuLogOut.Visible = false;
            this.mnuNew.Visible = false;
            this.mnuOpen.Visible = false;
            this.mnuFileSeperator2.Visible = false;
            this.mnuRecentFile.Visible = false;
            this.mnuFileSeperator3.Visible = false;
            this.mnuEdit.Visible = false;
            this.mnuView.Visible = false;
            this.mnuUserManagement.Visible = false;
        }

        private void HideAndShowMenuForRole()
        {
            VanAcc.Dto currentUser = Server.Current.Cache["User"] as VanAcc.Dto;
            VanRole.Dto role = currentUser.RoleList.Find((p) => 
            { 
                return String.Compare(p.Name, "Admin") == 0 || String.Compare(p.Name, "SuperAdmin") == 0; 
            });
            if (role == null)
            {
                this.mnuRegisterUser.Visible = false;
                this.mnuChangeAccount.Visible = false;
                this.mnuChangeOwnProfile.Visible = true;
            }
            else //Admin or Super Admin
            {
                this.mnuRegisterUser.Visible = true;
                this.mnuChangeAccount.Visible = true;
                this.mnuChangeOwnProfile.Visible = false;
            }
        }

        private void PopulateNewArtifact(String fileName, Facade.Artifact.Type type, Facade.Artifact.Dto currentArtifact)
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
                    currentArtifact.Path += currentArtifact.FileName + this.formDto.Rule.PathSeperator;
                }
            }
        }

        /// <summary>
        /// Attach parent to new node  and instantiate path with parent path
        /// </summary>
        /// <param name="parent"></param>
        private void AttachNodes(BinAff.Facade.Library.Dto parent, Facade.Artifact.Dto child)
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

        #region Tool Box

        private void btnHideShow_Click(object sender, EventArgs e)
        {
            if (this.btnRegister.Width == 0)
            {
                this.btnRegister.Width = this.btnHideShow.Width;
                this.btnCalender.Width = this.btnHideShow.Width;
                this.btnEmail.Width = this.btnHideShow.Width;
                this.btnSms.Width = this.btnHideShow.Width;
                this.btnNote.Width = this.btnHideShow.Width;
                this.btnConfiguration.Width = this.btnHideShow.Width;
                this.pnlTool.Width = this.btnHideShow.Width * 7;
                this.btnHideShow.Text = "7";
                this.toolTip.SetToolTip(this.btnHideShow, "Hide");
            }
            else
            {
                this.btnRegister.Width = 0;
                this.btnCalender.Width = 0;
                this.btnEmail.Width = 0;
                this.btnSms.Width = 0;
                this.btnNote.Width = 0;
                this.btnConfiguration.Width = 0;
                this.pnlTool.Width = this.btnHideShow.Width;
                this.btnHideShow.Text = "8";
                this.toolTip.SetToolTip(this.btnHideShow, "Show");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.ShowRegister();
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            this.ShowConfiguration();
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            this.ShowNote();
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            this.ShowCalender();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            this.ShowEmail();
        }

        private void btnSms_Click(object sender, EventArgs e)
        {
            this.ShowSms();
        }

        #endregion

        #region Containers Hide/Show

        private void ShowRegister()
        {
            this.pnlArtifact.Show();
            this.ucConfiguration.Hide();
            this.pnlNote.Hide();
        }

        private void ShowConfiguration()
        {
            this.pnlArtifact.Hide();
            this.pnlNote.Hide();
            this.ucConfiguration.Show();
            this.ucConfiguration.PopulateModuleForConfiguration();
        }

        private void ShowNote()
        {
            this.pnlArtifact.Hide();
            this.ucConfiguration.Hide();
            this.pnlNote.Show();
            if (this.pnlNote.Controls.Count == 0)
            {
                StickyNote stickyNote = StickyNote.Create(this);
                stickyNote.TopLevel = false;
                this.pnlNote.Controls.Add(stickyNote);
                stickyNote.Show();
            }
        }

        private void ShowCalender()
        {

        }

        private void ShowEmail()
        {

        }

        private void ShowSms()
        {

        }

        #endregion

        #region Address Bar

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

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

        #endregion

        private void RemoveChildDtoFromParentDto(TreeNode parentNode, TreeNode childNode)
        {
            Facade.Artifact.Dto parentArtifactDto;

            //Removing node from Parent Tag
            if (parentNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
                parentArtifactDto = (parentNode.Tag as Facade.Module.Dto).Artifact;
            else
                parentArtifactDto = parentNode.Tag as Facade.Artifact.Dto;
          
            foreach (Facade.Artifact.Dto child in parentArtifactDto.Children)
            {
                if (child.Id == (childNode.Tag as Facade.Artifact.Dto).Id)
                {
                    parentArtifactDto.Children.Remove(child);
                    break;
                }
            }
        }

        private void AddChildDtoToParentDto(TreeNode parentNode, TreeNode childNode)
        {
            Facade.Artifact.Dto parentArtifactDto;

            //Removing node from Parent Tag
            if(parentNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
                parentArtifactDto = (parentNode.Tag as Facade.Module.Dto).Artifact;
            else
                parentArtifactDto = parentNode.Tag as Facade.Artifact.Dto;

            if (parentArtifactDto.Children == null)
                parentArtifactDto.Children = new List<Facade.Artifact.Dto>();

            parentArtifactDto.Children.Add(childNode.Tag as Facade.Artifact.Dto);           

        }

        private void AttachTagToChildNodes(TreeNode node)
        {
            Facade.Artifact.Dto artifactDto = node.Tag as Facade.Artifact.Dto;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Tag = artifactDto.Children[i] as Facade.Artifact.Dto;
                if (node.Nodes[i].Nodes != null && node.Nodes[i].Nodes.Count > 0)
                    AttachTagToChildNodes(node.Nodes[i]);
            }
        }

        private void lsvContainer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.ResetListViewColumnHeader();     
                        
            this.sortColumn = this.lsvContainer.Columns[e.Column].Text;

            //Determine if clicked column is already the column that is being sorted.   
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.SortListView(this.sortColumn);
            
        }

        private void SortListView(String columnHeaderCaption)
        {
            this.ResetListViewColumnHeader();
            for (int i = 0; i < lsvContainer.Columns.Count; i++)
            {
                if (lsvContainer.Columns[i].Text == columnHeaderCaption)
                {
                    lvwColumnSorter.SortColumn = i;

                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)                        
                        this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Down.gif";
                    else
                        this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Up.gif";                 

                    // Perform the sort with these new sort options.
                    this.lsvContainer.Sort();

                    break;
                }
            }
            
        }       

        private void ResetListViewColumnHeader()
        {  
            //clear sort character from column caption
            for (int i = 0; i < lsvContainer.Columns.Count; i++)
            {
                this.lsvContainer.Columns[i].ImageKey = String.Empty;
                this.lsvContainer.Columns[i].ImageIndex = -1;
                this.lsvContainer.Columns[i].TextAlign = HorizontalAlignment.Center;
            }            
        }

        private void ShowHideContextMenuItems(Boolean isListView, TreeNode treeNode, ListViewItem listViewItem) 
        {
            if (isListView)
            {
                for (int i = 0; i < cmsExplorer.Items.Count; i++)
                {
                    cmsExplorer.Items[i].Visible = IsListViewItem(cmsExplorer.Items[i].Name, listViewItem);

                    //attach image to context menu
                    if ((cmsExplorer.Items[i].Name == "cmnuSort" && lvwColumnSorter.Order != SortOrder.None) || (cmsExplorer.Items[i].Name == "cmnuView"))
                        this.SetImageInContextMenu((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems, cmsExplorer.Items[i].Name);

                    if (cmsExplorer.Items[i].Name == "newToolStripMenuItem")
                        this.ShowHideContextMenuNewItems((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems);

                }
            }
            else //Tree View
            {
                for (int i = 0; i < cmsExplorer.Items.Count; i++)
                {
                    cmsExplorer.Items[i].Visible = IsTreeViewItem(cmsExplorer.Items[i].Name);

                    if (cmsExplorer.Items[i].Name == "newToolStripMenuItem")
                        this.ShowHideContextMenuNewItems((cmsExplorer.Items[i] as ToolStripMenuItem).DropDownItems);
                }
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
                    return listViewItem == null;
                case "newToolStripMenuItem":
                    return listViewItem == null;
                case "cmnuDelete":
                    return listViewItem != null;
                case "cmnuRename":
                    return listViewItem != null;
                case "cmnuCut":
                    return listViewItem != null;
                case "cmnuCopy":
                    return ((listViewItem != null) && ((listViewItem.Tag as Facade.Artifact.Dto).Style == Facade.Artifact.Type.Directory));
                case "cmnuPaste":
                    return ((listViewItem != null) && (this.editNode != null) && ((listViewItem.Tag as Facade.Artifact.Dto).Style == Facade.Artifact.Type.Directory));
                case "cmnuSeparator1":
                    return true;
                case "cmnuSeparator2":
                    return listViewItem != null;
                default:
                    return false;
            }
        }

        private Boolean IsTreeViewItem(String contextMenuName)
        {
            switch (contextMenuName)
            {
                case "cmnuCut":
                    return true;
                case "cmnuCopy":
                    return true;
                case "cmnuPaste":
                    return this.editNode != null;
                case "cmnuSeparator2":
                    return true;
                case "cmnuDelete":
                    return true;
                case "cmnuRename":
                    return true;
                case "cmnuSeparator3":
                    return true;
                case "newToolStripMenuItem":
                    return true;
                default:
                    return false;
            }
        }

        private void ResetColumnOrderInListView()
        {
            for (int i = 0; i < this.lsvContainer.Columns.Count; i++)
            {
                this.lsvContainer.Columns[i].DisplayIndex = i;
            }
        }

        private void SetImageInContextMenu(ToolStripItemCollection sortItems, String menuName)
        {
            //clear images
            for (int i = 0; i < sortItems.Count; i++)
                sortItems[i].Image = null;

            //set image in list context menu
            for (int i = 0; i < sortItems.Count; i++)
            {
                if (menuName == "cmnuSort")
                {
                    if ((this.sortColumn == sortItems[i].Text) || (lvwColumnSorter.Order.ToString() == sortItems[i].Text))
                        sortItems[i].Image = this.imgMisc.Images["Dot.gif"];
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
            //starting from 2nd item, since the 1st item directory will always be visible
            for (int i = 1; i < newItems.Count; i++)
                newItems[i].Visible = newItems[i].Text == tbcCategory.SelectedTab.Text;
        }

    }
   
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
	

}
