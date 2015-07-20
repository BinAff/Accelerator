using System.Collections.Generic;
using System;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;
using CrysArtfObserver = Crystal.Navigator.Component.Artifact.Observer;

namespace Crystal.Customer.Component.Action
{

    public abstract class Server : CrysArtfObserver.DocumentComponent, IAction
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void CreateChildren()
        {
            base.AddChild(new Status.Server(((Data)this.Data).Status)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            if (subject.GetType() == this.GetProductType())
            {
                return this.IsProductDeletable(subject);
            }
            else if (subject is Crystal.Customer.Component.Action.Status.Data)
            {
                return this.IsStatusDeletable(subject as Status.Data);
            }
            else
            {
                return this.IsDependedDeletable(subject);
            }
        }

        ReturnObject<List<Data>> IAction.Search(Status.Data status, DateTime startDate, DateTime endDate)
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

        ReturnObject<Boolean> IAction.UpdateStatus()
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>
            {
                Value = (this.DataAccess as Dao).UpdateStatus()
            };
            ret.MessageList = new List<Message>();
            if (ret.Value)
                ret.MessageList.Add(new Message("Room reservation status successfully updated", Message.Type.Information));
            else
                ret.MessageList.Add(new Message("Unable to update room reservation status", Message.Type.Error));
            return ret;
        }

        #region Mandatory Hook

        protected abstract Type GetProductType();

        protected abstract String GetMessage(Data data);

        #endregion

        #region Optional Hook

        protected virtual ReturnObject<Boolean> IsDependedDeletable(BinAff.Core.Data subject)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ReturnObject<Boolean> IsProductDeletable(BinAff.Core.Data subject)
        {
            ReturnObject<Boolean> ret = this.MakeReturnObject((this.DataAccess as Dao).IsProductDeletable(subject));
            if (!ret.HasError()) ret = this.IsDependedDeletable(subject);
            return ret;
        }

        private ReturnObject<Boolean> IsStatusDeletable(Status.Data data)
        {
            //Need to implement
            throw new NotImplementedException();
        }

        protected ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete...\n";

                foreach (Data data in dataList)
                {
                    msg += this.GetMessage(data);
                    msg += Environment.NewLine;
                }
                //Show max 4
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

    }

}