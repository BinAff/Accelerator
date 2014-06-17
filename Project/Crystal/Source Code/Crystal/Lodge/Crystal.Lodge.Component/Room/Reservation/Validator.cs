using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using System;
using Crystal.Reservation.Component;

namespace Crystal.Lodge.Component.Room.Reservation
{

    public class Validator : Crystal.Reservation.Component.Validator
    {

        public Validator(Data data) 
            : base(data) 
        {

        }

        protected override List<Message> Validate()
        {            
            List<Message> retMsg = base.Validate();
            Data data = (Data)base.Data;

            if (data.NoOfDays == 0)
                retMsg.Add(new Message("No of days cannot be 0.", Message.Type.Error));

            //if (data.NoOfPersons == 0)
            //    retMsg.Add(new Message("No of persons cannot be 0.", Message.Type.Error));

            if (data.NoOfRooms == 0)
                retMsg.Add(new Message("No of rooms cannot be 0.", Message.Type.Error));


            ////If rooms are selected for reservation, then checking whether any of the selected rooms are already booked for the same dates
            //if (data.ProductList != null)
            //{
            //    DateTime startDate = data.ActivityDate;
            //    DateTime endDate = startDate.AddDays(data.NoOfDays);

            //    Customer.Component.Action.IAction reservation = new Room.Reservation.Server(null);
            //    ReturnObject<List<Customer.Component.Action.Data>> ret = reservation.Search(data.Status, startDate, endDate);

            //    if (ret != null && ret.Value.Count > 0)
            //    {
            //        foreach (Crystal.Lodge.Component.Room.Data productData in data.ProductList)
            //        {
            //            foreach (Crystal.Lodge.Component.Room.Reservation.Data roomReservationData in ret.Value)
            //            {
            //                if (roomReservationData.ProductList != null && roomReservationData.ProductList.Count > 0)
            //                {
            //                    foreach (Crystal.Lodge.Component.Room.Data roomtData in roomReservationData.ProductList)
            //                    {
            //                        if (productData.Id == roomtData.Id && data.Id != roomReservationData.Id)
            //                        {
            //                            String msg = "Room No: " + roomtData.Number + " is booked from " + roomReservationData.ActivityDate.ToShortDateString() + " to " + roomReservationData.ActivityDate.AddDays(roomReservationData.NoOfDays).ToShortDateString();
            //                            retMsg.Add(new Message(msg, Message.Type.Error));
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
           
            return retMsg;
        }

    }

}
