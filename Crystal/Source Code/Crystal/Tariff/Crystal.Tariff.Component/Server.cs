using System.Collections.Generic;

using BinAff.Core;
using System;

namespace Crystal.Tariff.Component
{

    public abstract class Server : BinAff.Core.Observer.ObserverCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();
        protected abstract override BinAff.Core.Data CreateDataObject();
        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            if (subject.GetType().ToString() == GetProductType())
                return IsProductDeletable(subject);
            else
                return new ReturnObject<bool>()
                {
                    MessageList = new List<Message>() { 
                        new Message("Unknown deletable type detected.",Message.Type.Error)
                    }
                };
        }
        
        protected abstract String GetProductType();

        private ReturnObject<Boolean> IsProductDeletable(BinAff.Core.Data subject)
        {
            return MakeReturnObject(((Dao)this.DataAccess).IsProductDeletable(subject));
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

        protected abstract String GetMessage(Data data);
              
    }

}
