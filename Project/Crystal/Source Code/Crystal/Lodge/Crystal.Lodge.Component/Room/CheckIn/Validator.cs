using System;
using System.Collections.Generic;

using BinAff.Core;

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
           
            //check whether any room is already checked In
            List<Room.Data> checkInRoomList = new Dao(data).ReadCheckedInRoomList();
            if(checkInRoomList != null && checkInRoomList.Count > 0)
            {
                foreach (Room.Data room in ((Crystal.Customer.Component.Action.Data)(data.Reservation)).ProductList)
                { 
                    foreach(Room.Data checkInRoom in checkInRoomList)
                    {
                        if (room.Id == checkInRoom.Id)
                        {
                            retMsg.Add(new Message("Room : " + room.Number + " is already checked in.", Message.Type.Error));
                            break;
                        }
                    }
                }
            }

            return retMsg;
        }

        private Boolean IsReservationCheckedIn(Data data)
        {
            ICrud crud = new Reservation.Server(data.Reservation);
            ReturnObject<BinAff.Core.Data> reservationData = crud.Read();
            return ((Reservation.Data)reservationData.Value).Status.Id == 10004;//Convert in enum
        }

    }

}
