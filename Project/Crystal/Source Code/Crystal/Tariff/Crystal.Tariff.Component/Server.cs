using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Tariff.Component
{

    public abstract class Server : BinAff.Core.Observer.ObserverCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            if (subject.GetType().ToString() == GetProductType())
            {
                return this.IsProductDeletable(subject);
            }
            else
            {
                return new ReturnObject<Boolean>()
                {
                    MessageList = new List<Message>
                    { 
                        new Message("Unknown deletable type detected.",Message.Type.Error)
                    }
                };
            }
        }
        
        protected abstract String GetProductType();

        protected abstract String GetMessage(Data data);

        private ReturnObject<Boolean> IsProductDeletable(BinAff.Core.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsProductDeletable(subject));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Following " + this.Name + " has this dependency: ";
                foreach (Data data in dataList)
                {
                    msg += GetMessage(data);
                }
                
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