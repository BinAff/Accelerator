using System;

using BinAff.Core;
using CrysArtfObserver = Crystal.Navigator.Component.Artifact.Observer;
using System.Collections.Generic;

namespace Crystal.Accountant.Component.Invoice
{

    public class Server : CrysArtfObserver.DocumentComponent, IInvoice
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Invoice";
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
            base.AddChildren(new LineItem.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = false,
            }, (base.Data as Data).LineItemList);
            base.AddChildren(new Payment.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = true,
            }, (base.Data as Data).PaymentList);
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {            
            return new ReturnObject<Boolean>
            {
                MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
            };
            
        }
               
        //private ReturnObject<List<BinAff.Core.Data>> GetSalesData(DateTime startDate, DateTime endDate)
        //{
        //    ReturnObject<List<BinAff.Core.Data>> retList = new ReturnObject<List<BinAff.Core.Data>>
        //    {
        //        Value = ((Dao)this.DataAccess).GetSalesData(startDate, endDate)
        //    };

        //    return retList;
        //}

        ReturnObject<Data> IInvoice.GetInvoice(string invoiceNumber)
        {
            base.Data = this.ParseInvoiceNumber(invoiceNumber);
            base.Data.Id = (this.DataAccess as Dao).ReadInvoiceId();
            return new ReturnObject<Data>
            {
                Value = base.Read().Value as Data
            };
        }

        List<Payment.Data> IInvoice.ReadInvoicePayment(string invoiceNumber)
        {
            List<Payment.Data> paymentList = new List<Payment.Data>();
            this.Data = this.ParseInvoiceNumber(invoiceNumber);
            Int64 invoiceId = (this.DataAccess as Dao).ReadInvoiceId();

            if (invoiceId > 0)
            {
                List<BinAff.Core.Data> paymentDataList = new Payment.Server(null).ReadPayment(invoiceId);
                if (paymentDataList != null && paymentDataList.Count > 0)
                {
                    foreach (BinAff.Core.Data data in paymentDataList)
                        paymentList.Add(data as Payment.Data);
                }
                
            }
            return paymentList;
        }

        internal String FormatInvoiceNumber()
        {
            //Later this will be configurable
            Data data = this.Data as Data;
            return String.Format("RCPT/{0}-{1}-{2}/{3}",
                data.Date.Year.ToString().Remove(0, 2),
                data.Date.Month.ToString().PadLeft(2, '0'),
                data.Date.Day.ToString().PadLeft(2, '0'),
                data.SerialNumber.ToString().PadLeft(3, '0'));
        }

        internal Data ParseInvoiceNumber(String invoiceNumber)
        {
            //Later this will be configurable
            String[] tokens = invoiceNumber.Split('/');
            String[] dateTokens = tokens[1].Split('-');
            return new Data
            {
                SerialNumber = Convert.ToInt32(tokens[2]),
                Date = new DateTime(Convert.ToInt32(dateTokens[0]), Convert.ToInt32(dateTokens[1]), Convert.ToInt32(dateTokens[7])),
            };
        }

    }

}
