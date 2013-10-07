using System;

using BinAff.Core;

namespace Crystal.Guardian.Component.Role.Right
{

    public class Server : Crud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "User Right";
            this.Validator = new Validator((Data)this.Data);
            this.DataAccess = new Dao((Data)this.Data);
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
