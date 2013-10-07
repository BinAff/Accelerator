using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Navigator.Properties;

using Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component
{

    public class Artifact
    {

        /// <summary>
        /// Artifact identifier
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// Name of Artifact
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// File name associaated with Artifact
        /// </summary>
        public String FileName { get; set; }
        
        /// <summary>
        /// Virtual path of Artifact
        /// </summary>
        public String Path { get; set; }

        /// <summary>
        /// Type of Arctifact
        /// </summary>
        public Type Style { get; set; }

        /// <summary>
        /// Version number
        /// </summary>
        public Int32 Version { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<Artifact> Children { get; set; }

        /// <summary>
        /// Form artifact tree from database related record
        /// </summary>
        /// <param name="dataList"></param>
        public void FormTree(List<DBNode> dataList)
        {
            //Create root
            DBNode root = dataList.Find((p) => p.ParentId == 0);
            Int32 currentId = this.Id = root.Id;
            this.FileName = ".";
            this.Style = root.Style;
            this.Path = root.Name + Rule.Data.ModuleSeperator;
            dataList.Remove(root);
            //

            List<Artifact> dumpList = new List<Artifact>();
            dumpList.Add(this);

            while (true)
            {
                List<DBNode> children = dataList.FindAll((p) => p.ParentId == currentId);
                Artifact parent = dumpList.Find((p) => p.Id == currentId);
                dumpList.Remove(parent);
                if (children.Count > 0)
                {
                    parent.Children = new List<Artifact>();
                    foreach (DBNode node in children)
                    {
                        Artifact temp = CreateNode(node);
                        temp.Path = temp.Style == Type.Directory ? parent.Path + node.Name + Rule.Data.PathSeperator : parent.Path;                        
                        parent.Children.Add(temp);
                        dataList.Remove(node);
                        dumpList.Add(temp);
                    }
                }
                if (dumpList.Count == 0) break;
                currentId = dumpList[0].Id;
            }
        }

        /// <summary>
        /// Create nodes for TreeView
        /// </summary>
        /// <returns></returns>
        public TreeNode[] CreateTreeNodes()
        {
            TreeNode[] tree = null;
            if (this.Children != null && this.Children.Count > 0)
            {
                tree = new TreeNode[this.Children.FindAll((p) => (p.Style == Type.Directory)).Count]; //Consider only directory
                Int32 i = 0;
                foreach (Artifact artf in this.Children)
                {
                    if (artf.Style != Type.Directory) break; //If artifact is not style of Directory, no need to create the node

                    tree[i] = (artf.Children != null && artf.Children.Count > 0) ? //If there is more that one child
                        new TreeNode(artf.FileName, artf.CreateTreeNodes()) : //Add children also
                        new TreeNode(artf.FileName);
                    tree[i].Name = artf.Style == Type.Directory ? artf.Path : artf.Path + artf.FileName + Rule.Data.PathSeperator;
                    tree[i++].Tag = artf;

                }
            }
            return tree;
        }        

        private Artifact CreateNode(DBNode dbNode)
        {
            return new Artifact
            {
                Id = dbNode.Id,
                FileName = dbNode.Name,
                Style = dbNode.Style,
                CreatedBy = dbNode.CreatedBy,
                CreatedAt = dbNode.CreatedAt,
                ModifiedBy = dbNode.ModifiedBy,
                ModifiedAt = dbNode.ModifiedAt,
                Version = dbNode.Version //Mandatory
            };
        }

        public enum Type
        {
            Document,
            Directory
        }

        public class DBNode
        {

            public Int32 Id { get; set; }
            public String Name { get; set; }
            public Type Style { get; set; }
            public Int32 ParentId { get; set; }

            /// <summary>
            /// Version number
            /// </summary>
            public Int32 Version { get; set; }
            public User CreatedBy { get; set; }
            public User ModifiedBy { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime ModifiedAt { get; set; }

        }

    }

}
