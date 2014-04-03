using System;

using BinAff.Core;

using CrysCal = Crystal.Diary.Component.Calender;
using CrysApp = Crystal.Diary.Component.Appointment;
using System.Collections.Generic;

namespace Vanilla.Tool.Facade.Diary.Calender
{

    public class Server : BinAff.Facade.Library.Server
    {

        private FormDto formDto;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            this.formDto = new FormDto
            {
                AppointmentList= new List<Appointment.Dto>()
            };
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrysCal.Data calData = data as CrysCal.Data;
            Dto dto = new Dto
            {
                Time = calData.Start.ToShortTimeString()
            };
            if (calData.AppointmentList != null)
            {
                dto.AppointmentList = new List<Appointment.Dto>();
                foreach (CrysApp.Data app in calData.AppointmentList)
                {
                    dto.AppointmentList.Add(new Appointment.Server(null).Convert(app) as Appointment.Dto);
                }
            }

            return dto;
        }

        public override void Change()
        {
            //this.Add();
        }

        public override void Delete()
        {
            //base.Delete();
        }

        public List<Appointment.Dto> Search(DateTime date)
        {
            List<Appointment.Dto> appointmentList = new List<Appointment.Dto>();
            List<BinAff.Core.Data> searchList = (new CrysCal.Server() as CrysCal.ICalender).SearchAppointment(date);
            if (searchList != null)
            {
                foreach (BinAff.Core.Data data in searchList)
                {
                    appointmentList.Add(this.Convert(data) as Appointment.Dto);
                }
            }
            this.formDto.AppointmentList = appointmentList;
            return appointmentList;
        }


        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }
    }

}