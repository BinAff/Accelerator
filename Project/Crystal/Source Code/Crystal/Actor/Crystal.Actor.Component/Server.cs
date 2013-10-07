using System.Collections.Generic;

namespace Crystal.Actor.Component
{

    public abstract class Server : BinAff.Core.Observer.SubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

        protected override BinAff.Core.ReturnObject<List<BinAff.Core.Data>> ReadAll()
        {
            return new BinAff.Core.ReturnObject<List<BinAff.Core.Data>>
            {
                Value = ((Dao)this.DataAccess).ReadAll()
            };
        }

    }

}
