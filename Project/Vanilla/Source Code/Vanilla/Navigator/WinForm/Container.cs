using System;
using System.Windows.Forms;
using Vanilla.Navigator.Facade.Container;
using System.Collections;

using BinAff.Core;

using VanilaArtifact = Vanilla.Navigator.Facade.Artifact;
using VanilaModule = Vanilla.Navigator.Facade.Module;


namespace Vanilla.Navigator.WinForm
{

    public partial class Container : Form
    {

        private FormDto formDto;
        private Facade.Container.Server facade;
        Hashtable hashTreeView = new Hashtable();

        //Boolean isFormLoaded = false;
        //Boolean isCatalogueLoaded = false;
        //Boolean isReportLoaded = false;

        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tbcCategory.TabPages.Count; i++)
                hashTreeView.Add(tbcCategory.TabPages[i].Text, null);

            this.InitializeListView();
            this.txtAddress.Text = @"Form::";
            facade = new Server(this.formDto = new FormDto());
            facade.LoadForm();

            this.LoadModules(tbcCategory.TabPages[0].Text);

            lstViewContainer.View = View.Details;
            lstViewContainer.Dock = DockStyle.Fill;
        }
                         
        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvForm.LabelEdit = true;
            TreeNode node = new TreeNode
            {
                Text = "New folder",
                Tag = new Facade.Artifact.Dto { 
                    FileName = "test object"
                }
            };
          

            if (trvForm.SelectedNode != null)
            {
                (trvForm.SelectedNode as TreeNode).Nodes.Add(node);
                node.Parent.ExpandAll();
            }

            trvForm.SelectedNode = null;
            node.BeginEdit();
        }

        private void newItem_Click(object sender, EventArgs e)
        {
            if (trvForm.SelectedNode != null)
            {
                TreeNode selectedNode = (trvForm.SelectedNode as TreeNode);
                TreeNode rootNode = FindRootNode(selectedNode);
                //Facade.Module.Dto moduleDto = rootNode.Tag as Facade.Module.Dto;
                //BinAff.Facade.Library.Dto dto = rootNode.Tag as BinAff.Facade.Library.Dto;

                Type type = Type.GetType("AutoTourism.Customer.WinForm.CustomerForm, AutoTourism.Customer.WinForm", true);

                Type typeDto = Type.GetType("AutoTourism.Customer.Facade.Dto, AutoTourism.Customer.Facade", true);
                BinAff.Facade.Library.Dto dto = Activator.CreateInstance(typeDto) as BinAff.Facade.Library.Dto;
                              
                Form form = (Form)Activator.CreateInstance(type, dto);
                form.ShowDialog(this);
               
                if (dto.Id > 0)
                {

                    Vanilla.Navigator.Facade.Module.Dto moduleDto = rootNode.Tag as Vanilla.Navigator.Facade.Module.Dto;
                    moduleDto.Artifact = new VanilaArtifact.Dto { Id = dto.Id };

                    Facade.Artifact.Dto artifact = new VanilaArtifact.Dto
                    {
                        FileName = "NewCustomerFrom", // need to remove hard coding
                        Style = VanilaArtifact.Type.Document,
                        Parent = selectedNode.Tag as Facade.Artifact.Dto,
                        CreatedBy = new BinAff.Core.Table
                        {
                            Id = 1 //need to remove hard coding
                        },
                        CreatedAt = DateTime.Now,
                        Module = moduleDto,                       
                        Path = String.Empty
                    };

                    if (tbcCategory.SelectedTab.Text == "Form")
                        artifact.Category = VanilaArtifact.Category.Form;

                    VanilaArtifact.Server server = new VanilaArtifact.Server(new VanilaArtifact.FormDto { artifactDto = artifact });
                    ReturnObject<Boolean> retVal = server.Save();
                }
            }

            

            //ListViewItem item = new ListViewItem {
            //    Text = "New " + sender.ToString()                
            //};

            //Facade.Artifact.Dto dtoArtifact;
            //if (tbcCategory.SelectedTab.Text == "Form")
            //{
            //    dtoArtifact = trvForm.SelectedNode.Tag as Facade.Artifact.Dto;
            //    item.Tag = new Facade.Artifact.Dto {
            //        Id = dtoArtifact.Id, //storing the parentId for the current item
            //        Style = VanilaArtifact.Type.Document
            //    };
            //}
            

            //lstViewContainer.LabelEdit = true;
            //item.SubItems.Add(sender.ToString());           
            //lstViewContainer.Items.Add(item);
            //item.BeginEdit();
        }

        private void trvArtifact_MouseDown(object sender, MouseEventArgs e)
        {
            // Select the clicked node
            TreeView current = sender as TreeView;
            current.SelectedNode = current.GetNodeAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                ToolStripMenuItem menuItem = cmsExplorer.Items[0] as ToolStripMenuItem;
                if (current.SelectedNode != null)
                {
                    if (menuItem.DropDownItems.Count > 1)
                        menuItem.DropDownItems[1].Text = tbcCategory.SelectedTab.Text;
                    else
                    {
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

        private void trvArtifact_KeyUp(object sender, KeyEventArgs e)
        {
            TreeView current = sender as TreeView;
            if (e.KeyCode == Keys.F2)
            {
                current.LabelEdit = true;
                current.SelectedNode.BeginEdit();
            }
        }

        private void trvArtifact_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeView current = sender as TreeView;
            current.SelectedNode = null;
            current.LabelEdit = true;
            if (e.Label == null || e.Label.Trim().Length == 0)
                e.CancelEdit = true; // Can not be empty text
            else
            {

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
            Facade.Artifact.Dto dtoArtifact = selectedItem.Tag as Vanilla.Navigator.Facade.Artifact.Dto;
            dtoArtifact.FileName = (e.Label == null || e.Label.Trim().Length == 0) ? selectedItem.Text.Trim() : e.Label.Trim();
            dtoArtifact.CreatedAt = DateTime.Now;
            dtoArtifact.Version = 1;
        }

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

        private void trvArtifact_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.facade.LoadForm();
            this.facade.LoadArtifacts(e.Node.Text);
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
            this.lstViewContainer.Columns.Add("Type", 200);
            this.lstViewContainer.Columns.Add("Created By", 200);
            this.lstViewContainer.Columns.Add("Created At", 200);
            this.lstViewContainer.Columns.Add("Modified By", 200);
            this.lstViewContainer.Columns.Add("Modified At", 200);
        }

        private void trvArtifact_Click(object sender, EventArgs e)
        {
            VanilaArtifact.Dto selectedNode = (sender as TreeView).SelectedNode.Tag.GetType().ToString() == "Vanilla.Navigator.Facade.Module.Dto"?
                ((sender as TreeView).SelectedNode.Tag as VanilaModule.Dto).Artifact :
                (sender as TreeView).SelectedNode.Tag as VanilaArtifact.Dto;
            this.SelectNode(selectedNode);
            this.txtAddress.Text = this.tbcCategory.TabPages[0].Text + ":\\\\" + selectedNode.Path + selectedNode.fileName + "\\";
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
                    };
                    current.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
                        {   
                            new ListViewItem.ListViewSubItem(current, "Type")
                            {
                                Text = artifact.Style.ToString(),
                            },
                            new ListViewItem.ListViewSubItem(current, "Created By")
                            {
                                Text = (artifact.CreatedBy as BinAff.Core.Table).Name,
                            },
                            new ListViewItem.ListViewSubItem(current, "Created At")
                            {
                                Text = artifact.CreatedAt.ToString(),
                            },
                            new ListViewItem.ListViewSubItem(current, "Modified By")
                            {
                                Text = artifact.ModifiedBy == null ? String.Empty : (artifact.ModifiedBy as BinAff.Core.Table).Name,
                            },
                            new ListViewItem.ListViewSubItem(current, "Modified At")
                            {
                                Text = artifact.ModifiedAt == DateTime.MinValue? String.Empty : artifact.ModifiedAt.ToString(),
                            },
                        }
                    );
                    this.lstViewContainer.Items.Add(current);
                }
            }
        }

        private void lstViewContainer_DoubleClick(object sender, EventArgs e)
        {
            Vanilla.Navigator.Facade.Artifact.Dto currentArtifact = ((sender as ListView).SelectedItems[0].Tag as Vanilla.Navigator.Facade.Artifact.Dto);
            if (currentArtifact.Style == VanilaArtifact.Type.Directory)
            {
                this.SelectNode(currentArtifact);
            }
            else
            {
                //Currently hard coding. Need to change
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

    }

}
