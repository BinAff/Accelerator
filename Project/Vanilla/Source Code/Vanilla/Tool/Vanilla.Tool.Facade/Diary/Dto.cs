using System;
using System.Collections.Generic;

namespace Vanilla.Tool.Facade.Diary
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public DateTime Date { get; set; }
        public List<Appointment.Dto> AppointmentList { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.AppointmentList != null)
            {
                dto.AppointmentList = new List<Appointment.Dto>();
                foreach (Appointment.Dto contactNumber in this.AppointmentList)
                {
                    dto.AppointmentList.Add(contactNumber.Clone() as Appointment.Dto);
                }
            }
            return dto;
        }

    }

}
