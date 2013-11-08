using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalLodge = Crystal.Lodge.Component;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class ReservationServer : IReservation
    {       

        #region "IReservation"

        ReturnObject<FormDto> IReservation.LoadForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    roomList = this.ReadAllRoom().Value,
                }
            };

            return ret;
        }

        ReturnObject<Boolean> IReservation.Save(Dto dto)
        {
            return this.SaveReservation(dto);
        }

        //ReturnObject<List<Dto>> IReservation.GetBooking(Int64 customerId)
        //{
        //    return this.GetCustomerBooking(customerId);
        //}

        //ReturnObject<List<RoomReservationRegisterDto>> IReservation.Search(Int64 bookingStatusId, DateTime startDate, DateTime endDate)
        //{
        //    return this.GetBookingSearchRecords(bookingStatusId, startDate, endDate);
        //}

        //ReturnObject<RoomReservationRegisterFormDto> IReservation.LoadRegisterForm(Int64 bookingStatusId, DateTime startDate, DateTime endDate)
        //{
        //    BinAff.Core.ReturnObject<RoomReservationRegisterFormDto> ret = new BinAff.Core.ReturnObject<RoomReservationRegisterFormDto>()
        //    {
        //        Value = new RoomReservationRegisterFormDto()
        //        {
        //            RoomReservationDtoList = this.GetBookingSearchRecords(bookingStatusId,startDate,endDate).Value,
        //            StatusList = this.GetLodgeReservationStatus().Value,
        //        }
        //    };

        //    return ret;
        //}

        //ReturnObject<Boolean> IReservation.ChangeReservationStatus(Dto dto)
        //{
        //    return this.UpdateReservationStatus(dto);
        //}
        #endregion

        private ReturnObject<List<LodgeConfigurationFacade.Room.Dto>> ReadAllRoom()
        {
            return new LodgeConfigurationFacade.Room.Server(null).ReadAllRoom();
        }

        private ReturnObject<Boolean> SaveReservation(Dto dto)
        {
            ICrud crud = new CrystalLodge.Room.Reservation.Server(new CrystalLodge.Room.Reservation.Data
            {
                Id = dto.Id,
                //Description = "",
                NoOfDays = dto.NoOfDays,
                NoOfPersons = dto.NoOfPersons,
                NoOfRooms = dto.NoOfRooms,
                Advance = dto.Advance,
                //IsCheckedIn = false,

                ActivityDate = dto.BookingFrom,

                Date = DateTime.Now,
                ProductList = dto.RoomList == null ? null : GetRoomDataList(dto.RoomList),
                Status = new Crystal.Customer.Component.Action.Status.Data
                {
                },
            });
            return crud.Save();
            //ICrud crud = new Server(new Crystal.Lodge.Reservation.Data
            //{
            //    Id = dto.Id,
            //    BookingFrom = dto.BookingFrom,
            //    NoOfDays = dto.NoOfDays,
            //    NoOfPersons = dto.NoOfPersons,
            //    NoOfRooms = dto.NoOfRooms,
            //    Advance = dto.Advance,
            //    Customer = dto.Customer == null ? null : new Crystal.CustomerManagement.Data()
            //    {
            //        Id = dto.Customer.Id,
            //    },
            //    RoomList = dto.RoomList == null ? null : GetRoomDataList(dto.RoomList),
            //});
            //return crud.Save();
        }

        private List<Data> GetRoomDataList(List<LodgeConfigurationFacade.Room.Dto> RoomList)
        {
            List<Data> RoomDataList = new List<Data>();
            foreach (LodgeConfigurationFacade.Room.Dto dto in RoomList)
            {
                RoomDataList.Add(new CrystalLodge.Room.Data
                {
                    Id = dto.Id,
                    Number = dto.Number,
                });
            }
            return RoomDataList;
        }

        private ReturnObject<List<Dto>> GetCustomerBooking(Int64 customerId)
        {
            List<Dto> bookingList = new List<Dto>();

            //Crystal.Lodge.Reservation.IReservation reservation = new Server(new Crystal.Lodge.Reservation.Data
            //{
            //    Customer = new Crystal.CustomerManagement.Data()
            //    {
            //        Id = customerId,
            //    },
            //});

            //ReturnObject<List<BinAff.Core.Data>> reservationDataList = reservation.GetBooking();

        //    foreach (BinAff.Core.Data data in reservationDataList.Value)
        //    {
        //        bookingList.Add(new Dto()
        //        {
        //            Id = data.Id,
        //            BookingDate = ((Crystal.Lodge.Reservation.Data)data).BookingDate,
        //            BookingFrom = ((Crystal.Lodge.Reservation.Data)data).BookingFrom,
        //            NoOfDays = ((Crystal.Lodge.Reservation.Data)data).NoOfDays,
        //            NoOfPersons = ((Crystal.Lodge.Reservation.Data)data).NoOfPersons,
        //            NoOfRooms = ((Crystal.Lodge.Reservation.Data)data).NoOfRooms,
        //            Advance = ((Crystal.Lodge.Reservation.Data)data).Advance,
        //            BookingStatusId = ((Crystal.Lodge.Reservation.Data)data).BookingStatusId,
        //            RoomList = GetRoomDtoList(((Crystal.Lodge.Reservation.Data)data).RoomList),
        //        });
        //    }

            return new ReturnObject<List<Dto>>()
            {
                Value = bookingList,
            };

        }

        //private List<AutoTourism.Facade.Configuration.Room.Dto> GetRoomDtoList(List<Crystal.Lodge.Configuration.Room.Data> RoomDataList)
        //{
        //    List<AutoTourism.Facade.Configuration.Room.Dto> retVal = null;
        //    if (RoomDataList != null)
        //    {
        //        retVal = new List<Configuration.Room.Dto>();
        //        foreach (Crystal.Lodge.Configuration.Room.Data data in RoomDataList)
        //        {
        //            retVal.Add(new Configuration.Room.Dto()
        //            {
        //                Id = data.Id,
        //                Number = data.Number,
        //                Name = data.Name,
        //                Description = data.Description,
        //                Building = new Configuration.Building.Dto()
        //                {
        //                    Id = data.Building.Id,
        //                },
        //                IsDormitory = data.IsDormitory,
        //                StatusId = data.StatusId,
        //            });
        //        }
        //    }
        //    return retVal;
        //}

        //private ReturnObject<List<RoomReservationRegisterDto>> GetBookingSearchRecords(Int64 bookingStatusId, DateTime startDate, DateTime endDate)
        //{
        //    List<RoomReservationRegisterDto> bookingList = new List<RoomReservationRegisterDto>();
        //    Crystal.Lodge.Reservation.IReservation reservation = new Server(null);

        //    ReturnObject<List<BinAff.Core.Data>> reservationDataList = reservation.GetBookingSearch(bookingStatusId, startDate, endDate);

        //    foreach (BinAff.Core.Data data in reservationDataList.Value)
        //    {
        //        RoomReservationRegisterDto regDto = new RoomReservationRegisterDto()
        //        {
        //            Id = data.Id,
        //            BookingDate = ((Crystal.Lodge.Reservation.Data)data).BookingDate,
        //            BookingFrom = ((Crystal.Lodge.Reservation.Data)data).BookingFrom,
        //            NoOfDays = ((Crystal.Lodge.Reservation.Data)data).NoOfDays,
        //            NoOfPersons = ((Crystal.Lodge.Reservation.Data)data).NoOfPersons,
        //            NoOfRooms = ((Crystal.Lodge.Reservation.Data)data).NoOfRooms,
        //            Advance = ((Crystal.Lodge.Reservation.Data)data).Advance,
        //            BookingStatusId = ((Crystal.Lodge.Reservation.Data)data).BookingStatusId,
        //            RoomList = GetRoomDtoList(((Crystal.Lodge.Reservation.Data)data).RoomList),

        //            //call the customer component read method
        //            Customer = ((Crystal.Lodge.Reservation.Data)data).Customer == null ? null : ReadCustomer(((Crystal.Lodge.Reservation.Data)data).Customer.Id),
                                        
        //        };
        //        regDto.BookingTo = regDto.BookingFrom.AddDays(regDto.NoOfDays);
        //        regDto.Name = regDto.Customer == null ? String.Empty : regDto.Customer.FirstName + " " + regDto.Customer.MiddleName + " " + regDto.Customer.LastName;
        //        regDto.ContactNumber = regDto.Customer == null ? String.Empty : regDto.Customer.ContactNumberList[0].Name;
        //        regDto.Room = GetRooms(regDto.RoomList);
        //        bookingList.Add(regDto);
        //    }

        //    return new ReturnObject<List<RoomReservationRegisterDto>>()
        //    {
        //        Value = bookingList,
        //    };
        //}

        //private AutoTourism.Facade.CustomerManagement.Dto ReadCustomer(Int64 customerId)
        //{               

        //    ICrud crud = new Crystal.CustomerManagement.Server(new Crystal.CustomerManagement.Data(){Id=customerId});
        //    ReturnObject<BinAff.Core.Data> data = crud.Read();

        //    AutoTourism.Facade.CustomerManagement.Dto customerDto = new CustomerManagement.Dto() {
        //        Id = data.Value.Id,
        //        Initial = ((Crystal.CustomerManagement.Data)data.Value).Initial == null ? null : new Configuration.Initial.Dto()
        //            {
        //                Id = ((Crystal.CustomerManagement.Data)data.Value).Initial.Id,
        //                Name = ((Crystal.CustomerManagement.Data)data.Value).Initial.Name,
        //            },
        //        FirstName = ((Crystal.CustomerManagement.Data)data.Value).FirstName,
        //        MiddleName = ((Crystal.CustomerManagement.Data)data.Value).MiddleName,
        //        LastName = ((Crystal.CustomerManagement.Data)data.Value).LastName,
        //        Address = ((Crystal.CustomerManagement.Data)data.Value).Address,
        //        State = ((Crystal.CustomerManagement.Data)data.Value).State == null ? null : new Configuration.State.Dto()
        //        {
        //            Id = ((Crystal.CustomerManagement.Data)data.Value).State.Id,
        //            Name = ((Crystal.CustomerManagement.Data)data.Value).State.Name,
        //        },
        //        City = ((Crystal.CustomerManagement.Data)data.Value).City,
        //        Pin = ((Crystal.CustomerManagement.Data)data.Value).Pin,
        //        ContactNumberList = ((Crystal.CustomerManagement.Data)data.Value).ContactNumberList == null ? null : GetContactNumberList(((Crystal.CustomerManagement.Data)data.Value).ContactNumberList),
        //        Email = ((Crystal.CustomerManagement.Data)data.Value).Email,
        //        IdentityProofType = ((Crystal.CustomerManagement.Data)data.Value).IdentityProofType == null ? null : new Configuration.IdentityProofType.Dto()
        //        {
        //            Id = ((Crystal.CustomerManagement.Data)data.Value).IdentityProofType.Id,
        //            Name = ((Crystal.CustomerManagement.Data)data.Value).IdentityProofType.Name,
        //        },
        //        IdentityProofName = ((Crystal.CustomerManagement.Data)data.Value).IdentityProof,
                
        //    };


        //    return customerDto;
        //}

        //private List<AutoTourism.Facade.Library.ContactNumberDto> GetContactNumberList(List<Crystal.CustomerManagement.ContactNumberData> ContactNumberDataList)
        //{
        //    List<AutoTourism.Facade.Library.ContactNumberDto> ContactNumberDtoList = new List<AutoTourism.Facade.Library.ContactNumberDto>();
        //    foreach (Crystal.CustomerManagement.ContactNumberData data in ContactNumberDataList)
        //    {
        //        ContactNumberDtoList.Add(new AutoTourism.Facade.Library.ContactNumberDto()
        //        {
        //            Id = data.Id,
        //            Name = data.ContactNumber,
        //        });
        //    }
        //    return ContactNumberDtoList;
        //}

        //private String GetRooms(List<Facade.Configuration.Room.Dto> roomList)
        //    {
        //        if (roomList == null || roomList.Count == 0)
        //            return String.Empty;

        //        StringBuilder strbRoom = new StringBuilder();
        //        foreach (Facade.Configuration.Room.Dto room in roomList)
        //            strbRoom.Append(", " + room.Number.ToString());

        //        return strbRoom.ToString().Substring(1);
        //    }

        //private ReturnObject<List<Table>> GetLodgeReservationStatus()
        //{
            
        //    List<Table> reservationStatusList = new List<Table>();
        //    Crystal.Lodge.Reservation.IReservation reservation = new Server(null);

        //    ReturnObject<List<BinAff.Core.Table>> StatusList = reservation.GetAllReservationStatus();

        //    foreach (BinAff.Core.Table data in StatusList.Value)
        //    {
        //        reservationStatusList.Add(new Table() { 
        //            Id = data.Id,
        //            Name = data.Name,
        //        });                
        //    }

        //    return new ReturnObject<List<Table>>()
        //    {
        //        Value = reservationStatusList,
        //    };
        //}

        //private ReturnObject<Boolean> UpdateReservationStatus(Dto dto)
        //{
        //    ICrud crud = new Server(new Crystal.Lodge.Reservation.Data
        //    {
        //        Id = dto.Id,
        //        BookingStatusId = dto.BookingStatusId,
        //    });
        //    return crud.Save();
        //}

        public enum RoomStatus
        {
            Unoccupied = 10001,
            Occupied = 10002,
            Closed = 10003
        }

    }

}
