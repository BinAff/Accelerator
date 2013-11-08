using System;
using System.Collections.Generic;

using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class Dto
    {
        public Int64 Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public Int16 NoOfDays { get; set; }
        public Int16 NoOfPersons { get; set; }
        public Int16 NoOfRooms { get; set; }
        public Double Advance { get; set; }
        public Int64 BookingStatusId { get; set; }

        public List<LodgeConfigurationFacade.Room.Dto> RoomList { get; set; }
        public CustomerFacade.Dto Customer { get; set; }
    }
}
