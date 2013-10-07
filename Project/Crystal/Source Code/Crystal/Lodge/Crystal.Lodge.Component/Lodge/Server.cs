using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;
using System;
using State = Crystal.Configuration.Component.State;

namespace Crystal.Lodge.Component.Lodge
{
    //public class Server : ObserverCrud
    public class Server : Crud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Lodge";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override void CreateChildren()
        {
            base.AddChild(new State.Server(((Data)Data).State)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            });
        }

        protected override ReturnObject<List<BinAff.Core.Data>> ReadAll()
        {
            ReturnObject<List<BinAff.Core.Data>> retList = new ReturnObject<List<BinAff.Core.Data>>
            {
                Value = ((Dao)this.DataAccess).ReadAll()
            };

            foreach (BinAff.Core.Data data in retList.Value)
            {
                ICrud crud = new Server((Data)data);
                crud.Read();
            }
            return retList;
        }

        protected override ReturnObject<BinAff.Core.Data> ReadOwn()
        {
            ReturnObject<BinAff.Core.Data> retObj = new ReturnObject<BinAff.Core.Data>()
            {
                Value = ((Dao)this.DataAccess).Read(),
            };

            if (retObj.Value == null || retObj.Value.Id == 0) retObj.MessageList = new List<Message> { new Message("No data found for " + this.Name, Message.Type.Information) };

            return retObj;
        }

        //protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        //{
        //    switch (subject.GetType().ToString())
        //    {
        //        case "Crystal.Configuration.State.Data":
        //            return IsStateDeletable((Crystal.Configuration.State.Data)subject);
        //        default:
        //            return new ReturnObject<Boolean>
        //            {
        //                MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
        //            };
        //    }
        //}

        private ReturnObject<bool> IsStateDeletable(State.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsStateDeletable(subject));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Lodge defination has dependency: ";
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
