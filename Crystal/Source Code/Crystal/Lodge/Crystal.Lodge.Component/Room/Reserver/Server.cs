using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Lodge.Component.Room.Reserver
{

    public class Server : Crystal.Reservation.Component.Reserver.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.Name = "Room Reserver";
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
            base.AddChildren(new Lodge.Component.Room.Reservation.Server(null)
            {
                Type = ChildType.Independent,
                IsReadOnly = true,
            }, (this.Data as Data).AllList);
            //base.AddChild(new Lodge.Component.Room.Reservation.Server((this.Data as Data).Active as Lodge.Component.Room.Reservation.Data)
            //{
            //    Type = ChildType.Independent,
            //});
            //base.AddChildren(new Lodge.Component.Room.Reservation.Server(null)
            //{
            //    Type = ChildType.Independent,
            //    IsReadOnly = true,
            //}, ((Data)base.Data).ArchiveList);
            //base.AddChildren(new Lodge.Component.Room.Reservation.Server(null)
            //{
            //    Type = ChildType.Independent,
            //    IsReadOnly = true,
            //}, ((Data)base.Data).CurrentList);
        }

    }

}
