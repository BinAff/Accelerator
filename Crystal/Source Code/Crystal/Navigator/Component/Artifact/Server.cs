using System;
using System.Collections.Generic;

using BinAff.Core;

using GaurdianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public class Server : BinAff.Core.Observer.SubjectCrud, IArtifact
    {

        public Server(Data data)
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            this.Name = "Artifact";
            this.Validator = new Validator((Data)this.Data);
            this.DataAccess = new Dao((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        protected override void CreateChildren()
        {
            base.AddChild(new GaurdianAcc.Server(((Data)Data).CreatedBy)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new GaurdianAcc.Server(((Data)Data).ModifiedBy)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        ReturnObject<Data> IArtifact.FormTree()
        {
            List<BinAff.Core.Data> dataList = this.ReadAll().Value;
            this.FormTree(dataList);
            //TO DO :: Need to add validation later
            return new ReturnObject<Data>
            {
                Value = this.Data as Data
            };
        }

        /// <summary>
        /// Form artifact tree from database related record
        /// </summary>
        /// <param name="dataList"></param>
        private void FormTree(List<BinAff.Core.Data> dataList)
        {
            Rule.Data rule = new Rule.Data { Id = 1 };
            ICrud ruleServer = new Rule.Server(rule);
            ruleServer.Read();
            String moduleSeperator = rule.ModuleSeperator;
            String pathSeperator = rule.PathSeperator;

            //Create root
            Data root = this.FindRoot(dataList);
            this.Data = root;
            Data data = this.Data as Data;
            Int64 currentId = root.Id;
            data.FileName = ".";
            data.Style = root.Style;
            data.Path = root.FileName + moduleSeperator;
            dataList.Remove(root);
            //

            List<Data> dumpList = new List<Data>();
            dumpList.Add(this.Data as Data);

            while (true)
            {
                List<Data> children = this.FindAll(dataList, currentId);
                Data parent = dumpList.Find((p) => p.Id == currentId);
                dumpList.Remove(parent);
                if (children.Count > 0)
                {
                    parent.Children = new List<Data>();
                    foreach (Data node in children)
                    {
                        //node.Path = temp.Style == Type.Directory ? parent.Path + node.Name + Rule.Data.PathSeperator : parent.Path;
                        node.Path = node.Style == Artifact.Type.Directory ? parent.Path + node.FileName + pathSeperator : parent.Path;
                        parent.Children.Add(node);
                        dataList.Remove(node);
                        dumpList.Add(node);
                    }
                }
                if (dumpList.Count == 0) break;
                currentId = dumpList[0].Id;
            }
        }

        private Data FindRoot(List<BinAff.Core.Data> dataList)
        {
            foreach (BinAff.Core.Data data in dataList)
            {
                if ((data as Data).ParentId == 0)
                    return data as Data;
            }
            return null;
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
