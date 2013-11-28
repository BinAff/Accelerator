using BinAff.Core;
using System;
using System.Collections.Generic;

using AutotourismComponent = Autotourism.Component.Customer;
using CustomerComponent = Crystal.Customer.Component;
using LodgeComponent = Crystal.Lodge.Component;
using ConfigurationComponent = Crystal.Configuration.Component;
using RuleFacade = Autotourism.Configuration.Rule.Facade;

namespace AutoTourism.Customer.Facade
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.InitialList = this.ReadAllInitial();
            formDto.StateList = this.ReadAllState().Value;
            formDto.IdentityProofTypeList = this.ReadAllIdentityProof().Value;
            formDto.DtoList = this.ReadAllCustomer().Value;
            formDto.customerRuleDto = this.ReadCustomerRule().Value;
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            AutotourismComponent.Data customer = data as AutotourismComponent.Data;
            return new Dto
            {
                Id = data.Id,
                Initial = customer.Initial == null ? null : new Table
                {
                    Id = customer.Initial.Id,
                    Name = customer.Initial.Name,
                },
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Address = customer.Address,
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
            return new AutotourismComponent.Data
            {
                Id = dto.Id,
                Initial = customer.Initial == null ? null : new ConfigurationComponent.Initial.Data()
                {
                    Id = customer.Initial.Id,
                },
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Address = customer.Address,
                State = customer.State == null ? null : new ConfigurationComponent.State.Data()
                {
                    Id = customer.State.Id,
                },
                City = customer.City,
                Pin = customer.Pin,
                ContactNumberList = customer.ContactNumberList == null ? null : this.ConvertContactNumberList(customer.ContactNumberList),
                Email = customer.Email,
                IdentityProofType = customer.IdentityProofType == null ? null : new ConfigurationComponent.IdentityProofType.Data()
                {
                    Id = customer.IdentityProofType.Id,
                },
                IdentityProof = customer.IdentityProofName
            };
        }

        public override void Add()
        {
            this.Save();
        }

        public override void Change()
        {
            this.Save();
        }

        private void Save()
        {
            ICrud crud = new AutotourismComponent.Server(this.Convert((this.FormDto as FormDto).Dto) as AutotourismComponent.Data);
            ReturnObject<Boolean> ret = crud.Save();

            (this.FormDto as FormDto).Dto.Id = (crud as Crud).Data.Id;
            this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
        }

        private List<Table> ReadAllInitial()
        {
            //Building.FormDto buildingFormDto = new FacadeBuilding.FormDto();
            //Building.Server buildFacade = new FacadeBuilding.Server(buildingFormDto);
            //buildFacade.LoadForm();
            //this.DisplayMessageList.AddRange(buildFacade.DisplayMessageList);

            ICrud crud = new ConfigurationComponent.Initial.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            List<Table> ret = new List<Table>();

            //Populate data in dto from business entity
            foreach (ConfigurationComponent.Initial.Data data in dataList.Value)
            {
                ret.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        private ReturnObject<List<Table>> ReadAllState()
        {
            ICrud crud = new ConfigurationComponent.State.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            ReturnObject<List<Table>> ret = new ReturnObject<List<Table>>
            {
                Value = new List<Table>()
            };

            //Populate data in dto from business entity
            foreach (ConfigurationComponent.State.Data data in dataList.Value)
            {
                ret.Value.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        private ReturnObject<List<Table>> ReadAllIdentityProof()
        {
            ICrud crud = new ConfigurationComponent.IdentityProofType.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            ReturnObject<List<Table>> ret = new ReturnObject<List<Table>>
            {
                Value = new List<Table>()
            };

            //Populate data in dto from business entity
            foreach (ConfigurationComponent.IdentityProofType.Data data in dataList.Value)
            {
                ret.Value.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        private List<CustomerComponent.ContactNumber.Data> ConvertContactNumberList(List<Table> dtoList)
        {
            List<CustomerComponent.ContactNumber.Data> dataList = new List<CustomerComponent.ContactNumber.Data>();
            foreach (Table dto in dtoList)
            {
                dataList.Add(new CustomerComponent.ContactNumber.Data
                {
                    Id = dto.Id,
                    ContactNumber = dto.Name,
                });
            }
            return dataList;
        }

        private List<Table> ConvertContactNumberList(List<CustomerComponent.ContactNumber.Data> dataList)
        {
            List<Table> dtoList = new List<Table>();
            foreach (CustomerComponent.ContactNumber.Data data in dataList)
            {
                dtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.ContactNumber,
                });
            }
            return dtoList;
        }

        private List<Lodge.Room.Dto> GetRoomDtoList(List<BinAff.Core.Data> roomDataList)
        {
            List<Lodge.Room.Dto> retVal = null;
            if (roomDataList != null && roomDataList.Count > 0)
            {

                retVal = new List<Lodge.Room.Dto>();
                foreach (BinAff.Core.Data data in roomDataList)
                {
                    retVal.Add(new Lodge.Room.Dto()
                    {
                        Id = data.Id,
                        Number = ((LodgeComponent.Room.Data)data).Number,
                        Name = ((LodgeComponent.Room.Data)data).Name,
                        Description = ((LodgeComponent.Room.Data)data).Description,
                        Building = new Lodge.Building.Dto
                        {
                            Id = ((LodgeComponent.Room.Data)data).Building.Id,
                            Name = ((LodgeComponent.Room.Data)data).Building.Name,
                            Status = new Table
                            {
                                Id = ((LodgeComponent.Room.Data)data).Building.Status.Id,
                                Name = ((LodgeComponent.Room.Data)data).Building.Status.Name,
                            },

                            Type = new Table
                            {
                                Id = ((LodgeComponent.Room.Data)data).Building.Type.Id,
                                Name = ((LodgeComponent.Room.Data)data).Building.Type.Name,
                            }
                        },
                        Status = new Table
                        {
                            Id = ((LodgeComponent.Room.Data)data).Status.Id,
                            Name = ((LodgeComponent.Room.Data)data).Status.Name
                        },
                        Type = new Table
                        {
                            Id = ((LodgeComponent.Room.Data)data).Type.Id,
                            Name = ((LodgeComponent.Room.Data)data).Type.Name
                        },
                        IsAirconditioned = ((LodgeComponent.Room.Data)data).IsAirConditioned,
                        Category = new Table
                        {
                            Id = ((LodgeComponent.Room.Data)data).Category.Id,
                            Name = ((LodgeComponent.Room.Data)data).Category.Name
                        }
                    });
                }
            }
            return retVal;
        }

        private ReturnObject<List<Dto>> ReadAllCustomer()
        {
            ReturnObject<List<Dto>> retObj = new ReturnObject<List<Dto>>();

            ICrud crud = new AutotourismComponent.Server(null);
            ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

            if (lstData.HasError())
                return new ReturnObject<List<Dto>>
                {
                    MessageList = lstData.MessageList
                };

            ReturnObject<List<Dto>> ret = new ReturnObject<List<Dto>>()
            {
                Value = new List<Dto>(),
            };

            //Populate data in dto from business entity
            foreach (BinAff.Core.Data data in lstData.Value)
            {
                ret.Value.Add(new Dto
                {
                    Id = data.Id,
                    Initial = ((CustomerComponent.Data)data).Initial == null ? null : new Table
                    {
                        Id = ((CustomerComponent.Data)data).Initial.Id,
                        Name = ((CustomerComponent.Data)data).Initial.Name,
                    },
                    FirstName = ((CustomerComponent.Data)data).FirstName,
                    MiddleName = ((CustomerComponent.Data)data).MiddleName,
                    LastName = ((CustomerComponent.Data)data).LastName,
                    Address = ((CustomerComponent.Data)data).Address,
                    State = ((CustomerComponent.Data)data).State == null ? null : new Table()
                    {
                        Id = ((CustomerComponent.Data)data).State.Id,
                        Name = ((CustomerComponent.Data)data).State.Name,
                    },
                    City = ((CustomerComponent.Data)data).City,
                    Pin = ((CustomerComponent.Data)data).Pin,
                    ContactNumberList = ((CustomerComponent.Data)data).ContactNumberList == null ? null : ConvertContactNumberList(((CustomerComponent.Data)data).ContactNumberList),
                    Email = ((CustomerComponent.Data)data).Email,
                    IdentityProofType = ((CustomerComponent.Data)data).IdentityProofType == null ? null : new Table()
                    {
                        Id = ((CustomerComponent.Data)data).IdentityProofType.Id,
                        Name = ((CustomerComponent.Data)data).IdentityProofType.Name,
                    },
                    IdentityProofName = ((Crystal.Customer.Component.Data)data).IdentityProof,
                });
            }

            return ret;
        }

        private ReturnObject<RuleFacade.CustomerRuleDto> ReadCustomerRule()
        {
            return new RuleFacade.RuleServer().ReadCustomerRule();            
        }

    }

}
