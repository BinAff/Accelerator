using System;
using System.Collections.Generic;

namespace Crystal.Diary.Component.Calender
{

    public class Server:ICalender
    {

        List<BinAff.Core.Data> ICalender.SearchAppointment(System.DateTime date)
        {
            DateTime start = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime end = new DateTime(date.Year, date.Month, date.Day, 23, 45, 0);

            List<BinAff.Core.Data> searchList = (new Appointment.Server(null) as Appointment.IAppointment).Search(start, end).Value;

            List<BinAff.Core.Data> appointmentList = new List<BinAff.Core.Data>();
            DateTime index = start;
            while (index <= end)
            {
                Data entry = new Data
                {
                    Start = index,
                    AppointmentList = searchList.FindAll((p) => { return (p as Appointment.Data).Start == index; })
                };
                appointmentList.Add(entry);
                index = index.AddMinutes(15);
            }

            return appointmentList;
        }

    }

}
