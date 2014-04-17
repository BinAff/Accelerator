using System;
using System.Collections.Generic;

using BinAff.Core;

using GuardianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public abstract class Server : BinAff.Core.Observer.SubjectCrud, IArtifact
    {

        public Server(Data data)
            : base(data)
        {
            
        }

        protected abstract override void Compose();

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

        protected override void CreateChildren()
        {
            base.AddChild(new GuardianAcc.Server(((Data)Data).CreatedBy)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new GuardianAcc.Server(((Data)Data).ModifiedBy)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });

            BinAff.Core.Crud module = this.CreateModuleServerInstance((this.Data as Data).ComponentData);
            module.Type = ChildType.Independent;
            module.IsReadOnly = true;
            base.AddChild(module);
        }

        protected override ReturnObject<bool> DeleteBefore()
        {
            Crud child = this.CreateInstance(this.Data);
            child.Type = ChildType.Dependent;
            base.AddChildren(child, (this.Data as Data).Children);
            return base.DeleteBefore();
        }

        protected abstract BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData);

        ReturnObject<Data> IArtifact.FormTree()
        {
            //TO DO :: Need to add validation later
            Data data = this.Data as Data;
            data.Style = Artifact.Type.Directory;
            data.FileName = data.ComponentDefinition.Name;
            this.FormTree(this.ReadArtifactListForMudule());
            return new ReturnObject<Data>
            {
                Value = data
            };
        }

        /// <summary>
        /// Form artifact tree from database related record
        /// </summary>
        /// <param name="artifactList">List of artifacts</param>
        private void FormTree(List<BinAff.Core.Data> artifactList)
        {
            Rule.Data rule = new Rule.Data { Id = 1 };
            ICrud ruleServer = new Rule.Server(rule);
            ruleServer.Read();
            String moduleSeperator = rule.ModuleSeperator;
            String pathSeperator = rule.PathSeperator;

            //Create root
            List<BinAff.Core.Data> rootList = this.FindRoot(artifactList);
            Data data = this.Data as Data;
            //data.Path = data.Path + moduleSeperator + pathSeperator + pathSeperator + data.FileName + pathSeperator;
            data.Children = new List<BinAff.Core.Data>();
            foreach (Data root in rootList)
            {
                Int64 currentId = root.Id;
                //root.Path = data.Path + root.FileName + pathSeperator;
                root.ParentId = this.Data.Id;
                artifactList.Remove(root);
                //

                List<Data> dumpList = new List<Data>();
                dumpList.Add(root);

                while (true)
                {
                    List<Data> children = this.FindAll(artifactList, currentId);
                    Data parent = dumpList.Find((p) => p.Id == currentId);
                    dumpList.Remove(parent);
                    if (children.Count > 0)
                    {
                        parent.Children = new List<BinAff.Core.Data>();
                        foreach (Data node in children)
                        {
                            //node.Path += parent.Path + node.FileName + pathSeperator;
                            parent.Children.Add(node);
                            artifactList.Remove(node);
                            dumpList.Add(node);
                        }
                    }
                    if (dumpList.Count == 0) break;
                    currentId = dumpList[0].Id;
                }
                data.Children.Add(root);
            }
        }

        protected virtual List<BinAff.Core.Data> ReadArtifactListForMudule()
        {
            return (this.DataAccess as Dao).ReadArtifactListForMudule();
        }

        private List<BinAff.Core.Data> FindRoot(List<BinAff.Core.Data> dataList)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();
            foreach (BinAff.Core.Data data in dataList)
            {
                if ((data as Data).ParentId == 0)
                    ret.Add(data);
            }
            return ret;
        }

        private List<Data> FindAll(List<BinAff.Core.Data> dataList, Int64 parentId)
        {
            List<Data> matchedList = new List<Data>();
            foreach (BinAff.Core.Data data in dataList)
            {
                if ((data as Data).ParentId == parentId)
                    matchedList.Add(data as Data);
            }
            return matchedList;
        }

    }

}
