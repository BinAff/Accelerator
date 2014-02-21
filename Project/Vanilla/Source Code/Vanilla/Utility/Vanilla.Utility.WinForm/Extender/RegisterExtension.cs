using System;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm.Extender
{

    public static class TreeViewExtender
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

        /// <summary>
        /// Find root node for selected node in treeview
        /// </summary>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public static TreeNode FindRootNode(this TreeView treeView)
        {
            TreeNode treeNode = treeView.SelectedNode;
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
        }

        /// <summary>
        /// Find root node for specified node in treeview
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="treeNode">Specified node</param>
        /// <returns></returns>
        public static TreeNode FindRootNode(this TreeView treeView, TreeNode treeNode)
        {
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
        }

        public static Boolean IsNodeTypeEqual(this TreeView treeView, TreeNode destination, TreeNode source)
        {
            if (destination != null && source != null)
            {
                TreeNode destinationRootNode = treeView.FindRootNode(destination);
                TreeNode sourceRootNode = treeView.FindRootNode(source);

                return ((destinationRootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code == (sourceRootNode.Tag as Vanilla.Utility.Facade.Module.Dto).Code);
            }

            return false;
        }

    }

    public static class ListViewExtender
    {

        //private void SortListView(this ListView listView, String columnHeaderCaption)
        //{
        //    listView.ResetColumnHeader();
        //    for (int i = 0; i < listView.Columns.Count; i++)
        //    {
        //        if (listView.Columns[i].Text == columnHeaderCaption)
        //        {
        //            this.lvwColumnSorter.SortColumn = i;

        //            // Reverse the current sort direction for this column.
        //            if (lvwColumnSorter.Order == SortOrder.Ascending)
        //            {
        //                listView.Columns[lvwColumnSorter.SortColumn].ImageKey = "Down.gif";
        //            }
        //            else
        //            {
        //                listView.Columns[lvwColumnSorter.SortColumn].ImageKey = "Up.gif";
        //            }

        //            // Perform the sort with these new sort options.
        //            listView.Sort();
        //            break;
        //        }
        //    }
        //}

        public static void ResetColumnHeader(this ListView listView)
        {
            //clear sort character from column caption
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                listView.Columns[i].ImageKey = String.Empty;
                listView.Columns[i].ImageIndex = -1;
                listView.Columns[i].TextAlign = HorizontalAlignment.Left;
            }
        }

    }

}
