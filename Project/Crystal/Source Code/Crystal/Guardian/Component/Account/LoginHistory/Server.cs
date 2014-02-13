using System;

namespace Crystal.Guardian.Component.Account.LoginHistory
{

    public class Server : BinAff.Core.Crud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Name = "Login History";
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            throw new NotImplementedException();
        }

        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

    }

}
