using System;
using System.Windows.Forms;
using Vanilla.Navigator.Facade.Container;
using System.Collections;

namespace Vanilla.Navigator.WinForm
{
    public partial class Container : Form
    {

        private FormDto formDto;
        private Facade.Container.Server facade;
        Hashtable hashTreeView = new Hashtable();

        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tbcCategory.TabPages.Count; i++)
                hashTreeView.Add(tbcCategory.TabPages[i].Text, null);

            this.txtAddress.Text = @"Form::";
            facade = new Server(this.formDto = new FormDto());
            facade.LoadForm();

            this.LoadModules(tbcCategory.TabPages[0].Text);
            lstViewContainer.View = View.Details;
            lstViewContainer.Dock = DockStyle.Fill;
            tbcCategory.SelectedIndexChanged += tbcCategory_SelectedIndexChanged;
            
        }                      
        
        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvArtifact.LabelEdit = true;
            TreeNode node = new TreeNode();
            node.Text = "New folder";

            if (trvArtifact.SelectedNode != null)
            {
                (trvArtifact.SelectedNode as TreeNode).Nodes.Add(node);
                node.Parent.ExpandAll();
            }
            else
                trvArtifact.Nodes.Add(node);

            trvArtifact.SelectedNode = null;
            node.BeginEdit();
        }

        private void newItem_Click(object sender, EventArgs e)
        {
            if (lstViewContainer.Columns.Count == 0)
            {
                lstViewContainer.Columns.Add("Name", 300);
                lstViewContainer.Columns.Add("Type", 200);
            }

            ListViewItem item = new ListViewItem {
                Text = "New " + sender.ToString()
            };

            lstViewContainer.LabelEdit = true;
            item.SubItems.Add(sender.ToString());           
            lstViewContainer.Items.Add(item);
            item.BeginEdit();

        }

        private void trvArtifact_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                trvArtifact.SelectedNode = trvArtifact.GetNodeAt(e.X, e.Y);

                ToolStripMenuItem menuItem = cmsExplorer.Items[0] as ToolStripMenuItem;
                if (trvArtifact.SelectedNode != null)
                {
                    if (menuItem.DropDownItems.Count > 1)
                        menuItem.DropDownItems[1].Text = tbcCategory.SelectedTab.Text;
                    else
                    {
                        ToolStripMenuItem newItem = new ToolStripMenuItem
                        {
                            Text = tbcCategory.SelectedTab.Text
                        };
                        newItem.Click += newItem_Click;
                        menuItem.DropDownItems.Insert(menuItem.DropDownItems.Count, newItem);
                    }

                    cmsExplorer.Show(trvArtifact, e.Location);
                }
                //else
                //{
                //    if (menuItem.DropDownItems.Count > 1)
                //        menuItem.DropDownItems.RemoveAt(1);

                //    cmsExplorer.Show(Cursor.Position);
                //}
            }
        }

        private void trvArtifact_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                trvArtifact.LabelEdit = true;
                trvArtifact.SelectedNode.BeginEdit();
            }
        }

        private void trvArtifact_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            trvArtifact.SelectedNode = null;
            trvArtifact.LabelEdit = true;
            if (e.Label == null || e.Label.Trim().Length == 0)
                e.CancelEdit = true; // Can not be empty text

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
            foreach (ListViewItem item in lstViewContainer.SelectedItems)
                item.Selected = false;

            lstViewContainer.LabelEdit = true;
            if (e.Label == null || e.Label.Trim().Length == 0)
                e.CancelEdit = true;
        
        }

        private void tbcCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //trvArtifact.Nodes.Clear();
            //lstViewContainer.Clear();

            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Text == "Form")
            {
                this.txtAddress.Text = @"Form::";
                this.facade.GetModules(Facade.Group.Form);
                //this.LoadModules();
            }
            else if (current.Text == "Catalogue")
            {
                this.txtAddress.Text = @"Catalogue::";
                this.facade.GetModules(Facade.Group.Catalogue);
                //this.LoadModules();
            }
            else if (current.Text == "Report")
            {
                this.txtAddress.Text = @"Report::";
                this.facade.GetModules(Facade.Group.Report);
            }

            this.LoadModules(current.Text);    
        }

        private void tbcCategory_Deselected(object sender, TabControlEventArgs e)
        {
            String tabName = (sender as TabControl).SelectedTab.Text;           
            hashTreeView[tabName] = CopyNodes(trvArtifact, new TreeView());
        }

        private void LoadModules(String currentTab)
        {
            //Int16 leftPos = 2;
            //this.pnlModule.Controls.Clear();
            //foreach (Facade.Module.Dto module in this.formDto.Dto.Modules)
            //{
            //    this.pnlModule.Controls.Add(new Module
            //    {
            //        formDto = new Facade.Module.FormDto
            //        {
            //            Dto = module,
            //        },
            //        Left = leftPos,
            //    });
            //    leftPos += 28;
            //}

            //populate Tree view
            trvArtifact.Nodes.Clear();


            if (hashTreeView.ContainsKey(currentTab) && hashTreeView[currentTab] != null)
            {
                TreeView tvHash = hashTreeView[currentTab] as TreeView;
                CopyNodes(tvHash, trvArtifact);
            }
            else
            {
                foreach (Facade.Module.Dto module in this.formDto.Dto.Modules)
                {
                    trvArtifact.Nodes.Add(new TreeNode
                    {
                        Text = module.Name
                    });
                }
            }
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
            this.facade.LoadArtifacts(e.Node.Text);
        }

    }

}
