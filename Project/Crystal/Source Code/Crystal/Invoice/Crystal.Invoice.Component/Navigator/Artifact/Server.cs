using System;

using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Invoice.Component.Navigator.Artifact
{

    public class Server : ArtfComp.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Invoice " + (this.Data as Data).Category.ToString();
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
            return new Invoice.Component.Server(moduleData as Invoice.Component.Data);
        }

    }

}