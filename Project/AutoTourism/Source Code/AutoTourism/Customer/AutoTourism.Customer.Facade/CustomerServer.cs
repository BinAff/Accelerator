using System;
using System.Collections.Generic;

using BinAff.Core;

using AutotourismComponent = Autotourism.Component.Customer;
using CustomerComponent = Crystal.Customer.Component;
using ConfigurationComponent = Crystal.Configuration.Component;
using LodgeComponent = Crystal.Lodge.Component;


namespace AutoTourism.Customer.Facade
{

    public class CustomerServer : ICustomer
    {

        #region ICustomer

        ReturnObject<FormDto> ICustomer.LoadForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    InitialList = this.ReadAllInitial().Value,
                    StateList = this.ReadAllState().Value,
                    IdentityProofTypeList = this.ReadAllIdentityProof().Value,

                }
            };

            return ret;
        }

        ReturnObject<FormDto> ICustomer.LoadCustomerRegisterForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    CustomerList = this.ReadAllCustomer().Value,
                }
            };

            return ret;
        }
        
        ReturnObject<Boolean> ICustomer.Save(Dto dto)
        {
            return this.SaveCustomer(dto);
        }
        
        #endregion

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
                    ContactNumberList = ((CustomerComponent.Data)data).ContactNumberList == null ? null : GetContactNumberList(((CustomerComponent.Data)data).ContactNumberList),
                    Email = ((CustomerComponent.Data)data).Email,
                    IdentityProofType = ((CustomerComponent.Data)data).IdentityProofType == null ? null : new Table()
                    {
                        Id = ((CustomerComponent.Data)data).IdentityProofType.Id,
                        Name = ((CustomerComponent.Data)data).IdentityProofType.Name,
                    },
                    IdentityProofName = ((Crystal.Customer.Component.Data)data).IdentityProof,

                    reservationList = this.ReadReservationData(((CustomerComponent.Data)data).CharacteristicList)
                });
            }

            return ret;            
        }

        private ReturnObject<List<Table>> ReadAllInitial()
        {
            ICrud crud = new ConfigurationComponent.Initial.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            ReturnObject<List<Table>> ret = new ReturnObject<List<Table>>
            {
                Value = new List<Table>()
            };

            //Populate data in dto from business entity
            foreach (ConfigurationComponent.Initial.Data data in dataList.Value)
            {
                ret.Value.Add(new Table
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

        private ReturnObject<Boolean> SaveCustomer(Dto dto)
        {           
            ICrud crud = new AutotourismComponent.Server(new AutotourismComponent.Data
            {
                Id = dto.Id,
                Initial = dto.Initial == null ? null : new ConfigurationComponent.Initial.Data()
                {
                    Id = dto.Initial.Id,
                },
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Address = dto.Address,
                State = dto.State == null ? null : new ConfigurationComponent.State.Data()
                {
                    Id = dto.State.Id,
                },
                City = dto.City,
                Pin = dto.Pin,
                ContactNumberList = dto.ContactNumberList == null ? null : GetContactNumberDataList(dto.ContactNumberList),
                Email = dto.Email,
                IdentityProofType = dto.IdentityProofType == null ? null : new ConfigurationComponent.IdentityProofType.Data()
                {
                    Id = dto.IdentityProofType.Id,
                },
                IdentityProof = dto.IdentityProofName
            });
            return crud.Save();
        }

        private List<CustomerComponent.ContactNumber.Data> GetContactNumberDataList(List<Table> ContactNumberList)
        {
            List<CustomerComponent.ContactNumber.Data> ContactNumberDataList = new List<CustomerComponent.ContactNumber.Data>();
            foreach (Table dto in ContactNumberList)
            {
                ContactNumberDataList.Add(new CustomerComponent.ContactNumber.Data
                {
                    Id = dto.Id,
                    ContactNumber = dto.Name,
                });
            }
            return ContactNumberDataList;
        }

        private List<Table> GetContactNumberList(List<CustomerComponent.ContactNumber.Data> ContactNumberDataList)
        {
            List<Table> ContactNumberDtoList = new List<Table>();
            foreach (CustomerComponent.ContactNumber.Data data in ContactNumberDataList)
            {
                ContactNumberDtoList.Add(new Table
                {
                    Id = data.Id,
                    Name = data.ContactNumber,
                });
            }
            return ContactNumberDtoList;
        }

        private List<Lodge.Reservation.Dto> ReadReservationData(List<CustomerComponent.Characteristic.Data> characteristicList)
        {
            List<Lodge.Reservation.Dto> reservationList = new List<Lodge.Reservation.Dto>(); 
            foreach (CustomerComponent.Characteristic.Data characteristicData in characteristicList)
            {
                if (characteristicData.GetType().FullName == "Crystal.Lodge.Component.Room.Reserver.Data") {
                    if (characteristicData.AllList != null){
                        foreach (LodgeComponent.Room.Reservation.Data reservationData in characteristicData.AllList) 
                        {
                            reservationList.Add(new Lodge.Reservation.Dto
                            {
                                Id = reservationData.Id,
                                BookingDate = reservationData.ActivityDate,
                                BookingFrom = reservationData.Date,
                                NoOfDays = reservationData.NoOfDays,
                                NoOfPersons = reservationData.NoOfPersons,
                                NoOfRooms = reservationData.NoOfRooms,
                                Advance = reservationData.Advance,
                                BookingStatus = new Table{
                                    Id = reservationData.Status.Id,
                                    Name = reservationData.Status.Name
                                },                                
                                RoomList = reservationData.ProductList == null ? null : GetRoomDtoList(reservationData.ProductList),
                            });
                        }
                    }
                }
            }
            return reservationList;
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
                        Category = new Table {
                            Id = ((LodgeComponent.Room.Data)data).Category.Id,
                            Name = ((LodgeComponent.Room.Data)data).Category.Name
                        }                        
                    });
                }
            }
            return retVal;
        }


    }

}
