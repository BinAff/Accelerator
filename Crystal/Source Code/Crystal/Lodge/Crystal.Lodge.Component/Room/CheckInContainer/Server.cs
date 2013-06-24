using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Lodge.Component.Room.CheckInContainer
{

    public class Server : Crystal.Activity.Component.ActivityContainer.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "CheckIn Container";
            this.DataAccess = new Dao((Data)this.Data);
            this.Validator = new Validator((Data)this.Data);
        }

        protected override BinAff.Core.Data CreateDataObject()
        {
            return new Data();
        }

        protected override Crud CreateInstance(BinAff.Core.Data data)
        {
            return new Server(data as Data);
        }

        protected override void CreateChildren()
        {
            base.CreateChildren();
            base.AddChildren(new Lodge.Component.Room.CheckIn.Server(null)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            }, (this.Data as Data).AllList);           
        }

    }

}
