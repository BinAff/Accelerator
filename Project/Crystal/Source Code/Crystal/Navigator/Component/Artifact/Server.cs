using System;
using System.Collections.Generic;

using BinAff.Core;

using AccCrys = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public abstract class Server : BinAff.Core.Observer.SubjectCrud, IArtifact, Observer.IObserver
    {

        public Server(Data data)
            : base(data)
        {
            
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override void CreateChildren()
        {
            base.AddChild(new AccCrys.Server((this.Data as Data).CreatedBy)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
                IsReadOwnData = true,
            });
            base.AddChild(new AccCrys.Server((this.Data as Data).ModifiedBy)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
                IsReadOwnData = true,
            });
            base.AddChild(new Crystal.License.Component.Server((this.Data as Data).ComponentDefinition)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            
            Crud comp = this.CreateComponentServerInstance((this.Data as Data).ComponentData);
            comp.Type = ChildType.Independent;
            comp.IsReadOnly = base.actionType != Action.Delete;
            base.AddChild(comp);
        }

        protected override ReturnObject<Boolean> DeleteBefore()
        {
            Crud child = this.CreateInstance(this.Data);
            child.Type = ChildType.Dependent;
            base.AddChildren(child, (this.Data as Data).Children);
            return base.DeleteBefore();
        }

        protected override ReturnObject<Boolean> DeleteAfter()
        {
            if ((this.Data as Data).ComponentData != null && (this.Data as Data).ComponentData.Id > 0)
            {
                return (this.CreateComponentServerInstance((this.Data as Data).ComponentData) as ICrud).Delete();
            }
            return base.DeleteAfter();
        }

        protected abstract BinAff.Core.Crud CreateComponentServerInstance(BinAff.Core.Data componentData);

        protected abstract BinAff.Core.Data CreateComponentDataObject();

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

        ReturnObject<Data> IArtifact.ReadWithParent()
        {
            ReturnObject<BinAff.Core.Data> comp = this.Read();
            ReturnObject<Data> ret = new ReturnObject<Data>
            {
                Value = comp.Value as Data,
                MessageList = comp.MessageList,
            };
            if (ret.HasError() || (this.Data as Data).ParentId == null) return ret;
            Data parentData = this.CreateDataObject() as Data;
            parentData.Id = (Int64)(this.Data as Data).ParentId;
            parentData.Category = (this.Data as Data).Category;
            ReturnObject<BinAff.Core.Data> parentRet = (this.CreateInstance(parentData) as ICrud).Read();
            if (parentRet.MessageList != null && parentRet.MessageList.Count > 0)
            {
                if (ret.MessageList == null) ret.MessageList = new List<Message>();
                ret.MessageList.AddRange(parentRet.MessageList);
            }
            if (!parentRet.HasError())
            {
                ret.Value.Parent = parentData;
            }
            return ret;
        }

        Int64 IArtifact.ReadComponentLink()
        {
            return (this.DataAccess as Dao).ReadComponentLink();
        }

        ReturnObject<Boolean> IArtifact.CreateAttachmentLink(Data attachment)
        {
            return this.CreateAttachmentLink(attachment);
        }

        ReturnObject<List<Data>> IArtifact.ReadAttachmentLink()
        {
            return this.ReadAttachmentLink();
        }

        ReturnObject<Boolean> IArtifact.DeleteAttachmentLink(Data attachment)
        {
            return this.DeleteAttachmentLink(attachment);
        }

        ReturnObject<Server> IArtifact.GetAttachmentServer(Data attachment)
        {
            return new ReturnObject<Server>
            {
                Value = this.GetAttachmentServer(attachment),
            };
        }

        ReturnObject<Boolean> IArtifact.UpdaterModuleArtifactLink()
        {
            return new ReturnObject<Boolean>
            {
                Value = (this.DataAccess as Dao).UpdateComponentLink()
            };
        }

        ReturnObject<Data> IArtifact.ReadForComponent()
        {
            (this.DataAccess as Dao).ReadForComponent();
            //return new ReturnObject<Data>
            //{
            //    Value = this.Data as Data
            //};
            return base.Read().Convert<Data>();
        }

        protected virtual ReturnObject<Boolean> CreateAttachmentLink(Data attachment)
        {
            if (!(this.Data as Data).IsAttachmentSupported)
            {
                return new ReturnObject<Boolean>
                {
                    MessageList = new List<Message>
                    {
                        new Message("Attachment not supported", Message.Type.Information),
                    }
                };
            }
            ReturnObject<Boolean> ret = new ReturnObject<bool>
            {
                Value = (this.DataAccess as Dao).CreateAttachmentLink(attachment)
            };
            if (ret.Value)
            {
                ret.MessageList = new List<Message>
                {
                    new Message("Attachment linked successfully.", Message.Type.Error)
                };
            }
            else
            {
                ret.MessageList = new List<Message>
                {
                    new Message("Unable to link attachment.", Message.Type.Error)
                };
            }
            return ret;
        }

        private ReturnObject<List<Data>> ReadAttachmentLink()
        {
            if (!(this.Data as Data).IsAttachmentSupported)
            {
                return new ReturnObject<List<Data>>
                {
                    MessageList = new List<Message>
                    {
                        new Message("Attachment not supported", Message.Type.Information),
                    }
                };
            }
            return new ReturnObject<List<Data>>
            {
                Value = (this.DataAccess as Dao).ReadAttachmentLink()
            };
        }

        private ReturnObject<Boolean> DeleteAttachmentLink(Data attachment)
        {
            if (!(this.Data as Data).IsAttachmentSupported)
            {
                return new ReturnObject<Boolean>
                {
                    MessageList = new List<Message>
                    {
                        new Message("Attachment not supported", Message.Type.Information),
                    }
                };
            }
            ReturnObject<Boolean> ret = new ReturnObject<bool>
            {
                Value = (this.DataAccess as Dao).DeleteAttachmentLink(attachment)
            };
            if (ret.Value)
            {
                ret.MessageList = new List<Message>
                {
                    new Message("Attachment link deleted successfully.", Message.Type.Information)
                };
            }
            else
            {
                ret.MessageList = new List<Message>
                {
                    new Message("Unable to delete attachment link.", Message.Type.Error)
                };
            }
            return ret;
        }

        protected virtual Server GetAttachmentServer(Data attachment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Form artifact tree from database related record
        /// </summary>
        /// <param name="artifactList">List of artifacts</param>
        private void FormTree(List<BinAff.Core.Data> artifactList)
        {
            //Create root
            List<BinAff.Core.Data> rootList = this.FindRoot(artifactList);
            Data data = this.Data as Data;
            data.Children = new List<BinAff.Core.Data>();
            foreach (Data root in rootList)
            {
                Int64 currentId = root.Id;
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
                if ((data as Data).ParentId == null)
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

        #region IObserver

        ReturnObject<Boolean> Observer.IObserver.UpdateArtifactComponentLink(Data subject)
        {
            Boolean ret = (this.DataAccess as Dao).UpdateComponentLink();
            if (ret) this.Read();
            return new ReturnObject<Boolean>
            {
                Value = ret
            };
        }

        BinAff.Core.ReturnObject<Boolean> Observer.IObserver.UpdateAfterComponentUpdate(Data subject)
        {
            BinAff.Core.ReturnObject<Boolean> ret = this.Update();
            if (!ret.HasError())
            {
                this.Read();
            }
            return ret;
        }

        #endregion

    }

}