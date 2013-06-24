namespace Crystal.Navigator.Rule
{

    public class Server : BinAff.Core.Crud 
    {

        public Server(Data data)
            : base(data)
        {
            base.Data.Id = 1;
        }

        protected override void Compose()
        {
            this.Name = "Navigator Rule";
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
    }

}
