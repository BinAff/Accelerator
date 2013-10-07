namespace Crystal.Guardian.Rule
{

    public class Server : BinAff.Core.Crud 
    {

        public Server(Data data)
            : base(data)
        {
            base.Data.Id = 1; //Just to avoid skip in CRUD;
        }

        protected override void Compose()
        {
            this.Name = "User Rule";
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
