using System;

namespace AutoTourism.Lodge.Facade.BookingDetails
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String BookingDate { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String Rooms { get; set; }
        public Double Advance { get; set; }
        public Int64 BookingStatusId { get; set; }

    }

}
