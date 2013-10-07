using System;

namespace AutoTourism.Lodge.Configuration.Facade.Building
{
    public class ReasonDto : BinAff.Facade.Library.Dto
    {      
        public Building.Dto Building { get; set; }
        public String Reason { get; set; }
        public Vanilla.Guardian.Facade.Account.Dto UserAccount { get; set; }
        public DateTime ClosedDate { get; set; }
    }
}
