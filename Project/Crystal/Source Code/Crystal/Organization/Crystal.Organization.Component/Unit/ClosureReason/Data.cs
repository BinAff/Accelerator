using System;

namespace Crystal.Organization.Component.Unit.ClosureReason
{

    public class Data : BinAff.Core.Data
    {

        public String Reason { get; set; }
        //public Int64 UserId { get; set; } -- There should be a link to guardian
       
        public DateTime ClosedDate { get; set; }

    }

}
