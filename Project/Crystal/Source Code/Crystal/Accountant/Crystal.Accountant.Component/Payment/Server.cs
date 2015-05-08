using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

using ArtfObsCrys = Crystal.Navigator.Component.Artifact.Observer;

namespace Crystal.Accountant.Component.Payment
{

    public class Server : ArtfObsCrys.DocumentComponent, IPayment
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Payment";
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
            base.AddChildren(new LineItem.Server(null)
            {
                IsReadOnly = false,
                Type = ChildType.Dependent,
            }, (this.Data as Data).LineItemList);
            //base.AddChild(new Invoice.Server((base.Data as Data).Invoice)
            //{
            //    IsReadOnly = true,
            //    Type = ChildType.Independent,
            //});
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {
            //switch (subject.GetType().ToString())
            //{
            //    case "Crystal.Accountant.Component.Payment.Type.Data":
            //        return IsPaymentTypeDeletable((Crystal.Accountant.Component.Payment.Type.Data)subject);

            //    default:
            //        return new ReturnObject<Boolean>
            //        {
            //            MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
            //        };
            //}

            return new ReturnObject<Boolean> { Value = true };
        }

        protected override ReturnObject<Boolean> CreateBefore()
        {
            (this.Data as Data).Date = DateTime.Now;
            return base.CreateBefore();
        }

        //private ReturnObject<Boolean> IsPaymentTypeDeletable(Crystal.Accountant.Component.Payment.Type.Data subject)
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

        public List<BinAff.Core.Data> ReadPayment(Int64 invoiceId)
        {
            return new Dao(null).ReadPayment(invoiceId);
        }

        internal String FormatRecieptNumber()
        {
            //Later this will be configurable
            Data data = this.Data as Data;
            if (data == null || data.Date == null) return String.Empty;
            return String.Format("RCPT/{0}-{1}-{2}/{3}",
                data.Date.Year.ToString().Length == 4 ? data.Date.Year.ToString().Remove(0, 2) :
                data.Date.Year.ToString().Length == 2 ? data.Date.Year.ToString() :
                data.Date.Year.ToString().PadLeft(2, '0'),
                data.Date.Month.ToString().PadLeft(2, '0'),
                data.Date.Day.ToString().PadLeft(2, '0'),
                data.SerialNumber.ToString().PadLeft(3, '0'));
        }

        ReturnObject<Boolean> IPayment.AttachInvoice()
        {
            return (base.DataAccess as Dao).AttachInvoice() ?
                new ReturnObject<Boolean>
                {
                    Value = true,
                } :
                new ReturnObject<Boolean>
                {
                    MessageList = new List<Message>
                    {
                        new Message("Unable to attach invoice.", Message.Type.Error),
                    }
                };
        }

    }

}