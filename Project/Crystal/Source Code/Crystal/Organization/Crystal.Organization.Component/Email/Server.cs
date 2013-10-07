using BinAff.Core;

namespace Crystal.Organization.Component.Email
{
    public class Server : BinAff.Core.Observer.SubjectCrud
    {
        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Organization Email";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server((Data)data);
        }
    }
}
