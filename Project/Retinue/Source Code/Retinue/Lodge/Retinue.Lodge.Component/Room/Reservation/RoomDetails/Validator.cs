using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Component.Room.Reservation.RoomDetails
{

    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = this.Data as Data;

            if (data.ExtraAccomodation < 0)
            {
                retMsg.Add(new Message("Extra accomodation cannot be negetive.", Message.Type.Error));
            }
            if (data.Room == null)
            {
                retMsg.Add(new Message("Room is not selected.", Message.Type.Error));
            }

            return retMsg;
        }

    }

}