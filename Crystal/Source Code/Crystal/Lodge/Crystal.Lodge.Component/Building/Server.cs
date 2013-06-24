using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;
using System.Transactions;

namespace Crystal.Lodge.Component.Building
{
    public class Server : ObserverSubjectCrud, IBuilding
    {
        private const Int64 OPEN = 10001;
        private const Int64 CLOSE = 10002;

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Building";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
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
            base.CreateChildren();

            base.AddChildren(new Floor.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).FloorList);
            base.AddChild(new Type.Server(((Data)this.Data).Type)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Status.Server(((Data)this.Data).Status)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChildren(new ClosureReason.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = true,
            }, ((Data)base.Data).ClosureReasonList);
            base.AddChild(new Organization.Component.Server(((Data)this.Data).Organization)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }        

        #region IBuilding
        
        ReturnObject<Boolean> IBuilding.Open()
        {
            return this.Open();
        }

        ReturnObject<Boolean> IBuilding.Close()
        {
            return this.Close();
        }

        #endregion

        private ReturnObject<Boolean> Close()
        {

            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = false,
                MessageList = new List<Message>()
            };

            using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            {
                ICrud crud = new Lodge.Component.Building.ClosureReason.Server(new Lodge.Component.Building.ClosureReason.Data()
                {
                    Reason = ((Lodge.Component.Building.ClosureReason.Data)((Data)this.Data).ClosureReasonList[0]).Reason
                })
                {
                    ParentData = this.Data,
                };
                ReturnObject<Boolean> ret = crud.Save();

                
                if (ret.Value)
                    retObj.Value = new Dao((Data)this.Data).ModifyStatus(CLOSE);
            

                if (retObj.Value)
                    retObj.MessageList.Add(new Message()
                    {
                        Category = Message.Type.Information,
                        Description = "Building is closed successfully."
                    });
                else               
                    retObj.MessageList.Add(new Message()
                    {
                        Category = Message.Type.Error,
                        Description = "Error to close building."
                    });                  
                

                if (retObj.Value) T.Complete();
            }

            return retObj;
        }

        private ReturnObject<Boolean> Open()
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = false,
                MessageList = new List<Message>()
            };

            retObj.Value = new Dao((Data)this.Data).ModifyStatus(OPEN);

            if (retObj.Value)
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Information,
                    Description = "Building is opened successfully."
                });
            else
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Error,
                    Description = "Error to opening building."
                });

            return retObj;
        }
        
        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Crystal.Organization.Component.Data":
                    return IsOrganizationDeletable((Crystal.Organization.Component.Data)subject);
                case "Crystal.Lodge.Component.Building.Status.Data":
                    return IsStatusDeletable((Crystal.Lodge.Component.Building.Status.Data)subject);
                case "Crystal.Lodge.Component.Building.Type.Data":
                    return IsTypeDeletable((Crystal.Lodge.Component.Building.Type.Data)subject);
               
                    
                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }

        private ReturnObject<Boolean> IsOrganizationDeletable(Crystal.Organization.Component.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsOrganizationDeletable(subject));
        }

        private ReturnObject<Boolean> IsStatusDeletable(Crystal.Lodge.Component.Building.Status.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsStatusDeletable(subject));
        }

        private ReturnObject<Boolean> IsTypeDeletable(Crystal.Lodge.Component.Building.Type.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsTypeDeletable(subject));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        { 
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following " + this.Name + " has this dependency: ";
     
                foreach (Data data in dataList)               
                    msg += GetMessage(data);               
               
                ret.MessageList = new List<Message>
                {
                    new Message(msg, Message.Type.Error)
                };
            }
            else
            {
                ret.Value = true;
            }
            return ret;
        }
        
        private String GetMessage(Crystal.Lodge.Component.Building.Data data)
        {
            Data d = data as Data;
            return "Building " + data.Name + " has dependency.";
        }

    }

}
