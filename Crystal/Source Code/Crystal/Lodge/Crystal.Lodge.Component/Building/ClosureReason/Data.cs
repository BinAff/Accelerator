using System;

namespace Crystal.Lodge.Component.Building.ClosureReason
{
    public class Data : BinAff.Core.Data
    {
        public String Reason { get; set; }
        //public Int64 UserId { get; set; } -- There should be a link to guardian
       
        public DateTime ClosedDate { get; set; }
    }
}
