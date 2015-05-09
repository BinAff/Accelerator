namespace Retinue.Lodge.Component.Taxation
{

    public class Server : Crystal.Accountant.Component.Tax.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Lodge Taxation";
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

    }

}