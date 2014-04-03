using System;
using System.Collections.Generic;

namespace Crystal.Diary.Component.Calender
{

    public class Data : BinAff.Core.Data
    {

        public DateTime Start { get; set; }
        public List<BinAff.Core.Data> AppointmentList { get; set; }

    }

}
