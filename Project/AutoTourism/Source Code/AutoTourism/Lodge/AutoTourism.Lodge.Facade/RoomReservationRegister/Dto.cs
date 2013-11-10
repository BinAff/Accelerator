using System;
using System.Collections.Generic;

using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservationRegister
{
    public class Dto
    {
        public Int64 Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public Int32 NoOfDays { get; set; }
        public Int32 NoOfPersons { get; set; }
        public Int32 NoOfRooms { get; set; }
        public Double Advance { get; set; }
        public Int64 BookingStatusId { get; set; }
        public String Name { get; set; }
        public String ContactNumber { get; set; }
        public String Room { get; set; }

        public List<LodgeConfigurationFacade.Room.Dto> RoomList { get; set; }
        public CustomerFacade.Dto Customer { get; set; }
    }
}
