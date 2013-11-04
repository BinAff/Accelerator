using System;
using System.Collections.Generic;


namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class RoomReservationRegisterDto
    {
        public Int64 Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public Int32 NoOfDays { get; set; }
        public Int32 NoOfPersons { get; set; }
        public Int32 NoOfRooms { get; set; }
        public Decimal Advance { get; set; }
        public Int64 BookingStatusId { get; set; }
        public String Name { get; set; }
        public String ContactNumber { get; set; }
        public String Room { get; set; }

        //public List<AutoTourism.Facade.Configuration.Room.Dto> RoomList { get; set; }
        //public AutoTourism.Facade.CustomerManagement.Dto Customer { get; set; }
    }
}
