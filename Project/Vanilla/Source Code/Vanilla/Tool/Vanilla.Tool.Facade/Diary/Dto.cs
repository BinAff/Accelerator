using System;
using System.Collections.Generic;

namespace Vanilla.Tool.Facade.Diary
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public DateTime Date { get; set; }
        public List<Appointment.Dto> AppointmentList { get; set; }

    }

}
