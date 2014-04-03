using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Diary.Component.Appointment
{

    public interface IAppointment
    {

        ReturnObject<List<BinAff.Core.Data>> Search(DateTime start, DateTime end);
        ReturnObject<List<BinAff.Core.Data>> Search(DateTime start, DateTime end, Importance.Data importance);

    }

}
