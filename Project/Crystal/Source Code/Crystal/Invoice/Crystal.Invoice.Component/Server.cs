using System;

using BinAff.Core;
using CrysArtfObserver = Crystal.Navigator.Component.Artifact.Observer;

namespace Crystal.Invoice.Component
{

    //public class Server : BinAff.Core.Observer.ObserverSubjectCrud, IInvoice
    public class Server : CrysArtfObserver.DocumentComponent, IInvoice
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Invoice";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
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
            //base.CreateChildren();
            base.AddChildren(new LineItem.Server(null)
            {
                Type = ChildType.Dependent,
                IsReadOnly = false,
            }, ((Data)base.Data).LineItem);
        }

        protected override ReturnObject<Boolean> IsSubjectDeletable(BinAff.Core.Data subject)
        {            
            return new ReturnObject<Boolean>
            {
                MessageList = { new Message("Unknown deletable type detected.", Message.Type.Error) }
            };
            
        }

        //ReturnObject<List<BinAff.Core.Data>> IInvoice.GetList(DateTime startDate, DateTime endDate)
        //{
        //    throw new NotImplementedException();
        //}


        //private ReturnObject<List<BinAff.Core.Data>> GetSalesData(DateTime startDate, DateTime endDate)
        //{
        //    ReturnObject<List<BinAff.Core.Data>> retList = new ReturnObject<List<BinAff.Core.Data>>
        //    {
        //        Value = ((Dao)this.DataAccess).GetSalesData(startDate, endDate)
        //    };

        //    return retList;
        //}

        //ReturnObject<List<Data>> IInvoice.GetList(DateTime startDate, DateTime endDate)
        //{
        //    throw new NotImplementedException();
        //}

        ReturnObject<Data> IInvoice.GetInvoice(string invoiceNumber)
        {   
            base.Data.Id = new Dao((Data)this.Data).ReadInvoiceId(invoiceNumber);
            return new ReturnObject<Data> 
            {
                Value = base.Read().Value as Data
            };
        }

        Int64 IInvoice.GetInvoiceId(string invoiceNumber)
        {
            return new Dao((Data)this.Data).ReadInvoiceId(invoiceNumber);            
        }

    }

}
