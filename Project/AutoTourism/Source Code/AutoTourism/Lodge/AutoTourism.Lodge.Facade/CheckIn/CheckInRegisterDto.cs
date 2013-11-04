using System;
using LodgeFacade = AutoTourism.Lodge.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class CheckInRegisterDto
    {
        public Int64 Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public String Name { get; set; }
        public String ContactNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Room { get; set; }
        public Decimal Advance { get; set; }
        public Int64 InvoiceId { get; set; }

        public LodgeFacade.RoomReservation.Dto Reservation { get; set; }
    }
}
