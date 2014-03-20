
namespace Crystal.Lodge.Component.Taxation
{
    public class Server : Crystal.Invoice.Component.Taxation.Server
    {
        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Lodge Taxation";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        //protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        //{
        //    return new Server((Data)data);
        //}
    }
}
