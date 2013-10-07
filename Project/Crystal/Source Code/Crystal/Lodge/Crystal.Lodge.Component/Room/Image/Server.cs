using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Lodge.Component.Room.Image
{

    public class Server : SubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Room Image";
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

        //protected override ReturnObject<List<BinAff.Core.Data>> ReadAll()
        //{
        //    return new ReturnObject<List<BinAff.Core.Data>>
        //    {
        //        Value = ((Dao)this.DataAccess).ReadAll()
        //    };
        //}

    }

}
