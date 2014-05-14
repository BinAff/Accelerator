using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PresLib = BinAff.Presentation.Library;

using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ModFac = Vanilla.Utility.Facade.Module;

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

        public static void Sort(this TreeView treeView, TreeNode treeNode)
        {
            treeView.BeginUpdate();
            
            TreeNode[] childNodes = new TreeNode[treeNode.Nodes.Count];
            treeNode.Nodes.CopyTo(childNodes, 0);       

            List<BinAff.Core.Table> lstTableSortText = new List<BinAff.Core.Table>();
            for (int i = 0; i < childNodes.Length; i++)
            {
                lstTableSortText.Add(new BinAff.Core.Table
                {
                    Id = (childNodes[i].Tag as Vanilla.Utility.Facade.Artifact.Dto).Id,
                    Name = (childNodes[i].Tag as Vanilla.Utility.Facade.Artifact.Dto).FileName
                });
            }
            lstTableSortText = Common.SortTable(lstTableSortText, true);

            TreeNode[] sortNodes = new TreeNode[treeNode.Nodes.Count];
            int Index = 0;
            foreach (BinAff.Core.Table table in lstTableSortText)
            {
                for (int i = 0; i < childNodes.Length; i++)
                {
                    if (table.Id == (childNodes[i].Tag as Vanilla.Utility.Facade.Artifact.Dto).Id)
                    {
                        sortNodes[Index] = childNodes[i];
                        Index++;
                        break;
                    }
                }
            }

            treeNode.Nodes.Clear();
            treeNode.Nodes.AddRange(sortNodes);

            treeView.EndUpdate();
        }

        public static void AddNode(this TreeView treeView, TreeNode parentNode, TreeNode childNode, String pathSeperator, String moduleSeparator)
        {
            TreeNode childNodeClone = childNode.Clone() as TreeNode;

            //update the path of child node artifact
            Facade.Artifact.Dto parentNodeArtifact = new Facade.Artifact.Dto();
            String pathOfParent = String.Empty;


            if (parentNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
            {
                parentNodeArtifact = (parentNode.Tag as Facade.Module.Dto).Artifact;
                pathOfParent += parentNodeArtifact.Path + moduleSeparator + pathSeperator + pathSeperator + parentNode.Text + pathSeperator;
            }
            else
            {
                parentNodeArtifact = parentNode.Tag as Facade.Artifact.Dto;
                pathOfParent += parentNodeArtifact.Path;
            }

            Facade.Artifact.Dto childNodeArtifact = new Facade.Artifact.Dto();
            if (childNodeClone.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                childNodeArtifact = (childNodeClone.Tag as Facade.Module.Dto).Artifact;
            else
                childNodeArtifact = childNodeClone.Tag as Facade.Artifact.Dto;

            Facade.Artifact.Dto childNodeArtifactClone = new ArtfFac.Server(null).CloneArtifact(childNodeArtifact);
            new ArtfFac.Server(null).UpdateArtifactPath(pathOfParent, childNodeArtifactClone, pathSeperator);          

            if (parentNodeArtifact.Children == null)
                parentNodeArtifact.Children = new List<Facade.Artifact.Dto>();

            parentNodeArtifact.Children.Add(childNodeArtifactClone);
            childNodeArtifactClone.Parent = parentNodeArtifact;

            childNodeClone.Tag = childNodeArtifactClone;
            UpdateChildNodeTag(childNodeClone);

            parentNode.Nodes.Add(childNodeClone);
            treeView.Sort(parentNode);
            treeView.Refresh();
        }

        public static void RemoveNode(this TreeView treeView, TreeNode node)
        {
            TreeNode parentNode = node.Parent;
            Facade.Artifact.Dto parentNodeArtifact = new Facade.Artifact.Dto();
            Facade.Artifact.Dto nodeArtifact = new Facade.Artifact.Dto();   

            if (parentNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")            
                parentNodeArtifact = (parentNode.Tag as Facade.Module.Dto).Artifact;
            else            
                parentNodeArtifact = parentNode.Tag as Facade.Artifact.Dto;

            if (node.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                nodeArtifact = (node.Tag as Facade.Module.Dto).Artifact;
            else
                nodeArtifact = node.Tag as Facade.Artifact.Dto;

            parentNodeArtifact.Children.Remove(nodeArtifact);
            treeView.Nodes.Remove(node);
        }

        public static void AddArtifact(this TreeView treeView, TreeNode node, Facade.Artifact.Dto artifact, String pathSeperator, String moduleSeparator)
        {
            Facade.Artifact.Dto artifactClone = new ArtfFac.Server(null).CloneArtifact(artifact);
            String pathOfParent = String.Empty;

            //remove artifact from parent
            String selectedNodePath = artifact.Path.Substring(artifact.Path.IndexOf(moduleSeparator) + 3);

            if (artifactClone.Style == Facade.Artifact.Type.Document)
                selectedNodePath = selectedNodePath.Substring(0, selectedNodePath.LastIndexOf(pathSeperator)) + pathSeperator;
            
            TreeNode currentNode = FindTreeNodeFromPath(treeView, treeView.Nodes, selectedNodePath, pathSeperator);
            Facade.Artifact.Dto currentNodeArtifact = new Facade.Artifact.Dto();
            if (currentNode.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                currentNodeArtifact = (currentNode.Tag as Facade.Module.Dto).Artifact;
            else
                currentNodeArtifact = currentNode.Tag as Facade.Artifact.Dto;

            currentNodeArtifact.Children.Remove(artifact);


            //add artifact to node
            Facade.Artifact.Dto nodeArtifact = new Facade.Artifact.Dto();
            if (node.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
            {
                nodeArtifact = (node.Tag as Facade.Module.Dto).Artifact;
                pathOfParent += nodeArtifact.Path + moduleSeparator + pathSeperator + pathSeperator + node.Text + pathSeperator;
            }
            else
            {
                nodeArtifact = node.Tag as Facade.Artifact.Dto;
                pathOfParent += nodeArtifact.Path;
            }

            new ArtfFac.Server(null).UpdateArtifactPath(pathOfParent, artifactClone, pathSeperator);
            artifactClone.Parent = nodeArtifact;

            if (nodeArtifact.Children == null)
                nodeArtifact.Children = new List<Facade.Artifact.Dto>();

            nodeArtifact.Children.Add(artifactClone);

            
        }

        private static void UpdateTagArtifact(String pathOfParent, TreeNode node, String pathSeperator)
        {
            Facade.Artifact.Dto nodeArtifact = node.Tag as Facade.Artifact.Dto;
            new ArtfFac.Server(null).UpdateArtifactPath(pathOfParent, nodeArtifact, pathSeperator);            

            //update the tag object
            foreach (TreeNode tNode in node.Nodes)
                UpdateTagArtifact(nodeArtifact.Path, tNode, pathSeperator);                
           
        }

        private static void UpdateChildNodeTag(TreeNode Node)
        {
            Facade.Artifact.Dto artifactDto;
            if (Node.Nodes != null && Node.Nodes.Count > 0)
            {
                if (Node.Tag.GetType().FullName == "Vanilla.Utility.Facade.Module.Dto")
                    artifactDto = (Node.Tag as Facade.Module.Dto).Artifact;
                else
                    artifactDto = Node.Tag as Facade.Artifact.Dto;


                foreach (TreeNode node in Node.Nodes)
                {
                    foreach (Facade.Artifact.Dto childArtifact in artifactDto.Children)
                    {
                        if (node.Text == childArtifact.FileName)
                        {
                            node.Tag = childArtifact;
                            if (node.Nodes != null && node.Nodes.Count > 0)
                                UpdateChildNodeTag(node);

                            break;
                        }
                    }
                }
            }
        }

        //need to remove the method from Register.cs
        public static TreeNode FindTreeNodeFromPath(this TreeView treeView, TreeNodeCollection treeNodes, String path, String pathSeperator)
        {

            String text = path.Substring(0, path.IndexOfAny(pathSeperator.ToCharArray()));
            path = path.Substring(path.IndexOfAny(pathSeperator.ToCharArray()) + 1);
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
                        return FindTreeNodeFromPath(treeView, node.Nodes, path, pathSeperator);
                    }
                }
            }
            return null;
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
                    Name = "Type",
                    Text = artifact.Style.ToString(),
                },
                new ListViewItem.ListViewSubItem(node, "Version")
                {
                    Name = "Version",
                    Text = artifact.Version.ToString(),
                },
                new ListViewItem.ListViewSubItem(node, "Created By")
                {
                    Name = "Created By",
                    Text = artifact.CreatedBy == null ? String.Empty : (artifact.CreatedBy as BinAff.Core.Table).Name,
                },
                new ListViewItem.ListViewSubItem(node, "Created At")
                {
                    Name = "Created At",
                    Text = artifact.CreatedAt.ToString(),
                },
                new ListViewItem.ListViewSubItem(node, "Modified By")
                {
                    Name = "Modified By",
                    Text = artifact.ModifiedBy == null ? String.Empty : (artifact.ModifiedBy as BinAff.Core.Table).Name,
                },
                new ListViewItem.ListViewSubItem(node, "Modified At")
                {
                    Name = "Modified At",
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

            lstTableSortText = Common.SortTable(lstTableSortText, sortOrderAsc);
           
            List<ListViewItem> lstSortItems = new List<ListViewItem>();    
            foreach (BinAff.Core.Table table in lstTableSortText)
            {
                for (int i = 0; i < lstItems.Count; i++)
                {
                    if (table.Id == (lstItems[i].Tag as Vanilla.Utility.Facade.Artifact.Dto).Id)
                    {
                        lstSortItems.Add(lstItems[i]);                       
                        break;
                    }
                }
            }

            return lstSortItems;

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

        public static ListViewItem FindNode(this ListView listView, Facade.Artifact.Dto artifact)
        {
            ListViewItem ret = null;
            foreach (ListViewItem item in listView.Items)
            {
                if ((item.Tag as Facade.Artifact.Dto).Id == artifact.Id)
                {
                    return item;
                }
            }
            return ret;
        }

    }

    public static class ListViewItemExtender
    {

        public static void ChangeListViewSubItems(this ListViewItem node, Facade.Artifact.Dto artifact)
        {
            node.SubItems["Type"].Text = artifact.Style.ToString();
            node.SubItems["Version"].Text = artifact.Version.ToString();
            node.SubItems["Created By"].Text = artifact.CreatedBy.Name;
            node.SubItems["Created At"].Text = artifact.CreatedAt.ToString();
            node.SubItems["Modified By"].Text = artifact.ModifiedBy.Name;
            node.SubItems["Modified At"].Text = artifact.ModifiedAt.ToString();
        }

    }

    public static class Common
    {
        public static List<BinAff.Core.Table> SortTable(List<BinAff.Core.Table> lstTableSortText, Boolean isAscending)
        {
            List<BinAff.Core.Table> sortTable = new List<BinAff.Core.Table>();

            List<String> lstStringSortText = new List<string>();
            foreach (BinAff.Core.Table table in lstTableSortText)
                lstStringSortText.Add(table.Name);

            lstStringSortText.Sort(); // sort ascending [default behaviour]
            
            if (isAscending)
            {
                foreach (string text in lstStringSortText)
                {
                    for (int i = 0; i < lstTableSortText.Count; i++)
                    {
                        if (text == lstTableSortText[i].Name && !isExists(lstTableSortText[i], sortTable))
                        {
                            sortTable.Add(lstTableSortText[i]);
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int j = lstStringSortText.Count - 1; j >= 0; j--)
                {
                    for (int i = 0; i < lstTableSortText.Count; i++)
                    {
                        if (lstStringSortText[j] == lstTableSortText[i].Name && !isExists(lstTableSortText[i], sortTable))
                        {
                            sortTable.Add(lstTableSortText[i]);
                            break;
                        }
                    }
                }              
            }
            

            return sortTable;

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
              
        //public static void UpdateArtifactPath(String pathOfParent, Facade.Artifact.Dto artifactDto, String pathSeperator)
        //{
        //    if(artifactDto.Style == Facade.Artifact.Type.Folder)
        //        artifactDto.Path = pathOfParent + artifactDto.FileName + pathSeperator;
        //    else
        //        artifactDto.Path = pathOfParent + artifactDto.FileName;

        //    if (artifactDto.Children != null && artifactDto.Children.Count > 0)
        //    {
        //        foreach (Facade.Artifact.Dto dto in artifactDto.Children)
        //            UpdateArtifactPath(artifactDto.Path, dto, pathSeperator);
        //    }
        //}

        ////need to remove from Vanilla.Navigator.Facade.Register
        //public static Facade.Artifact.Dto CloneArtifact(Facade.Artifact.Dto dto)
        //{
        //    return new Facade.Artifact.Dto
        //    {
        //        Id = dto.Id,
        //        FileName = dto.FileName,
        //        Path = dto.Path,
        //        Style = dto.Style,
        //        Category = dto.Category,
        //        Version = dto.Version,
        //        CreatedBy = dto.CreatedBy,
        //        ModifiedBy = dto.ModifiedBy,
        //        CreatedAt = dto.CreatedAt,
        //        ModifiedAt = dto.ModifiedAt,
        //        Children = dto.Children == null ? null : GetChildren(dto),
        //        Module = dto.Module == null ? null : new BinAff.Facade.Library.Dto
        //        {
        //            Id = dto.Module.Id,
        //            Action = dto.Module.Action
        //        },
        //        Parent = dto.Parent == null ? null : new BinAff.Facade.Library.Dto
        //        {
        //            Id = dto.Parent.Id,
        //            Action = dto.Parent.Action
        //        }
        //    };
        //}

        //private static List<Facade.Artifact.Dto> GetChildren(Facade.Artifact.Dto dto)
        //{
        //    List<Facade.Artifact.Dto> children = dto.Children;
        //    List<Facade.Artifact.Dto> childrenList = new List<Facade.Artifact.Dto>();
        //    for (int i = 0; i < children.Count; i++)
        //    {
        //        Facade.Artifact.Dto clone = CloneArtifact(children[i]);
        //        clone.Parent = dto;
        //        childrenList.Add(clone);
        //    }

        //    return childrenList;
        //}
    }
}
