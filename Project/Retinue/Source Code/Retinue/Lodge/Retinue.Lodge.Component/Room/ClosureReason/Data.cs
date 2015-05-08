using System;

namespace Retinue.Lodge.Component.Room.ClosureReason
{
    public class Data : BinAff.Core.Data
    {
        public String Reason { get; set; }
        public Int64 UserId { get; set; }
        public Int64 BuildingId { get; set; }
        public DateTime ClosedDate { get; set; }
    }
}
