using System;
using System.Collections.Generic;

namespace Crystal.Diary.Component.Calender
{

    public interface ICalender
    {

        List<BinAff.Core.Data> SearchAppointment(DateTime date);

    }

}
