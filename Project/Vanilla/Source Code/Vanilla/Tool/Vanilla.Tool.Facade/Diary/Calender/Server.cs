using System;

using BinAff.Core;

using CrysCal = Crystal.Diary.Component.Calender;
using CrysApp = Crystal.Diary.Component.Appointment;
using System.Collections.Generic;

namespace Vanilla.Tool.Facade.Diary.Calender
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrysCal.Data calData = data as CrysCal.Data;
            Dto dto = new Dto
            {
                Time = calData.Start.ToString("hh:mm tt")
            };
            if (calData.AppointmentList != null && calData.AppointmentList.Count > 0)
            {
                dto.AppointmentList = new List<Appointment.Dto>();
                dto.Message = String.Empty;
                foreach (CrysApp.Data app in calData.AppointmentList)
                {
                    Appointment.Dto appointment = new Appointment.Server(null).Convert(app) as Appointment.Dto;
                    dto.Message += String.Format("{0}(up to {1}) : {2}", appointment.Title, appointment.End.ToString("hh:mm tt"), appointment.Description) + Environment.NewLine;
                    dto.AppointmentList.Add(appointment);
                }
            }

            return dto;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        public override void Change()
        {
            //this.Add();
        }

        public override void Delete()
        {
            //base.Delete();
        }

        public List<Dto> Search(DateTime date)
        {
            List<Dto> appointmentList = new List<Dto>();
            List<BinAff.Core.Data> searchList = (new CrysCal.Server() as CrysCal.ICalender).SearchAppointment(date);
            if (searchList != null)
            {
                foreach (BinAff.Core.Data data in searchList)
                {
                    appointmentList.Add(this.Convert(data) as Dto);
                }
            }
            (this.FormDto as FormDto).AppointmentList = appointmentList;
            return appointmentList;
        }

    }

}