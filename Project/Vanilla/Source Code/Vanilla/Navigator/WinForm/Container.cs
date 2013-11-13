using System;
using System.Windows.Forms;
using Vanilla.Navigator.Facade.Container;

namespace Vanilla.Navigator.WinForm
{
    public partial class Container : Form
    {

        private FormDto formDto;
        private Facade.Container.Server facade;

        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Form::";
            facade = new Server(this.formDto = new FormDto());
            facade.LoadForm();
            this.LoadModules();
        }

        private void tbpForm_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Form::";

            this.facade.GetModules(Facade.Group.Form);
            this.LoadModules();
        }

        private void tbpCatalogue_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Catalogue::";

            this.facade.GetModules(Facade.Group.Catalogue);
            this.LoadModules();
        }

        private void tbpReport_Enter(object sender, EventArgs e)
        {
            this.txtAddress.Text = @"Report::";

            this.facade.GetModules(Facade.Group.Report);
            this.LoadModules();
        }

        void LoadModules()
        {
            Int16 leftPos = 2;
            this.pnlModule.Controls.Clear();
            foreach (Facade.Module.Dto module in this.formDto.Dto.Modules)
            {
                this.pnlModule.Controls.Add(new Module
                {
                    formDto = new Facade.Module.FormDto
                    {
                        Dto = module,
                    },
                    Left = leftPos,
                });
                leftPos += 28;
            }
        }

        private void trvArtifact_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                trvArtifact.SelectedNode = trvArtifact.GetNodeAt(e.X, e.Y);

                if (trvArtifact.SelectedNode != null)
                    cmsExplorer.Show(trvArtifact, e.Location);
                else
                    cmsExplorer.Show(Cursor.Position);
            }  
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvArtifact.LabelEdit = true;
            TreeNode node = new TreeNode();
            node.Text = "aaaa";

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

    }

}
