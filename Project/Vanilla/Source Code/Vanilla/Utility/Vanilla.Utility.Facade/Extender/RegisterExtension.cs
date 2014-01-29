using System.Windows.Forms;

namespace Vanilla.Utility.Facade.Extender
{
    public static class RegisterExtension
    {
        public static TreeNode CreateTreeNodes(this TreeView treeView, Facade.Artifact.Dto node)
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
                        treeNode.Nodes.Add(CreateTreeNodes(treeView, child));
                    }
                }
            }
            return treeNode;
        }
    }
}
