using System;

using BinAff.Core;

namespace Crystal.Accountant.Component.Payment.LineItem
{

    public class Server : BinAff.Core.Observer.ObserverSubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Payment Line Item";
            this.DataAccess = new Dao(this.Data as Data);
            this.Validator = new Validator(this.Data as Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override void CreateChildren()
        {
            base.CreateChildren();

            base.AddChild(new Type.Server((this.Data as Data).Type)
            {
                IsReadOnly = true,
                Type = ChildType.Independent,
            });

        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            //switch (subject.GetType().ToString())
            //{
            //    case "Crystal.Invoice.Component.Payment.Type.Data":
            //        return IsPaymentTypeDeletable((Crystal.Invoice.Component.Payment.Type.Data)subject);

            //    default:
            //        return new ReturnObject<Boolean>
            //        {
            //            MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
            //        };
            //}
            return new ReturnObject<Boolean> { Value = true };
        }

        //private ReturnObject<Boolean> IsPaymentTypeDeletable(Crystal.Invoice.Component.Payment.Type.Data subject)
        //{
        //    return MakeReturnObject(((Dao)this.DataAccess).IsPaymentTypeDeletable(subject));
        //}

        //private ReturnObject<Boolean> MakeReturnObject(List<Data> dataList)
        //{
        //    ReturnObject<Boolean> ret = new ReturnObject<Boolean>();
        //    Int32 count = dataList.Count;
        //    if (count > 0)
        //    {
        //        String msg = "Unable to delete. Some payment(s) has this dependency: ";

        //        ret.MessageList = new List<Message>
        //        {
        //            new Message(msg, Message.Type.Error)
        //        };
        //    }
        //    else
        //    {
        //        ret.Value = true;
        //    }
        //    return ret;
        //}

    }

}