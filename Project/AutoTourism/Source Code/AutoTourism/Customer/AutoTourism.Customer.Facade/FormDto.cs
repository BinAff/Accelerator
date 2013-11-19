
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Customer.Facade
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {
        public Dto dto { get; set;}
        public List<Dto> CustomerList { get; set; }

        public List<Table> InitialList { get; set; }
        public List<Table> StateList { get; set; }
        public List<Table> IdentityProofTypeList { get; set; }
       
        //public List<LodgeReservationDto> ReservationList { get; set; }
    }

}
