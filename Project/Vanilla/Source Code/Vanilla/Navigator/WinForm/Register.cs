using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BinAff.Core;
using BinAff.Facade.Cache;
using PresLib = BinAff.Presentation.Library;

namespace Vanilla.Navigator.WinForm
{

    public partial class Register : UserControl
    {

        private Facade.Container.FormDto formDto;
        private Facade.Container.Server facade;

        private PresLib.ListViewColumnSorter lvwColumnSorter;

        private TreeNode editNode;
        private String sortColumn;
        private SortOrder sortOrder;
        private Boolean isCutAction;

        public String Address { get; set; }

        public Register()
        {
            InitializeComponent();
            this.sortOrder = SortOrder.Ascending;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.cmsExplorer.ImageList = this.imgSmallIcon;
            this.InitializeListView();
            this.LoadForm();
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

        #region TreeView

        #region Events

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
                    this.ShowHideContextMenuItems(false, current.SelectedNode, null);
                    this.cmsExplorer.Show(current, e.Location);
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

        private void trvArtifact_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Facade.Artifact.Dto selectedNode = (sender as TreeView).SelectedNode.Tag.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto" ?
                ((sender as TreeView).SelectedNode.Tag as Facade.Module.Dto).Artifact :
                (sender as TreeView).SelectedNode.Tag as Facade.Artifact.Dto;
            this.SelectNode(selectedNode);
            this.Address = selectedNode.Path;
            this.formDto.ModuleFormDto.Dto = this.FindRootNode((sender as TreeView).SelectedNode).Tag as Facade.Module.Dto;
        }

        #endregion

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

        private void ResetColumnOrderInListView()
        {
            for (int i = 0; i < this.lsvContainer.Columns.Count; i++)
            {
                this.lsvContainer.Columns[i].DisplayIndex = i;
            }
        }

        private void SortListView(String columnHeaderCaption)
        {
            this.ResetListViewColumnHeader();
            for (int i = 0; i < lsvContainer.Columns.Count; i++)
            {
                if (this.lsvContainer.Columns[i].Text == columnHeaderCaption)
                {
                    this.lvwColumnSorter.SortColumn = i;

                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Down.gif";
                    }
                    else
                    {
                        this.lsvContainer.Columns[lvwColumnSorter.SortColumn].ImageKey = "Up.gif";
                    }

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

        private TreeNode FindRootNode(TreeNode treeNode)
        {
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
        }

        private void RemoveChildDtoFromParentDto(TreeNode parentNode, TreeNode childNode)
        {
            Facade.Artifact.Dto parentArtifactDto;

            //Removing node from Parent Tag
            if (parentNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
            {
                parentArtifactDto = (parentNode.Tag as Facade.Module.Dto).Artifact;
            }
            else
            {
                parentArtifactDto = parentNode.Tag as Facade.Artifact.Dto;
            }

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
            if (parentNode.Tag.GetType().FullName == "Vanilla.Navigator.Facade.Module.Dto")
            {
                parentArtifactDto = (parentNode.Tag as Facade.Module.Dto).Artifact;
            }
            else
            {
                parentArtifactDto = parentNode.Tag as Facade.Artifact.Dto;
            }

            if (parentArtifactDto.Children == null)
            {
                parentArtifactDto.Children = new List<Facade.Artifact.Dto>();
            }

            parentArtifactDto.Children.Add(childNode.Tag as Facade.Artifact.Dto);
        }

        private void AttachTagToChildNodes(TreeNode node)
        {
            Facade.Artifact.Dto artifactDto = node.Tag as Facade.Artifact.Dto;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].Tag = artifactDto.Children[i] as Facade.Artifact.Dto;
                if (node.Nodes[i].Nodes != null && node.Nodes[i].Nodes.Count > 0)
                {
                    this.AttachTagToChildNodes(node.Nodes[i]);
                }
            }
        }

        #endregion

        #region ListView

        #region Events

        private void lsvContainer_AfterLabelEdit(object sender, LabelEditEventArgs e)
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

            PresLib.MessageBox.Type dialogueType;
            if (this.facade.IsError)
            {
                dialogueType = PresLib.MessageBox.Type.Error;
                this.lsvContainer.Items.Remove(selectedItem);
            }
            else
            {
                dialogueType = PresLib.MessageBox.Type.Information;
            }
            new PresLib.MessageBox
            {
                DialogueType = dialogueType,
                Heading = "Splash",
            }.Show(this.facade.DisplayMessageList);
        }

        private void lsvContainer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ShowHideContextMenuItems(true, null, this.lsvContainer.GetItemAt(e.X, e.Y));
                this.cmsExplorer.Show(Cursor.Position);
            }
        }

        private void lsvContainer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.lsvContainer.LabelEdit = true;
                foreach (ListViewItem item in this.lsvContainer.SelectedItems)
                {
                    item.BeginEdit();
                }
            }
        }

        private void lsvContainer_DoubleClick(object sender, EventArgs e)
        {
            Facade.Artifact.Dto currentArtifact = ((sender as ListView).SelectedItems[0].Tag as Facade.Artifact.Dto);
            if (currentArtifact.Style == Facade.Artifact.Type.Directory)
            {
                this.SelectNode(currentArtifact);
                this.Address = currentArtifact.Path;
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

        private void lsvContainer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.ResetListViewColumnHeader();
            this.sortColumn = this.lsvContainer.Columns[e.Column].Text;

            //Determine if clicked column is already the column that is being sorted.   
            if (e.Column == this.lvwColumnSorter.SortColumn)
            {
                if (this.lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    this.lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    this.lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }

            this.SortListView(this.sortColumn);
        }

        #endregion

        private void InitializeListView()
        {
            this.lsvContainer.Columns.Add("Name", 300);
            this.lsvContainer.Columns.Add("Type", 70);
            this.lsvContainer.Columns.Add("Version", 50);
            this.lsvContainer.Columns.Add("Created By", 200);
            this.lsvContainer.Columns.Add("Created At", 115);
            this.lsvContainer.Columns.Add("Modified By", 200);
            this.lsvContainer.Columns.Add("Modified At", 115);

            this.lsvContainer.ListViewItemSorter = this.lvwColumnSorter = new PresLib.ListViewColumnSorter();

            this.sortColumn = "Name"; //this name will come from rule
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

        private ListViewItem CreateNewListViewItem(String name, Int32 imageIndex)
        {
            return new ListViewItem
            {
                Text = name,
                ImageIndex = imageIndex,
            };
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

        #endregion

        private void ShowHideContextMenuItems(Boolean isListView, TreeNode treeNode, ListViewItem listViewItem)
        {
            if (isListView)
            {
                for (int i = 0; i < cmsExplorer.Items.Count; i++)
                {
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
            //starting from 2nd item, since the 1st item directory will always be visible
            for (int i = 1; i < newItems.Count; i++)
            {
                newItems[i].Visible = newItems[i].Text == tbcCategory.SelectedTab.Text;
            }
        }

        #region Context Menu

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

        public void Cut()
        {
            this.editNode = null;

            if (this.trvForm.SelectedNode != null && this.trvForm.SelectedNode.Parent != null)
            {
                this.editNode = this.trvForm.SelectedNode;
                this.isCutAction = true;
            }
        }

        public void Copy()
        {
            this.editNode = null;

            if (this.trvForm.SelectedNode != null && this.trvForm.SelectedNode.Parent != null)
            {
                this.editNode = this.trvForm.SelectedNode;
                this.isCutAction = false;
            }
        }

        public void Paste()
        {
            if (this.trvForm.SelectedNode != null && this.editNode != null)
            {
                Int64 newParentId = 0;

                foreach (TreeNode node in this.trvForm.SelectedNode.Nodes)
                {
                    if (node.Text.Trim() == this.editNode.Text.Trim())
                    {
                        new PresLib.MessageBox
                        {
                            DialogueType = PresLib.MessageBox.Type.Error,
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
                    {
                        this.SelectNode((selectNode.Tag as Facade.Module.Dto).Artifact);
                    }
                    else
                    {
                        this.SelectNode(selectNode.Tag as Facade.Artifact.Dto);
                    }
                }
            }
            this.editNode = null;
        }

        public void Delete()
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
                        this.Address = (node.Tag as Facade.Module.Dto).Artifact.Path;
                    }
                    else
                    {
                        this.SelectNode(node.Tag as Facade.Artifact.Dto);
                        this.Address = (node.Tag as Facade.Artifact.Dto).Path;
                    }

                    this.formDto.ModuleFormDto.Dto = this.FindRootNode(node).Tag as Facade.Module.Dto;
                }
            }
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
            this.SortListView(this.sortColumn);
        }

        public void Sort(SortOrder sortOrder)
        {
            this.sortOrder = sortOrder;
            this.lvwColumnSorter.Order = this.sortOrder;
            this.SortListView(this.sortColumn);
        }

        public void Sort(String sortColumn, SortOrder sortOrder)
        {
            this.sortColumn = sortColumn;
            this.sortOrder = sortOrder;
            this.lvwColumnSorter.Order = this.sortOrder;
            this.SortListView(this.sortColumn);
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

        public void SetViewForList(View view)
        {
            this.lsvContainer.View = view;
        }

        #endregion

        #region New

        private void cmnuDirectory_Click(object sender, EventArgs e)
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

        private void cmnuForm_Click(object sender, EventArgs e)
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

        #endregion

        #region Tab

        private void tbcCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TabPage currentTab = (sender as TabControl).SelectedTab;

            //if (currentTab.Text == "Form")
            //{
            //    if (hashTreeView[currentTab.Text] == null)
            //    {
            //        this.Address = @"Form::";
            //        this.facade.GetCurrentModules(Facade.Artifact.Category.Form);
            //        this.LoadModules(currentTab.Text);
            //        //this.isCatalogueLoaded = true;
            //    }
            //    else
            //    {
            //        CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvForm);
            //    }

            //    //if (!this.isFormLoaded)
            //    //{
            //    //    this.txtAddress.Text = @"Form::";
            //    //    this.facade.GetCurrentModules(Facade.Category.Form);
            //    //    this.LoadModules(currentTab.Text);
            //    //    this.isFormLoaded = true;
            //    //}
            //}
            //else if (currentTab.Text == "Catalogue")
            //{
            //    if (hashTreeView[currentTab.Text] == null)
            //    {
            //        this.txtAddress.Text = @"Catalogue::";
            //        this.facade.GetCurrentModules(Facade.Artifact.Category.Catalogue);
            //        this.LoadModules(currentTab.Text);
            //        //this.isCatalogueLoaded = true;
            //    }
            //    else
            //    {
            //        CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvCatalogue);
            //    }
            //    //if (!this.isCatalogueLoaded)
            //    //{
            //    //    this.txtAddress.Text = @"Catalogue::";
            //    //    this.facade.GetCurrentModules(Facade.Category.Catalogue);
            //    //    this.LoadModules(currentTab.Text);
            //    //    this.isCatalogueLoaded = true;
            //    //}
            //}
            //else if (currentTab.Text == "Report")
            //{
            //    if (hashTreeView[currentTab.Text] == null)
            //    {
            //        this.txtAddress.Text = @"Report::";
            //        this.facade.GetCurrentModules(Facade.Artifact.Category.Report);
            //        this.LoadModules(currentTab.Text);
            //        //this.isCatalogueLoaded = true;
            //    }
            //    else
            //    {
            //        CopyNodes(hashTreeView[currentTab.Text] as TreeView, trvReport);
            //    }
            //    //if (!this.isReportLoaded)
            //    //{
            //    //    this.txtAddress.Text = @"Report::";
            //    //    this.facade.GetCurrentModules(Facade.Category.Report);
            //    //    this.LoadModules(currentTab.Text);
            //    //    this.isReportLoaded = true;
            //    //}
            //}
        }

        private void tbcCategory_Deselected(object sender, TabControlEventArgs e)
        {
            //String tabName = (sender as TabControl).SelectedTab.Text;
            ////hashTreeView[tabName] = CopyNodes(trvForm, new TreeView());
            //switch (tabName)
            //{
            //    case "Form":
            //        hashTreeView[tabName] = CopyNodes(trvForm, new TreeView());
            //        break;
            //    case "Catalogue":
            //        hashTreeView[tabName] = CopyNodes(trvCatalogue, new TreeView());
            //        break;
            //    case "Report":
            //        hashTreeView[tabName] = CopyNodes(trvReport, new TreeView());
            //        break;
            //    default:
            //        break;
            //}
        }

        #endregion

    }

}
