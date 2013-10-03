using System;
using System.Collections.Generic;

using BinAff.Core;

using Lodge = Crystal.Lodge.Component.Lodge;
using Crystal.Lodge.Component.Lodge;

using State = Vanilla.Configuration.Facade.State;

namespace AutoTourism.Lodge.Configuration.Facade.Lodge
{

    public class Server : ILodge 
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

            ICrud crud = new Crystal.Lodge.Component.Lodge.Server(new Crystal.Lodge.Component.Lodge.Data() { Id = 0 });            
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
                    Id = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Id == null ? 0 : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Id,
                    Name = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Name == null ? String.Empty : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Name,
                    logo = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Logo == null ? null : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Logo,
                    LicenceNumber = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).LicenceNumber == null ? String.Empty : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).LicenceNumber,
                    Tan = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Tan == null ? String.Empty : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Tan,
                    Address = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Address == null ? String.Empty : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Address,
                    City = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).City == null ? String.Empty : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).City,
                    State = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).State == null ? null : new State.Dto()
                    {
                        Id = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).State.Id == null? 0 : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).State.Id,
                        Name = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).State.Name == null ? null : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).State.Name
                    },
                    Pin = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Pin == null ? 0 : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).Pin,
                    ContactName = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).ContactName == null ? String.Empty : ((Crystal.Lodge.Component.Lodge.Data)Data.Value).ContactName,

                    ContactNumberList = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).ContactNumberList == null ? null :
                            GetContactNumberList(((Crystal.Lodge.Component.Lodge.Data)Data.Value).ContactNumberList),
                    EmailList = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).EmailList == null ? null : 
                            GetEmailList(((Crystal.Lodge.Component.Lodge.Data)Data.Value).EmailList),
                    FaxList = ((Crystal.Lodge.Component.Lodge.Data)Data.Value).FaxList == null ? null : 
                            GetFaxList(((Crystal.Lodge.Component.Lodge.Data)Data.Value).FaxList),
                },
            };           

            return ret;
        }

        private ReturnObject<List<Dto>> ReadAllLodge()
        {
            BinAff.Core.ReturnObject<List<Dto>> retObj = new BinAff.Core.ReturnObject<List<Dto>>();
            BinAff.Core.ICrud crud = new Crystal.Lodge.Component.Lodge.Server(new Crystal.Lodge.Component.Lodge.Data());
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
                    Name = ((Crystal.Lodge.Component.Lodge.Data)data).Name,
                    logo = ((Crystal.Lodge.Component.Lodge.Data)data).Logo,
                    LicenceNumber = ((Crystal.Lodge.Component.Lodge.Data)data).LicenceNumber,
                    Tan = ((Crystal.Lodge.Component.Lodge.Data)data).Tan,
                    Address = ((Crystal.Lodge.Component.Lodge.Data)data).Address,
                    City = ((Crystal.Lodge.Component.Lodge.Data)data).City,
                    State = new State.Dto()
                    {
                        Id = ((Crystal.Lodge.Component.Lodge.Data)data).State.Id,
                    },
                    Pin = ((Crystal.Lodge.Component.Lodge.Data)data).Pin,
                    ContactName = ((Crystal.Lodge.Component.Lodge.Data)data).ContactName,
                    
                    ContactNumberList = ((Crystal.Lodge.Component.Lodge.Data)data).ContactNumberList == null ? null : this.GetContactNumberList(((Crystal.Lodge.Component.Lodge.Data)data).ContactNumberList),
                    EmailList = ((Crystal.Lodge.Component.Lodge.Data)data).EmailList == null ? null : this.GetEmailList(((Crystal.Lodge.Component.Lodge.Data)data).EmailList),
                    FaxList = ((Crystal.Lodge.Component.Lodge.Data)data).FaxList == null ? null : GetFaxList(((Crystal.Lodge.Component.Lodge.Data)data).FaxList),                    

                });
            }

            return ret;
        }

        private List<Table> GetContactNumberList(List<Crystal.Lodge.Component.Lodge.ContactNumberData> ContactNumberDataList)
        {
            List<Table> ContactNumberDtoList = new List<Table>();
            foreach (ContactNumberData data in ContactNumberDataList)
            {
                ContactNumberDtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.ContactNumber,
                });
            }
            return ContactNumberDtoList;
        }

        private List<Table> GetEmailList(List<Crystal.Lodge.Component.Lodge.EmailData> EmailDataList)
        {
            List<Table> EmailDtoList = new List<Table>();
            foreach (EmailData data in EmailDataList)
            {
                EmailDtoList.Add(new Table
                {
                    Id = data.Id, 
                    Name = data.Email,
                });
            }
            return EmailDtoList;
        }

        private List<Table> GetFaxList(List<Crystal.Lodge.Component.Lodge.FaxData> FaxDataList)
        {
            List<Table> FaxDtoList = new List<Table>();
            foreach (FaxData data in FaxDataList)
            {
                FaxDtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Fax,
                });
            }
            return FaxDtoList;
        }

        private ReturnObject<List<State.Dto>> ReadAllState()
        {
            ICrud crud = new Crystal.Configuration.Component.State.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            ReturnObject<List<State.Dto>> ret = new ReturnObject<List<State.Dto>>
            {
                Value = new List<State.Dto> ()
            };           

            //Populate data in dto from business entity
            foreach (Crystal.Configuration.Component.State.Data data in dataList.Value)
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
            Crystal.Lodge.Component.Lodge.Data data = new Crystal.Lodge.Component.Lodge.Data()
            {
                Id = dto.Id,
                Name = dto.Name,
                Logo = dto.logo,
                LicenceNumber = dto.LicenceNumber,
                Tan = dto.Tan,
                Address = dto.Address,
                City = dto.City,
                State = new Crystal.Configuration.Component.State.Data() { 
                    Id = dto.State.Id,
                },
                Pin = dto.Pin,
                ContactName = dto.ContactName,
                ContactNumberList = dto.ContactNumberList == null ? null : this.GetContactNumberDataList(dto.ContactNumberList),
                FaxList = dto.FaxList == null ? null : this.GetFaxDataList(dto.FaxList),
                EmailList = dto.EmailList == null ? null : GetEmailList(dto.EmailList),
            };

            ICrud crud = new Crystal.Lodge.Component.Lodge.Server(data);
            return crud.Save();
        }

        private List<Crystal.Lodge.Component.Lodge.ContactNumberData> GetContactNumberDataList(List<Table> contactNumberList)
        {
            List<ContactNumberData> ContactNumberDataList = new List<ContactNumberData>();
            foreach (Table dto in contactNumberList)
            {
                ContactNumberDataList.Add(new ContactNumberData
                {
                    Id = dto.Id,
                    ContactNumber = dto.Name,                    
                });
            }
            return ContactNumberDataList;
        }

        private List<Crystal.Lodge.Component.Lodge.FaxData> GetFaxDataList(List<Table> faxList)
        {
            List<FaxData> FaxDataList = new List<FaxData>();
            foreach (Table dto in faxList)
            {
                FaxDataList.Add(new FaxData
                {
                    Id = dto.Id,
                    Fax = dto.Name,
                });
            }
            return FaxDataList;
        }

        private List<Crystal.Lodge.Component.Lodge.EmailData> GetEmailList(List<Table> emailList)
        {
            List<EmailData> EmailDataList = new List<EmailData>();

            foreach (Table dto in emailList)
            {
                EmailDataList.Add(new EmailData
                {
                    Id = dto.Id,
                    Email = dto.Name,
                });
            }
            return EmailDataList;
        }
    }

}
