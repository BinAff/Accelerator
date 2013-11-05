using System;
using System.Collections.Generic;
using BinAff.Core;
//using Crystal.Lodge.CheckIn;
//using System.Transactions;
using System.Text;

using CrystalLodge = Crystal.Lodge.Component;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class CheckInServer : ICheckIn
    {
        public enum LodgeReservationStatus
        {
            Open = 10001,
            Closed = 10002,
            Cancel = 10003,
            CheckIn = 10004,
            Modify = 10005
        }

        public enum RoomStatus
        {
            Unoccupied = 10001,
            Occupied = 10002,
            Closed = 10003
        }

        ReturnObject<FormDto> ICheckIn.LoadForm()
        {
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    //roomList = this.ReadAllRoom().Value,
                }
            };

            return ret;
        }

        ReturnObject<Boolean> ICheckIn.Save(Dto dto)
        {
            return this.SaveCheckIn(dto);
        }

        ReturnObject<CheckInRegisterFormDto> ICheckIn.LoadCheckInRegisterForm(Int64 reservationStatusId, DateTime startDate, DateTime endDate)
        {
            BinAff.Core.ReturnObject<CheckInRegisterFormDto> ret = new BinAff.Core.ReturnObject<CheckInRegisterFormDto>()
            {
                Value = new CheckInRegisterFormDto()
                {
                    //CheckInRegisterDtoList = this.GetCheckInSearchRecords(reservationStatusId, startDate, endDate).Value,                   
                }
            };

            return ret;
        }

        ReturnObject<List<CheckInRegisterDto>> ICheckIn.Search(Int64 reservationStatusId, DateTime startDate, DateTime endDate)
        {
            //return this.GetCheckInSearchRecords(reservationStatusId, startDate, endDate);
            return new ReturnObject<List<CheckInRegisterDto>>();
        }
        
        private ReturnObject<Boolean> SaveCheckIn(Dto dto)
        {
            ReturnObject<Boolean> retObj = new ReturnObject<Boolean>()
            {
                Value = true,
                MessageList = new List<Message>()
            };

            //using (TransactionScope T = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(1, 0, 0)))
            //{
            //    Crystal.Lodge.Reservation.Data reservationData = new Crystal.Lodge.Reservation.Data() { 
            //        Id = dto.Reservation.Id,    
            //        BookingStatusId = dto.Reservation.BookingStatusId,
            //        BookingFrom = dto.Reservation.BookingFrom,
            //        NoOfDays = dto.Reservation.NoOfDays,
            //        NoOfPersons = dto.Reservation.NoOfPersons,
            //        NoOfRooms = dto.Reservation.NoOfRooms,
            //        Advance = dto.Advance,
            //        Customer = dto.Reservation.Customer == null ? null : new Crystal.CustomerManagement.Data()
            //        {
            //            Id = dto.Reservation.Customer.Id,
            //        },
            //        RoomList = dto.RoomList == null ? null : GetRoomDataList(dto.RoomList),
            //    };

            //    if (dto.Reservation.BookingStatusId == Convert.ToInt64(LodgeReservationStatus.Modify))
            //    {
            //        //Step1 : Call Reservation Component to update the ReservationStatus To Modify
            //        Crystal.Lodge.Reservation.IReservation reservation = new Crystal.Lodge.Reservation.Server(reservationData);
            //        retObj = reservation.UpdateReservationStatus();
            //        if (!retObj.Value) return retObj;

            //        //Step2 : Call Reservation Component to create a new Reservation
            //        reservationData.Id = 0; //for new insert
            //        ICrud crudReservation = new Crystal.Lodge.Reservation.Server(reservationData);
            //        retObj = crudReservation.Save();
            //        if (!retObj.Value) return retObj;

            //    }

            //    //Call Reservation Component to update the Reservation Status to CheckIn                   
            //    reservationData.BookingStatusId = Convert.ToInt64(LodgeReservationStatus.CheckIn);
            //    Crystal.Lodge.Reservation.IReservation rsrvn = new Crystal.Lodge.Reservation.Server(reservationData);
            //    retObj = rsrvn.UpdateReservationStatus();
            //    if (!retObj.Value) return retObj;

            //    //Save CheckIn Data
            //    ICrud crud = new Server(new Crystal.Lodge.CheckIn.Data
            //    {
            //        Id = dto.Id,
            //        Advance = dto.Advance,
            //        Reservation = new Crystal.Lodge.Reservation.Data() { Id = reservationData.Id },
            //        RoomList = dto.RoomList == null ? null : GetRoomDataList(dto.RoomList),
            //    });

            //    retObj = crud.Save();
            //    if (!retObj.Value) return retObj;

            //    Crystal.Lodge.Reservation.IReservation resrvn = new Crystal.Lodge.Reservation.Server(reservationData);
            //    Boolean retVal = resrvn.CreateRoomBooked(reservationData.RoomList, reservationData.Id);
            //    if (!retVal) {
            //        retObj.Value = false;
            //        return retObj;
            //    } 

            //    //Room Room component to change the room status to occupied
            //    foreach (Crystal.Lodge.Configuration.Room.Data data in reservationData.RoomList)
            //    {
            //        Crystal.Lodge.Configuration.Room.IRoom roomServer = new Crystal.Lodge.Configuration.Room.Server(new Crystal.Lodge.Configuration.Room.Data() {
            //            Id = data.Id,
            //            StatusId = Convert.ToInt64(RoomStatus.Occupied),
            //        });
            //        retObj = roomServer.UpdateRoomStatus();
            //        if (!retObj.Value) return retObj;
            //    }

              
            //    T.Complete();
            //}

            //retObj.MessageList.Clear();
            //retObj.MessageList.Add(new Message("Reservation is checked in successfully.",Message.Type.Information));
            return retObj;
                        
        }

        //private List<CrystalLodge.Room.Data> GetRoomDataList(List<LodgeConfigurationFacade.Room.Dto> RoomList)
        //{
        //    List<CrystalLodge.Room.Data> RoomDataList = new List<CrystalLodge.Room.Data>();
        //    foreach (LodgeConfigurationFacade.Room.Dto dto in RoomList)
        //    {
        //        RoomDataList.Add(new CrystalLodge.Room.Data()
        //        {                    
        //            Id = dto.Id,
        //            Number = dto.Number,
        //        });
        //    }
        //    return RoomDataList;
        //}

        //private ReturnObject<List<AutoTourism.Facade.Configuration.Room.Dto>> ReadAllRoom()
        //{
        //    ICrud crud = new Crystal.Lodge.Configuration.Room.Server(null);
        //    ReturnObject<List<BinAff.Core.Data>> lstData = crud.ReadAll();

        //    if (lstData.HasError())
        //    {
        //        return new ReturnObject<List<AutoTourism.Facade.Configuration.Room.Dto>>
        //        {
        //            MessageList = lstData.MessageList
        //        };
        //    }

        //    ReturnObject<List<AutoTourism.Facade.Configuration.Room.Dto>> ret = new ReturnObject<List<AutoTourism.Facade.Configuration.Room.Dto>>
        //    {
        //        Value = new List<AutoTourism.Facade.Configuration.Room.Dto>(),
        //    };

        //    //Populate data in dto from business entity
        //    foreach (BinAff.Core.Data data in lstData.Value)
        //    {
        //        if (((Crystal.Lodge.Configuration.Room.Data)data).StatusId != Convert.ToInt64(RoomStatus.Closed))
        //        {
        //            ret.Value.Add(new AutoTourism.Facade.Configuration.Room.Dto
        //            {
        //                Id = data.Id,
        //                Number = ((Crystal.Lodge.Configuration.Room.Data)data).Number,
        //                Name = ((Crystal.Lodge.Configuration.Room.Data)data).Name,
        //                Description = ((Crystal.Lodge.Configuration.Room.Data)data).Description,
        //                Building = new AutoTourism.Facade.Configuration.Building.Dto()
        //                {
        //                    Id = ((Crystal.Lodge.Configuration.Room.Data)data).Building.Id,
        //                },
        //                Floor = ((Crystal.Lodge.Configuration.Room.Data)data).Floor,
        //                Category = new AutoTourism.Facade.Configuration.RoomCategory.Dto()
        //                {
        //                    Id = ((Crystal.Lodge.Configuration.Room.Data)data).Category.Id,
        //                },
        //                Type = new AutoTourism.Facade.Configuration.RoomType.Dto()
        //                {
        //                    Id = ((Crystal.Lodge.Configuration.Room.Data)data).Type.Id,
        //                },
        //                IsAirconditioned = ((Crystal.Lodge.Configuration.Room.Data)data).IsAirConditioned,
        //                IsDormitory = ((Crystal.Lodge.Configuration.Room.Data)data).IsDormitory,
        //                StatusId = ((Crystal.Lodge.Configuration.Room.Data)data).StatusId,
        //            });
        //        }
        //    }

        //    return ret;
        //}

        //private ReturnObject<List<CheckInRegisterDto>> GetCheckInSearchRecords(Int64 reservationStatusId, DateTime startDate, DateTime endDate)
        //{
        //    List<CheckInRegisterDto> checkInList = new List<CheckInRegisterDto>();
        //    Crystal.Lodge.CheckIn.ICheckIn checkIn = new Server(null);

        //    ReturnObject<List<BinAff.Core.Data>> checkInDataList = checkIn.GetCheckInSearch(startDate, endDate);
                        
        //    foreach (BinAff.Core.Data data in checkInDataList.Value)
        //    {               
        //        CheckInRegisterDto regDto = new CheckInRegisterDto()
        //        {
        //            Id = data.Id,
        //            CheckInDate = ((Crystal.Lodge.CheckIn.Data)data).Date,
        //            InvoiceId = ((Crystal.Lodge.CheckIn.Data)data).InvoiceId,
        //            Advance = ((Crystal.Lodge.CheckIn.Data)data).Advance,                   
        //            Reservation = GetReservationDto(((Crystal.Lodge.CheckIn.Data)data).Reservation),

        //        };

        //        regDto.Name = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.Initial.Name + " " +
        //            regDto.Reservation.Customer.FirstName + " " + regDto.Reservation.Customer.MiddleName + " " + regDto.Reservation.Customer.LastName;
        //        regDto.ContactNumber = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.ContactNumberList[0].Name;
        //        regDto.StartDate = regDto.Reservation.BookingFrom;
        //        regDto.EndDate = regDto.Reservation.BookingFrom.AddDays(regDto.Reservation.NoOfDays);
        //        regDto.Room = GetRooms(regDto.Reservation.RoomList);
                   
        //        if (((Crystal.Lodge.CheckIn.Data)data).Reservation.BookingStatusId == reservationStatusId)                    
        //            checkInList.Add(regDto);
        //    }

        //    return new ReturnObject<List<CheckInRegisterDto>>()
        //    {
        //        Value = checkInList,
        //    };
        //}

        //private AutoTourism.Facade.LodgeManagement.Reservation.Dto GetReservationDto(Crystal.Lodge.Reservation.Data data)
        //{
        //    ICrud crud = new Crystal.Lodge.Reservation.Server(data);
        //    ReturnObject<BinAff.Core.Data> retData = crud.Read();

        //    AutoTourism.Facade.LodgeManagement.Reservation.Dto dto = new Reservation.Dto() {
        //        Id = data.Id,
        //        BookingDate = ((Crystal.Lodge.Reservation.Data)data).BookingDate,
        //        BookingFrom = ((Crystal.Lodge.Reservation.Data)data).BookingFrom,
        //        NoOfDays = ((Crystal.Lodge.Reservation.Data)data).NoOfDays,
        //        NoOfPersons = ((Crystal.Lodge.Reservation.Data)data).NoOfPersons,
        //        NoOfRooms = ((Crystal.Lodge.Reservation.Data)data).NoOfRooms,
        //        Advance = ((Crystal.Lodge.Reservation.Data)data).Advance,
        //        BookingStatusId = ((Crystal.Lodge.Reservation.Data)data).BookingStatusId,
        //        RoomList = GetRoomDtoList(((Crystal.Lodge.Reservation.Data)data).RoomList),

        //        //call the customer component read method
        //        Customer = ((Crystal.Lodge.Reservation.Data)data).Customer == null ? null : ReadCustomer(((Crystal.Lodge.Reservation.Data)data).Customer.Id),
                    
        //    };

        //    return dto;
        //}

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
        //                IsAirconditioned = data.IsAirConditioned,
        //                Description = data.Description,
        //                Building = new Configuration.Building.Dto()
        //                {
        //                    Id = data.Building.Id,
        //                },
        //                IsDormitory = data.IsDormitory,
        //                StatusId = data.StatusId,
        //                Category = new Configuration.RoomCategory.Dto() { Id = data.Category.Id },
        //                Type = new Configuration.RoomType.Dto() { Id = data.Type.Id }
        //            });
        //        }
        //    }
        //    return retVal;
        //}

        //private AutoTourism.Facade.CustomerManagement.Dto ReadCustomer(Int64 customerId)
        //{

        //    ICrud crud = new Crystal.CustomerManagement.Server(new Crystal.CustomerManagement.Data() { Id = customerId });
        //    ReturnObject<BinAff.Core.Data> data = crud.Read();

        //    AutoTourism.Facade.CustomerManagement.Dto customerDto = new CustomerManagement.Dto()
        //    {
        //        Id = data.Value.Id,
        //        Initial = ((Crystal.CustomerManagement.Data)data.Value).Initial == null ? null : new Configuration.Initial.Dto()
        //        {
        //            Id = ((Crystal.CustomerManagement.Data)data.Value).Initial.Id,
        //            Name = ((Crystal.CustomerManagement.Data)data.Value).Initial.Name,
        //        },
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
        //{
        //    if (roomList == null || roomList.Count == 0)
        //        return String.Empty;

        //    StringBuilder strbRoom = new StringBuilder();
        //    foreach (Facade.Configuration.Room.Dto room in roomList)
        //        strbRoom.Append(", " + room.Number.ToString());

        //    return strbRoom.ToString().Substring(1);
        //}

    }
}
