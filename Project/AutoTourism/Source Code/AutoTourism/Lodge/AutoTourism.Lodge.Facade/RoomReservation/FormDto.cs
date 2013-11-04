using System.Collections.Generic;
using BinAff.Core;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class FormDto
    {
        public Dto bookingDto { get; set; }
        //public List<AutoTourism.Facade.Configuration.Room.Dto> roomList { get; set; }

        public List<LodgeReservationDto> ReservationList { get; set; }
    }
}
