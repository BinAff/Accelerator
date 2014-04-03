using System;

using BinAff.Core;

using CrysCal = Crystal.Diary.Component.Calender;
using CrysApp = Crystal.Diary.Component.Appointment;
using System.Collections.Generic;

namespace Vanilla.Tool.Facade.Diary.Appointment
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            this.LoadTypeList();
            this.LoadImportanceList();
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            CrysApp.Data appData = data as CrysApp.Data;
            Dto appDto = new Dto
            {
                Id = appData.Id,
                Title = appData.Title,
                Type = new Table
                {
                    Id = appData.Type.Id,
                    Name = appData.Type.Name,
                },
                Start = appData.Start,
                End = appData.End,
                Location = appData.Location,
                Description = appData.Description,
                Reminder = appData.Reminder,
            };
            if (appData.Importance != null)
            {
                appDto.Importance = new Table
                {
                    Id = appData.Importance.Id,
                    Name = appData.Importance.Name,
                };
            }
            return appDto;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto appDto = dto as Dto;
            CrysApp.Data appData = new CrysApp.Data
            {
                Id = appDto.Id,
                Actor = new Guardian.Facade.Account.Server(null).Convert((BinAff.Facade.Cache.Server.Current.Cache["User"] as Vanilla.Guardian.Facade.Account.Dto)),
                Title = appDto.Title,
                Type = new CrysApp.Type.Data
                {
                    Id = appDto.Type.Id,
                    Name = appDto.Type.Name,
                },
                Start = appDto.Start,
                End = appDto.End,
                Location = appDto.Location,
                Description = appDto.Description,
                Reminder = appDto.Reminder,
            };
            if (appDto.Importance != null)
            {
                appData.Importance = new CrysApp.Importance.Data
                {
                    Id = appDto.Importance.Id,
                    Name = appDto.Importance.Name,
                };
            }
            return appData;
        }

        public override void Add()
        {
            ICrud crud = new CrysApp.Server(this.Convert((base.FormDto as FormDto).Dto) as CrysApp.Data);
            ReturnObject<Boolean> ret = crud.Save();

            (this.FormDto as FormDto).Dto.Id = (crud as Crud).Data.Id;
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        public override void Change()
        {
            this.Add();
        }

        public override void Delete()
        {
            base.Delete();
        }

        public override void Read()
        {
            base.Read();
        }

        private void LoadTypeList()
        {
            ReturnObject<List<Data>> typeList = (new CrysApp.Type.Server(null) as ICrud).ReadAll();
            if (typeList == null || typeList.HasError())
            {
                this.DisplayMessageList = new List<String>();
                this.DisplayMessageList.AddRange(typeList.GetMessage(Message.Type.Error));
            }
            else if (typeList.Value != null && typeList.Value.Count > 0)
            {
                (this.FormDto as FormDto).TypeList = new List<Table>();
                foreach (CrysApp.Type.Data data in typeList.Value)
                {
                    (this.FormDto as FormDto).TypeList.Add(new Table
                    {
                        Id = data.Id,
                        Name = data.Name,
                    });
                }
            }
        }

        private void LoadImportanceList()
        {
            ReturnObject<List<Data>> importanceList = (new CrysApp.Importance.Server(null) as ICrud).ReadAll();
            if (importanceList == null || importanceList.HasError())
            {
                this.DisplayMessageList = new List<String>();
                this.DisplayMessageList.AddRange(importanceList.GetMessage(Message.Type.Error));
            }
            else if (importanceList.Value != null && importanceList.Value.Count > 0)
            {
                (this.FormDto as FormDto).ImportanceList = new List<Table>();
                foreach (CrysApp.Importance.Data data in importanceList.Value)
                {
                    (this.FormDto as FormDto).ImportanceList.Add(new Table
                    {
                        Id = data.Id,
                        Name = data.Name,
                    });
                }
            }
        }

        public List<BinAff.Facade.Library.Dto> Search(DateTime date)
        {
            List<BinAff.Facade.Library.Dto> appointmentList = new List<BinAff.Facade.Library.Dto>();
            CrysCal.ICalender server = new CrysCal.Server();
            List<BinAff.Core.Data> search = server.SearchAppointment(date);
            if (search != null)
            {
                foreach (BinAff.Core.Data data in search)
                {
                    appointmentList.Add(this.Convert(data));
                }
            }
            return appointmentList;
        }

    }

}