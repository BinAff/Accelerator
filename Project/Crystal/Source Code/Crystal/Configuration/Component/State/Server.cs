using System.Collections.Generic;

namespace Crystal.Configuration.Component.State
{

    public class Server : BinAff.Core.Observer.SubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "State";
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

        //protected override BinAff.Core.ReturnObject<List<BinAff.Core.Data>> ReadAll()
        //{
        //    return new BinAff.Core.ReturnObject<List<BinAff.Core.Data>>
        //    {
        //        Value = ((Dao)this.DataAccess).ReadAll()
        //    };
        //}

    }

}
