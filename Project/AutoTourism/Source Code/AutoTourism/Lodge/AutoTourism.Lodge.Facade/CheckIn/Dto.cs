
using System;
using System.Collections.Generic;

using BinAff.Core;
using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;


namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime Date { get; set; }
        public LodgeFacade.RoomReservation.Dto reservationDto { get; set; }
        public String customerDisplayName { get; set; }

        //public DateTime Date { get; set; }
        //public DateTime CheckInDate { get; set; }
        //public Int16 NoOfDays { get; set; }
        //public Int16 NoOfPersons { get; set; }
        //public Int16 NoOfRooms { get; set; }
        //public Double Advance { get; set; }

        //public Table RoomCategory { get; set; }
        //public Table RoomType { get; set; }
        //public Boolean IsAC { get; set; }

        //public List<LodgeConfigurationFacade.Room.Dto> RoomList { get; set; }
        //public CustomerFacade.Dto Customer { get; set; }
        
    }
}
