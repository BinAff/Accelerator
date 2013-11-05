using System.Collections.Generic;

namespace AutoTourism.Lodge.Facade.BookingDetails
{
    public class FormDto : BinAff.Facade.Library.Dto
    {
        public List<Dto> bookingDetailList { get; set; }
    }
}
