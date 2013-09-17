using System;
using System.Collections.Generic;

using BinAff.Core;

using Crystal.Lodge.Configuration.Lodge;

namespace AutoTourism.Facade.Configuration.Lodge
{

    public class LodgeServer : ILodge 
    {
        
        #region IBuildingType

        ReturnObject<FormDto> ILodge.LoadForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    Lodge = this.ReadLodge().Value,
                    //LodgeList = this.ReadAllLodge().Value,
                    StateList = this.ReadAllState().Value,                    
                }
            };
          
            return ret;     
        }

        ReturnObject<Boolean> ILodge.SaveLodge(Dto dto)
        {
            return this.Save(dto);
        }
       

        #endregion

        private ReturnObject<Dto> ReadLodge()
        {
            ReturnObject<Dto> retObj = new ReturnObject<Dto>();

            ICrud crud = new Crystal.Lodge.Configuration.Lodge.Server(new Crystal.Lodge.Configuration.Lodge.Data() { Id = 0 });            
            ReturnObject<BinAff.Core.Data> Data = crud.Read();

            if (Data.HasError())
                return new BinAff.Core.ReturnObject<Dto>
                {
                    MessageList = Data.MessageList
                };

            //Populate data in dto from business entity
            BinAff.Core.ReturnObject<Dto> ret = new BinAff.Core.ReturnObject<Dto>()
            {
                Value =  (Data.Value == null || Data.Value.Id == 0) ? null : new Dto() {
                    Id = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Id == null ? 0 : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Id,
                    Name = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Name == null ? String.Empty : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Name,
                    logo = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Logo == null ? null : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Logo,
                    LicenceNumber = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).LicenceNumber == null ? String.Empty : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).LicenceNumber,
                    Tan = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Tan == null ? String.Empty : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Tan,
                    Address = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Address == null ? String.Empty : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Address,
                    City = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).City == null ? String.Empty : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).City,
                    State = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).State == null ? null : new State.Dto()
                    {
                        Id = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).State.Id == null? 0 : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).State.Id,
                        Name = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).State.Name == null ? null : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).State.Name
                    },
                    Pin = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Pin == null ? 0 : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).Pin,
                    ContactName = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).ContactName == null ? String.Empty : ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).ContactName,

                    ContactNumberList = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).ContactNumberList == null ? null :
                            GetContactNumberList(((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).ContactNumberList),
                    EmailList = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).EmailList == null ? null : 
                            GetEmailList(((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).EmailList),
                    FaxList = ((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).FaxList == null ? null : 
                            GetFaxList(((Crystal.Lodge.Configuration.Lodge.Data)Data.Value).FaxList),
                },
            };           

            return ret;
        }

        private ReturnObject<List<Dto>> ReadAllLodge()
        {
            BinAff.Core.ReturnObject<List<Dto>> retObj = new BinAff.Core.ReturnObject<List<Dto>>();
            BinAff.Core.ICrud crud = new Crystal.Lodge.Configuration.Lodge.Server(new Crystal.Lodge.Configuration.Lodge.Data());
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new BinAff.Core.ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };

            BinAff.Core.ReturnObject<List<Dto>> ret = new BinAff.Core.ReturnObject<List<Dto>>()
            {
                Value = new List<Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {   
                ret.Value.Add(new Dto
                {
                    Id = data.Id,
                    Name = ((Crystal.Lodge.Configuration.Lodge.Data)data).Name,
                    logo = ((Crystal.Lodge.Configuration.Lodge.Data)data).Logo,
                    LicenceNumber = ((Crystal.Lodge.Configuration.Lodge.Data)data).LicenceNumber,
                    Tan = ((Crystal.Lodge.Configuration.Lodge.Data)data).Tan,
                    Address = ((Crystal.Lodge.Configuration.Lodge.Data)data).Address,
                    City = ((Crystal.Lodge.Configuration.Lodge.Data)data).City,
                    State = new State.Dto()
                    {
                        Id = ((Crystal.Lodge.Configuration.Lodge.Data)data).State.Id,
                    },
                    Pin = ((Crystal.Lodge.Configuration.Lodge.Data)data).Pin,
                    ContactName = ((Crystal.Lodge.Configuration.Lodge.Data)data).ContactName,
                    
                    ContactNumberList = ((Crystal.Lodge.Configuration.Lodge.Data)data).ContactNumberList == null ? null : GetContactNumberList(((Crystal.Lodge.Configuration.Lodge.Data)data).ContactNumberList),
                    EmailList = ((Crystal.Lodge.Configuration.Lodge.Data)data).EmailList == null ? null : GetEmailList(((Crystal.Lodge.Configuration.Lodge.Data)data).EmailList),
                    FaxList = ((Crystal.Lodge.Configuration.Lodge.Data)data).FaxList == null ? null : GetFaxList(((Crystal.Lodge.Configuration.Lodge.Data)data).FaxList),                    

                });
            }

            return ret;
        }

        private List<ContactNumberDto> GetContactNumberList(List<ContactNumberData> ContactNumberDataList)
        {
            List<ContactNumberDto> ContactNumberDtoList = new List<ContactNumberDto>();
            foreach (ContactNumberData data in ContactNumberDataList)
            {
                ContactNumberDtoList.Add(new ContactNumberDto() {
                    Id = data.Id,
                    Name = data.ContactNumber,
                });
            }
            return ContactNumberDtoList;
        }

        private List<EmailDto> GetEmailList(List<EmailData> EmailDataList)
        {
            List<EmailDto> EmailDtoList = new List<EmailDto>();
            foreach (EmailData data in EmailDataList)
            {
                EmailDtoList.Add(new EmailDto()
                {
                    Id = data.Id, 
                    Name = data.Email,
                });
            }
            return EmailDtoList;
        }

        private List<FaxDto> GetFaxList(List<FaxData> FaxDataList)
        {
            List<FaxDto> FaxDtoList = new List<FaxDto>();
            foreach (FaxData data in FaxDataList)
            {
                FaxDtoList.Add(new FaxDto()
                {
                    Id = data.Id,
                    Name = data.Fax,
                });
            }
            return FaxDtoList;
        }

        private ReturnObject<List<State.Dto>> ReadAllState()
        {
            ICrud crud = new Crystal.Configuration.State.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            ReturnObject<List<State.Dto>> ret = new ReturnObject<List<State.Dto>>
            {
                Value = new List<State.Dto> ()
            };           

            //Populate data in dto from business entity
            foreach (Crystal.Configuration.State.Data data in dataList.Value)
            {
                ret.Value.Add(new State.Dto
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        private ReturnObject<Boolean> Save(Dto dto)
        {
            Crystal.Lodge.Configuration.Lodge.Data data = new Crystal.Lodge.Configuration.Lodge.Data()
            {
                Id = dto.Id,
                Name = dto.Name,
                Logo = dto.logo,
                LicenceNumber = dto.LicenceNumber,
                Tan = dto.Tan,
                Address = dto.Address,
                City = dto.City,
                State = new Crystal.Configuration.State.Data() { 
                    Id = dto.State.Id,
                },
                Pin = dto.Pin,
                ContactName = dto.ContactName,
                ContactNumberList = dto.ContactNumberList == null ? null : GetContactNumberDataList(dto.ContactNumberList),
                FaxList = dto.FaxList == null ? null : GetFaxDataList(dto.FaxList),
                EmailList = dto.EmailList == null ? null : GetEmailList(dto.EmailList),
            };

            ICrud crud = new Crystal.Lodge.Configuration.Lodge.Server(data);
            return crud.Save();
        }

        private List<ContactNumberData> GetContactNumberDataList(List<ContactNumberDto> ContactNumberList)
        {
            List<ContactNumberData> ContactNumberDataList = new List<ContactNumberData>();
            foreach (ContactNumberDto dto in ContactNumberList)
            {
                ContactNumberDataList.Add(new ContactNumberData()
                {
                    Id = dto.Id,
                    ContactNumber = dto.Name,                    
                });
            }
            return ContactNumberDataList;
        }

        private List<FaxData> GetFaxDataList(List<FaxDto> FaxList)
        {
            List<FaxData> FaxDataList = new List<FaxData>();
            foreach (FaxDto dto in FaxList)
            {
                FaxDataList.Add(new FaxData()
                {
                    Id = dto.Id,
                    Fax = dto.Name,
                });
            }
            return FaxDataList;
        }

        private List<EmailData> GetEmailList(List<EmailDto> EmailList)
        {
            List<EmailData> EmailDataList = new List<EmailData>();

            foreach (EmailDto dto in EmailList)
            {
                EmailDataList.Add(new EmailData()
                {
                    Id = dto.Id,
                    Email = dto.Name,
                });
            }
            return EmailDataList;
        }
    }

}
