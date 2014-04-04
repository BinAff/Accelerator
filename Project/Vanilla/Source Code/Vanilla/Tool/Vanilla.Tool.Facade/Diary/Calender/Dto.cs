using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Tool.Facade.Diary.Calender
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Time { get; set; }
        public String Message { get; set; }
        public List<Appointment.Dto> AppointmentList { get; set; }

    }

}
