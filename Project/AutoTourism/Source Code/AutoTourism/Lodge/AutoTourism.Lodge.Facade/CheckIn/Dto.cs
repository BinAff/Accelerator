using System;
using System.Collections.Generic;
using LodgeFacade = AutoTourism.Lodge.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        //public Int64 Id { get; set; }
        public Decimal Advance { get; set; }
        public LodgeFacade.RoomReservation.Dto Reservation { get; set; }
        public List<LodgeConfigurationFacade.Room.Dto> RoomList { get; set; }
        
    }
}
