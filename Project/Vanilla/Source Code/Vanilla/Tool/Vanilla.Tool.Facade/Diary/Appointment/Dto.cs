using System;

using BinAff.Core;

namespace Vanilla.Tool.Facade.Diary.Appointment
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Title { get; set; }
        public Table Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public Table Importance { get; set; }
        public DateTime? Reminder { get; set; }

    }

}
