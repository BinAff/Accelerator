using System;
using System.Windows.Forms;

using Crystal.Navigator.Component;

namespace Vanilla.Navigator.Presentation
{

    public partial class DetailMenuTreeView : DetailMenu
    {

        public DetailMenuTreeView()
        {
            InitializeComponent();
        }

        private void DetailMenuTreeView_Load(object sender, EventArgs e)
        {
            this.trvMenu.Nodes.AddRange(this.CreateNodes());
        }

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            base.SelectedArtifact = (Artifact)e.Node.Tag;
            base.OnClick(e);
        }

        protected virtual TreeNode[] CreateNodes()
        {
            throw new NotImplementedException();
        }

        public override void Navigate(String path)
        {
            this.trvMenu.SelectedNode = this.trvMenu.Nodes.Find(path, true)[0];
            this.trvMenu.Select();
        }

    }

}
