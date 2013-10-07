using System;
using System.Collections.Generic;

using BinAff.Core;


namespace Crystal.Reservation.Component
{

    public abstract class Server : Customer.Component.Action.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected override void CreateChildren()
        {
            base.CreateChildren();
        }

        public abstract ReturnObject<Boolean> ChangeReservationToOccupied();
       
    }

}
