using System;

using BinAff.Core;

using NavCrys = Crystal.Navigator.Component;

namespace Crystal.Accountant.Component.Invoice.Report.Navigator.Artifact
{

    public class Server : Crystal.Report.Component.Navigator.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Invoice Report";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
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

        protected override BinAff.Core.Crud CreateComponentServerInstance(BinAff.Core.Data componentData)
        {            
            return new Report.Server(componentData as Report.Data);
        }

        protected override BinAff.Core.Data CreateComponentDataObject()
        {
            return new Report.Data();
        }

        protected override ICrud GetComponentServer()
        {
            return new Report.Server(new Report.Data
            {
                Id = (this.Data as Data).ComponentData.Id
            });
        }

    }

}