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

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Type != null) dto.Type = this.Type.Clone();
            if (this.Importance != null) dto.Importance = this.Importance.Clone();
            return dto;
        }

    }

}
