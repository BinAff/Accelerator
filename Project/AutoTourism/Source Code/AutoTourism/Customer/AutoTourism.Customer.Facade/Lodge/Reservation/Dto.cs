using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Customer.Facade.Lodge.Reservation
{

    public class Dto : BinAff.Facade.Library.Dto
    {
        
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public Int32 NoOfDays { get; set; }
        public Int32 NoOfPersons { get; set; }
        public Int32 NoOfRooms { get; set; }
        public Double Advance { get; set; }
        public Table BookingStatus { get; set; }
        public List<Room.Dto> RoomList { get; set; }
        //public AutoTourism.Facade.CustomerManagement.Dto Customer { get; set; }

    }

}
