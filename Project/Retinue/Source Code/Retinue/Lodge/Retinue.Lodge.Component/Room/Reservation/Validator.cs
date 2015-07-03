using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Component.Room.Reservation
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
            Data data = base.Data as Data;

            if (data.NoOfDays == 0)
            {
                retMsg.Add(new Message("No of days cannot be 0.", Message.Type.Error));
            }
            if (data.NoOfRooms == 0)
            {
                retMsg.Add(new Message("No of rooms cannot be 0.", Message.Type.Error));
            }
            if (data.NoOfMale + data.NoOfFemale == 0)
            {
                retMsg.Add(new Message("There must be at least male or female guest.", Message.Type.Error));
            }
            if (data.ProductList != null && data.ProductList.Count > 0 && data.ProductList.Count > data.NoOfRooms)
            {
                retMsg.Add(new Message("Selected rooms cannot be greated than number of required room.", Message.Type.Error));
            }

            ////If rooms are selected for reservation, then checking whether any of the selected rooms are already booked for the same dates
            //if (data.ProductList != null)
            //{
            //    DateTime startDate = data.ActivityDate;
            //    DateTime endDate = startDate.AddDays(data.NoOfDays);

            //    Customer.Component.Action.IAction reservation = new Room.Reservation.Server(null);
            //    ReturnObject<List<Customer.Component.Action.Data>> ret = reservation.Search(data.Status, startDate, endDate);

            //    if (ret != null && ret.Value.Count > 0)
            //    {
            //        foreach (Retinue.Lodge.Component.Room.Data productData in data.ProductList)
            //        {
            //            foreach (Retinue.Lodge.Component.Room.Reservation.Data roomReservationData in ret.Value)
            //            {
            //                if (roomReservationData.ProductList != null && roomReservationData.ProductList.Count > 0)
            //                {
            //                    foreach (Retinue.Lodge.Component.Room.Data roomtData in roomReservationData.ProductList)
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
