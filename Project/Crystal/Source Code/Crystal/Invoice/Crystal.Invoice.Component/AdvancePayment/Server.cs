using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Invoice.Component.AdvancePayment
{

    public class Server : BinAff.Core.Observer.ObserverSubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Advance Payment";
            this.DataAccess = new Dao(this.Data as Data);
            this.Validator = new Validator(this.Data as Data);
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

            base.AddChild(new Payment.Type.Server((base.Data as Data).Type)
            {
                IsReadOnly = true,
                Type = ChildType.Independent,
            });
           
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            switch (subject.GetType().ToString())
            {
                case "Crystal.Invoice.Component.Payment.Type.Data":
                    return IsPaymentTypeDeletable((Crystal.Invoice.Component.Payment.Type.Data)subject);                              

                default:
                    return new ReturnObject<Boolean>
                    {
                        MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
                    };
            }
        }
        
        private ReturnObject<Boolean> IsPaymentTypeDeletable(Crystal.Invoice.Component.Payment.Type.Data subject)
        {
            return MakeReturnObject((this.DataAccess as Dao).IsPaymentTypeDeletable(subject));
        }

        private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
            Int32 count = dataList.Count;
            if (count > 0)
            {
                String msg = "Unable to delete. Some advance payment(s) has this dependency: ";

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

        public List<BinAff.Core.Data> ReadPayment(Int64 invoiceId)
        {
            return new Dao(null).ReadAdvancePayment(invoiceId);
        }

    }

}
