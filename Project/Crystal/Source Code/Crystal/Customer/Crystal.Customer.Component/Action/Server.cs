using System.Collections.Generic;
using System;

using BinAff.Core;

namespace Crystal.Customer.Component.Action
{

    public abstract class Server : BinAff.Core.Observer.ObserverSubjectCrud, IAction
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

        protected override void CreateChildren()
        {
            base.CreateChildren();

            base.AddChild(new Status.Server(((Data)this.Data).Status)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        ReturnObject<List<Data>> IAction.Search(Status.Data status, System.DateTime startDate, System.DateTime endDate)
        {
            ReturnObject<List<Data>> ret = new ReturnObject<List<Data>>
            {
                Value = (this.DataAccess as Dao).Search(status, startDate, endDate)
            };
            if (ret.Value == null || ret.Value.Count == 0)
            {
                ret.MessageList = new List<Message> { new Message("No record found", Message.Type.Error) };
            }
            return ret;
        }

        ReturnObject<Boolean> IAction.UpdateStatus(Status.Data status)
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>
            {
                Value = (this.DataAccess as Dao).UpdateStatus(status)
            };
            ret.MessageList = new List<Message>();
            if (ret.Value)
                ret.MessageList.Add(new Message("Room reservation status successfully updated", Message.Type.Information));
            else
                ret.MessageList.Add(new Message("Unable to update room reservation status", Message.Type.Error));
            return ret;
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            if (subject.GetType().ToString() == GetProductType())
            {
                return IsProductDeletable(subject);
            }
            else switch (subject.GetType().ToString())
            {
                case "Crystal.Customer.Component.Action.Status.Data":
                    return IsStatusDeletable((Status.Data)subject);
                default:
                    return new ReturnObject<Boolean>();                    
            }
        }

        private ReturnObject<Boolean> IsProductDeletable(BinAff.Core.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsProductDeletable(subject));
        }

        protected abstract String GetProductType();

        private ReturnObject<Boolean> IsStatusDeletable(Status.Data data)
        {
            throw new NotImplementedException();
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following " + this.Name + " has this dependency: ";
                //Show max 4
                foreach (Data data in dataList)
                {
                    msg += GetMessage(data);
                }
                //for (Int16 i = 0; i < (count > 4 ? 4 : count); i++)
                //{
                //    msg += dataList[i].;
                //    if (i < 3 && i < count - 1) msg += ", ";
                //}
                //if (count > 4) msg += ",...";
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

        protected abstract String GetMessage(Data data);

    }

}
