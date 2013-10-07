using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Guardian.Component.SecurityQuestion
{

    public class Server : BinAff.Core.Observer.SubjectCrud
    {

        public Server(Data data)
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            this.Name = "User Security Question";
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

        //protected override ReturnObject<List<BinAff.Core.Data>> ReadAll()
        //{
        //    return new ReturnObject<List<BinAff.Core.Data>>
        //    {
        //        Value = ((Dao)this.DataAccess).ReadAll()
        //    };
        //}

    }

}
