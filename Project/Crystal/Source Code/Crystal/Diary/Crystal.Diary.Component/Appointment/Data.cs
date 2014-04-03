using System;

namespace Crystal.Diary.Component.Appointment
{

    public class Data : BinAff.Core.Data
    {

        public BinAff.Core.Data Actor { get; set; }
        public String Title { get; set; }
        public Type.Data Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public Importance.Data Importance { get; set; }
        public DateTime? Reminder { get; set; }

    }

}
