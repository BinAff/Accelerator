namespace Crystal.Customer.Component.Report
{

    public class Server : Crystal.Report.Component.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Report";
            Data data = this.Data as Data;
            this.DataAccess = new Dao(data);
            this.Validator = new Validator(data);
        }
        
        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }

    }

}
