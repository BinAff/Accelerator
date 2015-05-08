using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Core.Observer;
using System.Transactions;

namespace Retinue.Lodge.Component.Building
{

    public class Server : Crystal.Organization.Component.Unit.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Building";
            this.DataAccess = new Dao(this.Data as Data);
            this.Validator = new Validator(this.Data as Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {           
            return new Data();
        }
        
        protected override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }
        
        protected override void CreateChildren()
        {
            base.CreateChildren();

            base.AddChildren(new Floor.Server(null)
            {
                Type = ChildType.Dependent,
            }, ((Data)base.Data).FloorList);
        }

    }

}