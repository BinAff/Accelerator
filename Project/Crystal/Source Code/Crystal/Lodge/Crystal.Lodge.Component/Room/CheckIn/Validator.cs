using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using System;
using Crystal.Reservation.Component;

namespace Crystal.Lodge.Component.Room.CheckIn
{

    public class Validator : Crystal.Activity.Component.Validator
    {

        public Validator(Data data) 
            : base(data) 
        {

        }

        protected override List<Message> Validate()
        {            
            List<Message> retMsg = base.Validate();
            Data data = (Data)base.Data;

            //if (this.IsReservationCheckedIn(data))
            //    retMsg.Add(new Message("Reservation is already checked in.", Message.Type.Error));

            return retMsg;
        }

        private Boolean IsReservationCheckedIn(Data data)
        {
            ICrud crud = new Reservation.Server(data.Reservation);
            ReturnObject<BinAff.Core.Data> reservationData = crud.Read();
            return ((Reservation.Data)reservationData.Value).IsCheckedIn;            
        }

    }

}
