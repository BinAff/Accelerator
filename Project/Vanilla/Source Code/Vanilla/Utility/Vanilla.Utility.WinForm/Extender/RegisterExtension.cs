using System;
using System.Collections.Generic;
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
                    if (child.Style == Facade.Artifact.Type.Folder)
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

        public static String Initialize(this ListView listView)
        {
            listView.Columns.Add("Name", 150);
            listView.Columns.Add("Type", 70);
            listView.Columns.Add("Version", 50);
            listView.Columns.Add("Created By", 100);
            listView.Columns.Add("Created At", 115);
            listView.Columns.Add("Modified By", 100);
            listView.Columns.Add("Modified At", 115);

            listView.ListViewItemSorter = new PresLib.ListViewColumnSorter();
            return "Name"; //this name will come from rule
        }

        public static void EditListViewSelectedItem(this ListView listView)
        {
            listView.LabelEdit = true;
            foreach (ListViewItem item in listView.SelectedItems)
            {
                item.Text = (item.Tag as Vanilla.Utility.Facade.Artifact.Dto).FileName;
                item.BeginEdit();
                break;
            }
        }

        public static void EditListViewSelectedItem(this ListView listView, String artifactFileName)
        {
            listView.LabelEdit = true;
            foreach (ListViewItem item in listView.SelectedItems)
            {
                item.Text = artifactFileName;                
                item.BeginEdit();              
            }
        }

        public static void AttachChildren(this ListView listView, Facade.Artifact.Dto selectedNode, Boolean isDocumentFirst)
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
                        ImageIndex = artifact.Style == Facade.Artifact.Type.Folder ? 0 : 2,
                    };
                    if (artifact.Style == Facade.Artifact.Type.Document) current.Text += "." + artifact.Extension;
                    current.SubItems.AddRange(AddListViewSubItems(current, artifact));
                    listView.Items.Add(current);
                }

                //Sort
                listView.ResetColumnOrder();
                listView.Sort("Name", new PresLib.ListViewColumnSorter
                {
                    Order = SortOrder.Ascending
                },isDocumentFirst);
            }
        }

        public static void AttachChildren(this ListView listView, List<Facade.Artifact.Dto> nodeList, Boolean isDocumentFirst)
        {
            listView.Items.Clear();
            if (nodeList != null && nodeList.Count > 0)
            {
                foreach (Facade.Artifact.Dto artifact in nodeList)
                {
                    ListViewItem current = new ListViewItem
                    {
                        Text = artifact.FileName,
                        Tag = artifact,
                        ImageIndex = artifact.Style == Facade.Artifact.Type.Folder ? 0 : 2,
                    };
                    if (artifact.Style == Facade.Artifact.Type.Document) current.Text += "." + artifact.Extension;
                    current.SubItems.AddRange(AddListViewSubItems(current, artifact));
                    listView.Items.Add(current);
                }

                //Sort
                listView.ResetColumnOrder();
                listView.Sort("Name", new PresLib.ListViewColumnSorter
                {
                    Order = SortOrder.Ascending
                },isDocumentFirst);
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

        public static void Sort(this ListView listView, String columnHeaderCaption, PresLib.ListViewColumnSorter columnSorter, Boolean isDocumentFirst)
        {
            listView.ResetColumnHeader();
            //listView.ListViewItemSorter = new PresLib.ListViewColumnSorter
            //{
            //    Order = columnSorter.Order
            //};
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                if (listView.Columns[i].Text == columnHeaderCaption)
                {
                    columnSorter.SortColumn = i;

                    // Reverse the current sort direction for this column.
                    listView.Columns[columnSorter.SortColumn].ImageKey = (columnSorter.Order == SortOrder.Ascending) ? "Down" : "Up";
                    //if (columnSorter.Order == SortOrder.Ascending)
                    //{
                    //    listView.Columns[columnSorter.SortColumn].ImageKey = "Down";
                    //}
                    //else
                    //{
                    //    listView.Columns[columnSorter.SortColumn].ImageKey = "Up";
                    //}

                    // Perform the sort with these new sort options.
                    //listView.Sort();

                    SortItems(listView, isDocumentFirst, i, columnSorter.Order == SortOrder.Ascending);
                    break;
                }
            }
        }

        private static void SortItems(ListView lsvContainer, Boolean isDocumentFirst,int sortColumnIndex ,Boolean sortOrderAsc)
        {
            List<ListViewItem> folder = new List<ListViewItem>();
            List<ListViewItem> document = new List<ListViewItem>();

            for (int i = 0; i < lsvContainer.Items.Count; i++)
            {
                if ((lsvContainer.Items[i].Tag as Facade.Artifact.Dto).Style == Facade.Artifact.Type.Folder)
                    folder.Add(lsvContainer.Items[i]);
                else
                    document.Add(lsvContainer.Items[i]);
            }

            lsvContainer.Items.Clear();

            folder = Sort(sortOrderAsc, sortColumnIndex, folder);
            document = Sort(sortOrderAsc, sortColumnIndex, document);

            if (isDocumentFirst)
            {
                foreach (ListViewItem item in document)
                    lsvContainer.Items.Add(item);

                foreach (ListViewItem item in folder)
                    lsvContainer.Items.Add(item);
            }
            else
            {
                foreach (ListViewItem item in folder)
                    lsvContainer.Items.Add(item);

                foreach (ListViewItem item in document)
                    lsvContainer.Items.Add(item);
            }
        }

        private static List<ListViewItem> Sort(Boolean sortOrderAsc, int sortIndex, List<ListViewItem> lstItems)
        {            
            List<BinAff.Core.Table> lstTableSortText = new List<BinAff.Core.Table>();
            foreach (ListViewItem item in lstItems)
                lstTableSortText.Add(new BinAff.Core.Table
                {
                    Id = (item.Tag as Facade.Artifact.Dto).Id,
                    Name = item.SubItems[sortIndex].Text
                });


            List<String> lstStringSortText = new List<string>();
            foreach (BinAff.Core.Table table in lstTableSortText)
                lstStringSortText.Add(table.Name);

            lstStringSortText.Sort(); // sort in ascending
            
            List<BinAff.Core.Table> sortTableAsc = new List<BinAff.Core.Table>();
            foreach (string text in lstStringSortText)
            {
                for (int i = 0; i < lstTableSortText.Count; i++)
                {
                    if (text == lstTableSortText[i].Name && !isExists(lstTableSortText[i], sortTableAsc))
                    {
                        sortTableAsc.Add(lstTableSortText[i]);
                        break;
                    }
                }
            }


            List<ListViewItem> lstSortItems = new List<ListViewItem>();
            if (sortOrderAsc)
            {
                for (int i = 0; i < sortTableAsc.Count; i++)
                {
                    for (int j = 0; j < lstItems.Count; j++)
                    {
                        if (sortTableAsc[i].Id == (lstItems[j].Tag as Facade.Artifact.Dto).Id)
                        {
                            lstSortItems.Add(lstItems[j]);
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = sortTableAsc.Count-1; i >= 0; i--)
                {
                    for (int j = 0; j < lstItems.Count; j++)
                    {
                        if (sortTableAsc[i].Id == (lstItems[j].Tag as Facade.Artifact.Dto).Id)
                        {
                            lstSortItems.Add(lstItems[j]);
                            break;
                        }
                    }
                }
            }


            return lstSortItems;

        }

        private static Boolean isExists(BinAff.Core.Table item, List<BinAff.Core.Table> lstItem)
        {
            foreach (BinAff.Core.Table table in lstItem)
            {
                if (table.Id == item.Id)
                    return true;
            }

            return false;
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
