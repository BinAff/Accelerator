using BinAff.Core;

namespace Crystal.Customer.Component.Report.Navigator.Artifact
{

    public class Server : Crystal.Report.Component.Navigator.Artifact.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Customer Report";
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
            return new Customer.Component.Report.Server(componentData as Customer.Component.Report.Data);
        }

        protected override BinAff.Core.Data CreateComponentDataObject()
        {
            return new Customer.Component.Report.Data();
        }

        protected override ICrud GetComponentServer()
        {
            return new Customer.Component.Report.Server(new Customer.Component.Report.Data
            {
                Id = (this.Data as Data).ComponentData.Id
            });
        }

    }

}