using System;

using BinAff.Core;

namespace Crystal.Invoice.Component.AdvancePayment.Navigator.Artifact
{

    public class Server : Crystal.Navigator.Component.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Advance Payment " + (this.Data as Data).Category.ToString();
            (this.Data as Data).Extension = "frm";
            this.DataAccess = new Dao(this.Data as Data);
            this.Validator = new Validator(this.Data as Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data
            {
                Category = (this.Data as Data).Category
            };
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override BinAff.Core.Crud CreateModuleServerInstance(BinAff.Core.Data moduleData)
        {
            return new AdvancePayment.Server(moduleData as AdvancePayment.Data);
        }

        //public Data GetArtifactForInvoiceNumber(String invoiceNumber)
        //{           
        //    return new Dao(this.Data as Data).GetArtifactForInvoiceNumber(invoiceNumber);
        //}

    }

}
