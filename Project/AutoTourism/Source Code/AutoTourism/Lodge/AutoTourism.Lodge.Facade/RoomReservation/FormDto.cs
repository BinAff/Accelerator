using System.Collections.Generic;
using BinAff.Core;

using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class FormDto
    {
        //public Dto bookingDto { get; set; }
        public List<LodgeConfigurationFacade.Room.Dto> roomList { get; set; }

        //public List<LodgeReservationDto> ReservationList { get; set; }
    }
}
