using System;

namespace Vanilla.Configuration.Lodge.Facade.Building
{
    public class ReasonDto : BinAff.Facade.Library.Dto
    {      
        public Building.Dto Building { get; set; }
        public String Reason { get; set; }
        public Guardian.Facade.Account.Dto UserAccount { get; set; }
        public DateTime ClosedDate { get; set; }
    }
}
