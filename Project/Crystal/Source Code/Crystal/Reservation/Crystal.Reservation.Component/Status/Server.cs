using System.Collections.Generic;
using BinAff.Core;

namespace Crystal.Reservation.Component.Status
{

    public class Server : BinAff.Core.Observer.SubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Reservation Status";
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


        protected override ReturnObject<List<BinAff.Core.Data>> ReadAll()
        {
            ReturnObject<List<BinAff.Core.Data>> retList = new ReturnObject<List<BinAff.Core.Data>>
            {
                Value = ((Dao)this.DataAccess).ReadAll()
            };

            foreach (BinAff.Core.Data data in retList.Value)
            {
                ICrud crud = this.CreateInstance(data);
                crud.Read();
            }

            return retList;
        }

    }

}
