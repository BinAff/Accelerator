using System;
using System.Collections.Generic;
using System.Transactions;

using BinAff.Core;
using BinAff.Core.Observer;

using OrgCrys = Crystal.Organization.Component;

namespace Crystal.Organization.Component.Unit
{

    public abstract class Server : ObserverSubjectCrud, IUnit
    {

        private const Int64 OPEN = 10001;
        private const Int64 CLOSE = 10002;

        public Server(Data data)
            : base(data)
        {

        }

        protected override void CreateChildren()
        {
            base.CreateChildren();
            base.AddChild(new Status.Server((this.Data as Data).Status)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChild(new Type.Server((this.Data as Data).Type)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
            base.AddChildren(new ClosureReason.Server(null)
            {
                Type = ChildType.Dependent,
            }, (this.Data as Data).ClosureReasonList);
            base.AddChild(new OrgCrys.Server((this.Data as Data).Organization)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Crystal.Organization.Component.Data":
                    return IsOrganizationDeletable((OrgCrys.Data)subject);
                case "Crystal.Organization.Component.Unit.Status.Data":
                    return IsStatusDeletable(subject as Status.Data);
                case "Crystal.Organization.Component.Unit.Type.Data":
                    return IsTypeDeletable((Type.Data)subject);
                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }

        private ReturnObject<Boolean> IsStatusDeletable(Status.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsStatusDeletable(subject));
        }

        private ReturnObject<Boolean> IsTypeDeletable(Type.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsTypeDeletable(subject));
        }

        private ReturnObject<Boolean> IsOrganizationDeletable(OrgCrys.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsOrganizationDeletable(subject));
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

        private String GetMessage(Crystal.Organization.Component.Unit.Data data)
        {
            return "Unit " + (data as Data).Name + " has dependency.";
        }

        #region IUnit

        ReturnObject<Boolean> IUnit.Open()
        {
            return this.Open();
        }

        ReturnObject<Boolean> IUnit.Close()
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
                ICrud crud = new ClosureReason.Server(new ClosureReason.Data()
                {
                    Reason = ((ClosureReason.Data)(this.Data as Data).ClosureReasonList[0]).Reason
                })
                {
                    ParentData = this.Data,
                };
                ReturnObject<Boolean> ret = crud.Save();


                if (ret.Value)
                    retObj.Value = (this.DataAccess as Dao).ModifyStatus(CLOSE);


                if (retObj.Value)
                    retObj.MessageList.Add(new Message()
                    {
                        Category = Message.Type.Information,
                        Description = "Unit is closed successfully."
                    });
                else
                    retObj.MessageList.Add(new Message()
                    {
                        Category = Message.Type.Error,
                        Description = "Error to close Unit."
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

            retObj.Value = (this.DataAccess as Dao).ModifyStatus(OPEN);

            if (retObj.Value)
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Information,
                    Description = "Unit is opened successfully."
                });
            else
                retObj.MessageList.Add(new Message()
                {
                    Category = Message.Type.Error,
                    Description = "Error to opening Unit."
                });

            return retObj;
        }

    }

}
