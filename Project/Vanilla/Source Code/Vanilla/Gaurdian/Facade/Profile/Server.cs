using System;
using System.Collections.Generic;

using BinAff.Core;

using CrysInitial = Crystal.Configuration.Component.Initial;
using CrysProfile = Crystal.Guardian.Component.Account.Profile;

namespace Vanilla.Guardian.Facade.Profile
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            this.LoadInitialList();
            //Reading profile data from cache
            CrysProfile.Data profile; ;
            ReturnObject<BinAff.Core.Data> ret = (new CrysProfile.Server(profile = this.Convert(((FormDto)this.FormDto).Dto) as CrysProfile.Data) as ICrud).Read();

            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
            if (!this.IsError) (this.FormDto as FormDto).Dto = (new Account.Server(null)).Convert(ret.Value) as Account.Dto;
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CrysProfile.Data profileData = data as CrysProfile.Data;
            Dto profileDto = new Dto
            {
                FirstName = profileData.FirstName,
                MiddleName = profileData.MiddleName,
                LastName = profileData.LastName,
                DateOfBirth = profileData.DateOfBirth,
            };
            if (profileData.Initial != null)
            {
                profileDto.Initial = new Table
                {
                    Id = profileData.Initial.Id,
                    Name = profileData.Initial.Name,
                };
            }
            if (profileData.ContactNumberList != null && profileData.ContactNumberList.Count > 0)
            {
                profileDto.ContactNumberList = new List<Table>();
                foreach (CrysProfile.ContactNumber.Data contactNumber in profileData.ContactNumberList)
                {
                    profileDto.ContactNumberList.Add(new Table
                    {
                        Id = contactNumber.Id,
                        Name = contactNumber.ContactNumber,
                    });
                }
            }
            return profileDto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            CrysProfile.Data profileData = new CrysProfile.Data();
            Dto profileDto = dto as Dto;

            profileData.Id = profileDto.Id;
            if (!String.IsNullOrEmpty(profileDto.FirstName) || !String.IsNullOrEmpty(profileDto.MiddleName)
                || !String.IsNullOrEmpty(profileDto.FirstName) || !String.IsNullOrEmpty(profileDto.MiddleName))
            {
                profileData = new CrysProfile.Data
                {
                    FirstName = profileDto.FirstName,
                    MiddleName = profileDto.MiddleName,
                    LastName = profileDto.LastName,
                    DateOfBirth = profileDto.DateOfBirth,
                };
                if (profileDto.Initial != null)
                {
                    profileData.Initial = new CrysInitial.Data
                    {
                        Id = profileDto.Initial.Id,
                        Name = profileDto.Initial.Name,
                    };
                }
            }

            if (profileDto.ContactNumberList != null && profileDto.ContactNumberList.Count > 0)
            {
                profileData.ContactNumberList = new List<Data>();
                foreach (Table d in profileDto.ContactNumberList)
                {
                    profileData.ContactNumberList.Add(new CrysProfile.ContactNumber.Data
                    {
                        Id = d.Id,
                        ContactNumber = d.Name,
                    });
                }
            }

            return profileData;
        }

        public override void Change()
        {
            
        }

        private void LoadInitialList()
        {
            ICrud component = new CrysInitial.Server(null);
            ReturnObject<List<Data>> ret = component.ReadAll();
            if (this.IsError = ret.HasError())
            {
                this.DisplayMessageList = ret.GetMessage(Message.Type.Error);
            }
            else
            {
                if (ret.Value != null && ret.Value.Count > 0)
                {
                    (this.FormDto as FormDto).InitialList = new List<Table>();
                    foreach (CrysInitial.Data data in ret.Value)
                    {
                        (this.FormDto as FormDto).InitialList.Add(new Table
                        {
                            Id = data.Id,
                            Name = data.Name,
                        });
                    }
                }
            }
        }

    }

}
