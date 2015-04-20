using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Lodge.Component.Building.Type
{

    public class Server : SubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Building Type";
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
