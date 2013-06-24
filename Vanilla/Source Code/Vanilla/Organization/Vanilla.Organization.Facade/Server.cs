using System;
using System.Collections.Generic;
using Component = Crystal.Organization.Component;
using ConfigurationComponent = Crystal.Configuration.Component;
using BinAff.Core;

namespace Vanilla.Organization.Facade
{
    public class Server : BinAff.Facade.Library.Server
    {
        public Server(FormDto formDto)
            : base(formDto)
        {
            
        }

        public override void LoadForm()
        {
            (this.FormDto as FormDto).StateList = this.ReadAllState();
            (this.FormDto as FormDto).Dto = this.ReadDto();           

        }

        public override void ConvertToDto()
        {
            throw new NotImplementedException();
        }

        public override void ConvertFromDto()
        {
            throw new NotImplementedException();
        }

        public override ReturnObject<Boolean> Save()
        {
            ICrud crud = new Component.Server(this.ConvertDtoToData(this.FormDto as FormDto));
            return crud.Save();
        }

        public List<ContactNumber.Dto> GetContactNumberList(List<Component.ContactNumber.Data> ContactNumberDataList)
        {
            List<ContactNumber.Dto> ContactNumberDtoList = new List<ContactNumber.Dto>();
            foreach (Component.ContactNumber.Data data in ContactNumberDataList)
            {
                ContactNumberDtoList.Add(new ContactNumber.Dto()
                {
                    Id = data.Id,
                    Name = data.ContactNumber,
                });
            }
            return ContactNumberDtoList;
        }

        private List<State.Dto> ReadAllState()
        {
            ICrud crud = new ConfigurationComponent.State.Server(null);            
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            ReturnObject<List<State.Dto>> ret = new ReturnObject<List<State.Dto>>
            {
                Value = new List<State.Dto>()
            };

            //Populate data in dto from business entity
            foreach (ConfigurationComponent.State.Data data in dataList.Value)
            {
                ret.Value.Add(new State.Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret.Value;
        }

        private Dto ReadDto() {

            Dto organizationDto = null;
           
            ICrud crud = new Component.Server(new Component.Data() { Id=1});
            ReturnObject<BinAff.Core.Data> data = crud.Read();
            
            //name is mandatory for organization
            if (data.Value != null && ((Component.Data)data.Value).Name != null)
            {
                organizationDto = new Dto()
                {
                    Id = ((Component.Data)data.Value).Id,
                    Name = ((Component.Data)data.Value).Name,
                    Logo = ((Component.Data)data.Value).Logo,
                    LicenceNumber = ((Component.Data)data.Value).LicenceNumber,
                    Tan = ((Component.Data)data.Value).Tan,
                    Address = ((Component.Data)data.Value).Address,
                    City = ((Component.Data)data.Value).City,
                    Pin = ((Component.Data)data.Value).Pin,
                    ContactName = ((Component.Data)data.Value).ContactName,

                    State = new State.Dto() {
                    Id = ((Component.Data)data.Value).State == null ? -1 : ((Component.Data)data.Value).State.Id
                    },
                
                    ContactNumberList = this.ReadAllContactNumber(((Component.Data)data.Value).ContactNumberList),
                    EmailList = this.ReadAllEmail(((Component.Data)data.Value).EmailList),
                    FaxList = this.ReadAllFax(((Component.Data)data.Value).FaxList)
                };
            }

            return organizationDto;
        }

        private List<ContactNumber.Dto> ReadAllContactNumber(List<BinAff.Core.Data> contactDataList)
        {
            List<ContactNumber.Dto> ContactNumberList = new List<ContactNumber.Dto>();
            if (contactDataList != null && contactDataList.Count > 0) {
                foreach (BinAff.Core.Data data in contactDataList) {
                    ContactNumberList.Add(new ContactNumber.Dto() {
                        Id = ((Component.ContactNumber.Data)data).Id,
                        Name = ((Component.ContactNumber.Data)data).ContactNumber,
                    });
                }
            }

            return ContactNumberList;
        }

        private List<Email.Dto> ReadAllEmail(List<BinAff.Core.Data> emailDataList)
        {
            List<Email.Dto> emailList = new List<Email.Dto>();
            if (emailDataList != null && emailDataList.Count > 0)
            {
                foreach (BinAff.Core.Data data in emailDataList)
                {
                    emailList.Add(new Email.Dto()
                    {
                        Id = ((Component.Email.Data)data).Id,
                        Name = ((Component.Email.Data)data).Email,
                    });
                }
            }

            return emailList;
        }

        private List<Fax.Dto> ReadAllFax(List<BinAff.Core.Data> faxDataList)
        {
            List<Fax.Dto> faxList = new List<Fax.Dto>();
            if (faxDataList != null && faxDataList.Count > 0)
            {
                foreach (BinAff.Core.Data data in faxDataList)
                {
                    faxList.Add(new Fax.Dto()
                    {
                        Id = ((Component.Fax.Data)data).Id,
                        Name = ((Component.Fax.Data)data).Fax,
                    });
                }
            }

            return faxList;
        }

        private Component.Data ConvertDtoToData(FormDto formDto) {
            Component.Data data = new Component.Data();
            if (formDto != null && formDto.Dto != null) {
                data.Id = formDto.Dto.Id;
                data.Name = formDto.Dto.Name;
                data.Logo = formDto.Dto.Logo;
                data.LicenceNumber = formDto.Dto.LicenceNumber;
                data.Tan = formDto.Dto.Tan;
                data.Address = formDto.Dto.Address;
                data.City = formDto.Dto.City;
                data.Pin = formDto.Dto.Pin;
                data.ContactName = formDto.Dto.ContactName;
                data.State = new ConfigurationComponent.State.Data()
                {
                    Id = formDto.Dto.State.Id
                };

                data.ContactNumberList = this.GetContactNumberDataList(formDto.Dto.ContactNumberList);
                data.EmailList = formDto.Dto.EmailList == null ? null : this.GetEmailDataList(formDto.Dto.EmailList);
                data.FaxList = formDto.Dto.FaxList == null ? null : this.GetFaxDataList(formDto.Dto.FaxList);
            }
            return data;
        }

        public List<BinAff.Core.Data> GetContactNumberDataList(List<ContactNumber.Dto> ContactNumberDtoList)
        {
            List<BinAff.Core.Data> ContactNumberDataList = new List<BinAff.Core.Data>();
            foreach (ContactNumber.Dto dto in ContactNumberDtoList)
            {
                ContactNumberDataList.Add(new Component.ContactNumber.Data()
                {
                    Id = dto.Id,
                    ContactNumber = dto.Name,
                });
            }
            return ContactNumberDataList;
        }

        public List<BinAff.Core.Data> GetEmailDataList(List<Email.Dto> emailDtoList)
        {
            List<BinAff.Core.Data> emailDataList = new List<BinAff.Core.Data>();
            foreach (Email.Dto dto in emailDtoList)
            {
                emailDataList.Add(new Component.Email.Data()
                {
                    Id = dto.Id,
                    Email = dto.Name,
                });
            }
            return emailDataList;
        }

        public List<BinAff.Core.Data> GetFaxDataList(List<Fax.Dto> faxDtoList)
        {
            List<BinAff.Core.Data> faxDataList = new List<BinAff.Core.Data>();
            foreach (Fax.Dto dto in faxDtoList)
            {
                faxDataList.Add(new Component.Fax.Data()
                {
                    Id = dto.Id,
                    Fax = dto.Name,
                });
            }
            return faxDataList;
        }
    }
}
