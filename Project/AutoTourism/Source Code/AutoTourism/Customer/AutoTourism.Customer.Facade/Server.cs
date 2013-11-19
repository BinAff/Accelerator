using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutotourismComponent = Autotourism.Component.Customer;
using CustomerComponent = Crystal.Customer.Component;
using LodgeComponent = Crystal.Lodge.Component;

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
            throw new NotImplementedException();
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
                ContactNumberList = customer.ContactNumberList == null ? null : this.GetContactNumberList(customer.ContactNumberList),
                Email = customer.Email,
                IdentityProofType = customer.IdentityProofType == null ? null : new Table()
                {
                    Id = customer.IdentityProofType.Id,
                    Name = customer.IdentityProofType.Name,
                },
                IdentityProofName = ((Crystal.Customer.Component.Data)data).IdentityProof,

                reservationList = this.ReadReservationData(customer.CharacteristicList)
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
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
                if (characteristicData.GetType().FullName == "Crystal.Lodge.Component.Room.Reserver.Data")
                {
                    if (characteristicData.AllList != null)
                    {
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
                                BookingStatus = new Table
                                {
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

    }

}
