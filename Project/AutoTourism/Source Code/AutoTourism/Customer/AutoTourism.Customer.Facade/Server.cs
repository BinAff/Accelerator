using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Transactions;

using CustCrys = Crystal.Customer.Component;
using LodgeCrys = Crystal.Lodge.Component;
using ConfigCrys = Crystal.Configuration.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;

using CustAuto = AutoTourism.Component.Customer;
using CustArtfAuto = AutoTourism.Component.Customer.Navigator.Artifact;
using RuleAuto = AutoTourism.Configuration.Rule.Facade;

namespace AutoTourism.Customer.Facade
{

    public class Server : Vanilla.Form.Facade.Document.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {
            
        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;

            //formDto.InitialList = cache.InitialList;
            Vanilla.Utility.Facade.Cache.Dto cache = BinAff.Facade.Cache.Server.Current.Cache["Main"] as Vanilla.Utility.Facade.Cache.Dto;
            formDto.CountryList = cache.CountryList;
            formDto.IdentityProofTypeList = cache.IdentityProofTypeList;
            formDto.RuleDto = (BinAff.Facade.Cache.Server.Current.Cache["Main"] as AutoTourism.Utility.Facade.Cache.Dto).CustomerRule;
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            CustAuto.Data customer = data as CustAuto.Data;
            return new Dto
            {
                Id = data.Id,
                //Initial = customer.Initial == null ? null : new Table
                //{
                //    Id = customer.Initial.Id,
                //    Name = customer.Initial.Name,
                //},
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Address = customer.Address,
                Country = customer.Country == null ? null : new Table()
                {
                    Id = customer.Country.Id,
                    Name = customer.Country.Name,
                },
                State = customer.State == null ? null : new Table()
                {
                    Id = customer.State.Id,
                    Name = customer.State.Name,
                },
                City = customer.City,
                Pin = customer.Pin,
                ContactNumberList = customer.ContactNumberList == null ? null : this.ConvertContactNumberList(customer.ContactNumberList),
                Email = customer.Email,
                IdentityProofType = customer.IdentityProofType == null ? null : new Table()
                {
                    Id = customer.IdentityProofType.Id,
                    Name = customer.IdentityProofType.Name,
                },
                IdentityProofName = ((Crystal.Customer.Component.Data)data).IdentityProof,
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto customer = dto as Dto;
            return new CustAuto.Data
            {
                Id = dto.Id,
                //Initial = customer.Initial == null ? null : new ConfigCrys.Initial.Data()
                //{
                //    Id = customer.Initial.Id,
                //},
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Address = customer.Address,
                Country = customer.Country == null ? null : new ConfigCrys.Country.Data()
                {
                    Id = customer.Country.Id,
                },
                State = customer.State == null ? null : new ConfigCrys.State.Data()
                {
                    Id = customer.State.Id,
                },
                City = customer.City,
                Pin = customer.Pin,
                ContactNumberList = customer.ContactNumberList == null ? null : this.ConvertContactNumberList(customer.ContactNumberList),
                Email = customer.Email,
                IdentityProofType = customer.IdentityProofType == null ? null : new ConfigCrys.IdentityProofType.Data()
                {
                    Id = customer.IdentityProofType.Id,
                },
                IdentityProof = customer.IdentityProofName
            };
        }

        //private void Save()
        //{
        //    ReturnObject<Boolean> ret = this.componentServer.Save();
        //    (this.FormDto as FormDto).Dto.Id = (this.componentServer as Crud).Data.Id;
        //    //ReturnObject<Boolean> ret;
        //    //if ((this.FormDto as FormDto).Dto.Id > 0)
        //    //{
        //    //    ret = this.componentServer.Save();
        //    //}
        //    //else
        //    //{
        //    //    using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
        //    //    {
        //    //        ret = componentServer.Save();
        //    //        Int64 customerId = (componentServer as Crud).Data.Id;

        //    //        if (!ret.HasError())
        //    //        {
        //    //            Crystal.Navigator.Component.Artifact.IArtifact artifact = new CustAuto.Navigator.Artifact.Server(
        //    //                new CustAuto.Navigator.Artifact.Data
        //    //                {
        //    //                    Id = this.ArtifactDto.Id,
        //    //                    ComponentData = new Data { Id = customerId }
        //    //                });
        //    //            ret = artifact.UpdaterModuleArtifactLink();
        //    //            if (!ret.HasError())
        //    //            {
        //    //                T.Complete();
        //    //            }
        //    //        }

        //    //        (this.FormDto as FormDto).Dto.Id = (componentServer as Crud).Data.Id;
        //    //    }
        //    //}
           
        //    this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        //}
      
        //private List<Table> ReadAllInitial()
        //{
        //    //Building.FormDto buildingFormDto = new FacadeBuilding.FormDto();
        //    //Building.Server buildFacade = new FacadeBuilding.Server(buildingFormDto);
        //    //buildFacade.LoadForm();
        //    //this.DisplayMessageList.AddRange(buildFacade.DisplayMessageList);

        //    ICrud crud = new ConfigCrys.Initial.Server(null);
        //    ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

        //    List<Table> ret = new List<Table>();

        //    //Populate data in dto from business entity
        //    foreach (ConfigCrys.Initial.Data data in dataList.Value)
        //    {
        //        ret.Add(new Table
        //        {
        //            Id = data.Id,
        //            Name = data.Name
        //        });
        //    }

        //    return ret;
        //}

        public void LoadStateForCountry(Table country)
        {
            ICrud crud = new ConfigCrys.State.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            if (dataList.Value != null && dataList.Value.Count > 0)
            {
                (base.FormDto as Facade.FormDto).StateList = dataList.Value.ConvertAll((p) =>
                {
                    return new Table
                    {
                        Id = p.Id,
                        Name = (p as ConfigCrys.State.Data).Name
                    };
                });
            }
        }

        private List<CustCrys.ContactNumber.Data> ConvertContactNumberList(List<Table> dtoList)
        {
            List<CustCrys.ContactNumber.Data> dataList = new List<CustCrys.ContactNumber.Data>();
            foreach (Table dto in dtoList)
            {
                dataList.Add(new CustCrys.ContactNumber.Data
                {
                    Id = dto.Id,
                    ContactNumber = dto.Name,
                });
            }
            return dataList;
        }

        private List<Table> ConvertContactNumberList(List<CustCrys.ContactNumber.Data> dataList)
        {
            List<Table> dtoList = new List<Table>();
            foreach (CustCrys.ContactNumber.Data data in dataList)
            {
                dtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.ContactNumber,
                });
            }
            return dtoList;
        }

        //private List<Lodge.Room.Dto> GetRoomDtoList(List<BinAff.Core.Data> roomDataList)
        //{
        //    List<Lodge.Room.Dto> retVal = null;
        //    if (roomDataList != null && roomDataList.Count > 0)
        //    {

        //        retVal = new List<Lodge.Room.Dto>();
        //        foreach (BinAff.Core.Data data in roomDataList)
        //        {
        //            retVal.Add(new Lodge.Room.Dto()
        //            {
        //                Id = data.Id,
        //                Number = ((LodgeCrys.Room.Data)data).Number,
        //                Name = ((LodgeCrys.Room.Data)data).Name,
        //                Description = ((LodgeCrys.Room.Data)data).Description,
        //                Building = new Lodge.Building.Dto
        //                {
        //                    Id = ((LodgeCrys.Room.Data)data).Building.Id,
        //                    Name = ((LodgeCrys.Room.Data)data).Building.Name,
        //                    Status = new Table
        //                    {
        //                        Id = ((LodgeCrys.Room.Data)data).Building.Status.Id,
        //                        Name = ((LodgeCrys.Room.Data)data).Building.Status.Name,
        //                    },

        //                    Type = new Table
        //                    {
        //                        Id = ((LodgeCrys.Room.Data)data).Building.Type.Id,
        //                        Name = ((LodgeCrys.Room.Data)data).Building.Type.Name,
        //                    }
        //                },
        //                Status = new Table
        //                {
        //                    Id = ((LodgeCrys.Room.Data)data).Status.Id,
        //                    Name = ((LodgeCrys.Room.Data)data).Status.Name
        //                },
        //                Type = new Table
        //                {
        //                    Id = ((LodgeCrys.Room.Data)data).Type.Id,
        //                    Name = ((LodgeCrys.Room.Data)data).Type.Name
        //                },
        //                IsAirconditioned = ((LodgeCrys.Room.Data)data).IsAirConditioned,
        //                Category = new Table
        //                {
        //                    Id = ((LodgeCrys.Room.Data)data).Category.Id,
        //                    Name = ((LodgeCrys.Room.Data)data).Category.Name
        //                }
        //            });
        //        }
        //    }
        //    return retVal;
        //}

        public void SaveArtifactForCustomer(Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            Vanilla.Utility.Facade.Module.Dto customerModuleDto = new Vanilla.Utility.Facade.Module.Server(null).GetModule("CUST", (this.FormDto as FormDto).ModuleFormDto.FormModuleList);
            String fileName = new Vanilla.Utility.Facade.Artifact.Server(null).GetArtifactName(customerModuleDto.Artifact, Vanilla.Utility.Facade.Artifact.Type.Document, "Form");

            artifactDto.FileName = fileName;            

            if (customerModuleDto != null)
                customerModuleDto.Artifact.Children.Add(artifactDto);

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto
            {
                Dto = artifactDto
            };

            (this.FormDto as FormDto).ModuleFormDto.Dto = customerModuleDto;
            Vanilla.Utility.Facade.Module.Server moduleFacade = new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();

        }

        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData)
        {
            return new CustArtfAuto.Server(artifactData as CustArtfAuto.Data);
        }

        protected override ICrud GetComponentServer()
        {
            this.componentServer = new CustAuto.Server(this.Convert((this.FormDto as FormDto).Dto) as CustAuto.Data);
            return this.componentServer;
        }

        protected override String GetComponentDataType()
        {
            return "AutoTourism.Component.Customer.Navigator.Artifact.Data, AutoTourism.Component.Customer";
        }

        public override ReturnObject<Boolean> ValidateDelete()
        {
            ReturnObject<Boolean> ret = new ReturnObject<Boolean> { Value = true };

            Int64 componentId = this.ReadComponentIdForArtifact(this.Data.Id);
            if (componentId == 0) return ret;
            ReturnObject<Data> retData = (new CustAuto.Server(new CustAuto.Data { Id = componentId }) as ICrud).Read();

            LodgeCrys.Room.Reserver.Data reservationData = (retData.Value as CustAuto.Data).RoomReserver;
            LodgeCrys.Room.CheckInContainer.Data checkInData = (retData.Value as CustAuto.Data).Checkin;
            ret.MessageList = new List<Message>();
            if (reservationData != null && reservationData.AllList != null && reservationData.AllList.Count > 0)
            {
                ret.Value = false;
                ret.MessageList.Add(new Message("Customer has reservation.", Message.Type.Error));
            }
            if (checkInData != null && checkInData.AllList != null && checkInData.AllList.Count > 0)
            {
                ret.Value = false;
                ret.MessageList.Add(new Message("Customer has checkIn.", Message.Type.Error));
            }
            return ret;
        }

        public override String GetComponentCode()
        {
            return "CUST";
        }

        protected override ArtfCrys.Data GetArtifactData(Int64 artifactId)
        {
            return new CustArtfAuto.Data { Id = artifactId };
        }

    }

}
