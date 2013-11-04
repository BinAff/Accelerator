using System;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class LodgeReservationDto
    {
        public Int64 Id { get; set; }
        public String BookingDate { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String Rooms { get; set; }
        public Decimal Advance { get; set; }
        public Int64 BookingStatusId { get; set; }
    }
}
