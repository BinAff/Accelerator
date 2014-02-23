using System;
using System.Windows.Forms;

using PresLib = BinAff.Presentation.Library;

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

        public static TreeNode FindNode(this TreeView treeView, Facade.Artifact.Dto artifact)
        {
            return Find(artifact, treeView.Nodes, null);
        }

        //public static TreeNode FindFromTag(this TreeView treeView, Facade.Artifact.Dto artifact, TreeNode selectedNode)
        //{
        //    return Find(artifact, treeView.Nodes, selectedNode);
        //}

        private static TreeNode Find(Facade.Artifact.Dto artifact, TreeNodeCollection treeNodes, TreeNode selectedNode)
        {
            foreach (TreeNode node in treeNodes)
            {
                if (selectedNode != null)
                {
                    break;
                }
                Facade.Artifact.Dto tagArtifactDto;

                if (node.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                {
                    tagArtifactDto = (node.Tag as Vanilla.Utility.Facade.Module.Dto).Artifact;
                }
                else
                {
                    tagArtifactDto = node.Tag as Vanilla.Utility.Facade.Artifact.Dto;
                }

                if ((tagArtifactDto.Id == artifact.Id) && (tagArtifactDto.FileName == artifact.FileName))
                {
                    selectedNode = node;
                    break;
                }
                else
                {
                    selectedNode = Find(artifact, node.Nodes, selectedNode);
                }
            }

            return selectedNode;
        }

    }

    public static class ListViewExtender
    {

        public static void AttachChildren(this ListView listView, Facade.Artifact.Dto selectedNode)
        {
            listView.Items.Clear();
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
                    current.SubItems.AddRange(AddListViewSubItems(current, artifact));
                    listView.Items.Add(current);
                }

                //Sort
                listView.ResetColumnOrder();
                listView.Sort("Name", new PresLib.ListViewColumnSorter
                {
                    Order = SortOrder.Ascending
                });
            }
        }

        private static void ResetColumnOrder(this ListView listView)
        {
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                listView.Columns[i].DisplayIndex = i;
            }
        }

        private static ListViewItem.ListViewSubItem[] AddListViewSubItems(ListViewItem node, Facade.Artifact.Dto artifact)
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
                    Text = artifact.CreatedBy == null ? String.Empty : (artifact.CreatedBy as BinAff.Core.Table).Name,
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

        public static void Sort(this ListView listView, String columnHeaderCaption, PresLib.ListViewColumnSorter columnSorter)
        {
            listView.ResetColumnHeader();
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                if (listView.Columns[i].Text == columnHeaderCaption)
                {
                    columnSorter.SortColumn = i;

                    // Reverse the current sort direction for this column.
                    if (columnSorter.Order == SortOrder.Ascending)
                    {
                        listView.Columns[columnSorter.SortColumn].ImageKey = "Down.gif";
                    }
                    else
                    {
                        listView.Columns[columnSorter.SortColumn].ImageKey = "Up.gif";
                    }

                    // Perform the sort with these new sort options.
                    listView.Sort();
                    break;
                }
            }
        }

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
