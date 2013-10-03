using System;
using System.Collections.Generic;

using BinAff.Core;

using LodgeComponent = Crystal.Organization.Component;
using StateComponent = Crystal.Configuration.Component.State;

namespace AutoTourism.Lodge.Facade
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            LodgeComponent.Data data = new LodgeComponent.Data
            {
                Id = 1,
            };
            ReturnObject<BinAff.Core.Data> ret = (new LodgeComponent.Server(data) as ICrud).Read();
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);

            (this.FormDto as FormDto).StateList = this.ReadAllState().Value;
            (this.FormDto as FormDto).Lodge = this.Convert(data) as Dto;
        }

        public override void Add()
        {
            LodgeComponent.Data data = this.Convert((this.FormDto as FormDto).Lodge) as LodgeComponent.Data;
            ReturnObject<Boolean> ret = (new LodgeComponent.Server(data) as ICrud).Save();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        protected override BinAff.Facade.Library.Dto Convert(Data data)
        {
            LodgeComponent.Data lodge = data as LodgeComponent.Data;
            return new Dto
            {
                Id = data.Id,
                Name = lodge.Name == null ? String.Empty : lodge.Name,
                logo = lodge.Logo == null ? null : lodge.Logo,
                LicenceNumber = lodge.LicenceNumber == null ? String.Empty : lodge.LicenceNumber,
                Tan = lodge.Tan == null ? String.Empty : lodge.Tan,
                Address = lodge.Address == null ? String.Empty : lodge.Address,
                City = lodge.City == null ? String.Empty : lodge.City,
                State = lodge.State == null ? null : new Table
                {
                    Id = lodge.State.Id,
                    Name = lodge.State.Name == null ? null : lodge.State.Name
                },
                Pin = lodge.Pin,
                ContactName = lodge.ContactName == null ? String.Empty : lodge.ContactName,
                ContactNumberList = lodge.ContactNumberList == null ? null : ConvertContactNumberList(lodge.ContactNumberList),
                EmailList = lodge.EmailList == null ? null : ConvertEmailList(lodge.EmailList),
                FaxList = lodge.FaxList == null ? null : ConvertFaxList(lodge.FaxList),
            };
        }

        protected override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto lodge = dto as Dto;
            return new LodgeComponent.Data
            {
                Id = dto.Id,
                Name = lodge.Name,
                Logo = lodge.logo,
                LicenceNumber = lodge.LicenceNumber,
                Tan = lodge.Tan,
                Address = lodge.Address,
                City = lodge.City,
                State = new StateComponent.Data
                {
                    Id = lodge.State.Id,
                },
                Pin = lodge.Pin,
                ContactName = lodge.ContactName,
                ContactNumberList = lodge.ContactNumberList == null ? null : ConvertContactNumberList(lodge.ContactNumberList),
                FaxList = lodge.FaxList == null ? null : ConvertFaxList(lodge.FaxList),
                EmailList = lodge.EmailList == null ? null : ConvertEmailList(lodge.EmailList),
            };
        }

        private ReturnObject<List<Table>> ReadAllState()
        {
            ReturnObject<List<BinAff.Core.Data>> dataList = (new StateComponent.Server(null) as ICrud).ReadAll();

            ReturnObject<List<Table>> ret = new ReturnObject<List<Table>>
            {
                Value = new List<Table>()
            };

            //Populate data in dto from business entity
            foreach (StateComponent.Data data in dataList.Value)
            {
                ret.Value.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        private List<Table> ConvertContactNumberList(List<BinAff.Core.Data> contactNumberDataList)
        {
            List<Table> dtoList = new List<Table>();
            foreach (LodgeComponent.ContactNumber.Data data in contactNumberDataList)
            {
                dtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.ContactNumber,
                });
            }
            return dtoList;
        }

        private List<Table> ConvertEmailList(List<BinAff.Core.Data> emailDataList)
        {
            List<Table> dtoList = new List<Table>();
            foreach (LodgeComponent.Email.Data data in emailDataList)
            {
                dtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Email,
                });
            }
            return dtoList;
        }

        private List<Table> ConvertFaxList(List<BinAff.Core.Data> faxDataList)
        {
            List<Table> dtoList = new List<Table>();
            foreach (LodgeComponent.Fax.Data data in faxDataList)
            {
                dtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Fax,
                });
            }
            return dtoList;
        }

        private List<BinAff.Core.Data> ConvertContactNumberList(List<Table> contactNumberList)
        {
            List<BinAff.Core.Data> dataList = new List<BinAff.Core.Data>();
            foreach (Table dto in contactNumberList)
            {
                dataList.Add(new LodgeComponent.ContactNumber.Data
                {
                    Id = dto.Id,
                    ContactNumber = dto.Name,
                });
            }
            return dataList;
        }

        private List<BinAff.Core.Data> ConvertEmailList(List<Table> emailList)
        {
            List<BinAff.Core.Data> dataList = new List<BinAff.Core.Data>();

            foreach (Table dto in emailList)
            {
                dataList.Add(new LodgeComponent.Email.Data
                {
                    Id = dto.Id,
                    Email = dto.Name,
                });
            }
            return dataList;
        }

        private List<BinAff.Core.Data> ConvertFaxList(List<Table> faxList)
        {
            List<BinAff.Core.Data> dataList = new List<BinAff.Core.Data>();
            foreach (Table dto in faxList)
            {
                dataList.Add(new LodgeComponent.Fax.Data
                {
                    Id = dto.Id,
                    Fax = dto.Name,
                });
            }
            return dataList;
        }

    }

}
