﻿
using System;
using System.Collections.Generic;

using BinAff.Core;

using CrystalLodge = Crystal.Lodge.Component;
using CrystalAction = Crystal.Customer.Component.Action;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservationRegister
{
    public class ReservationRegisterServer : IReservationRegister
    {
        ReturnObject<FormDto> IReservationRegister.LoadRegisterForm(Int64 bookingStatusId, DateTime startDate, DateTime endDate)
        {
            ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    RoomReservationDtoList = this.GetBookingSearchRecords(bookingStatusId, startDate, endDate).Value,
                    StatusList = this.GetLodgeReservationStatus().Value,
                }
            };

            return ret;
        }

        private ReturnObject<List<Dto>> GetBookingSearchRecords(Int64 bookingStatusId, DateTime startDate, DateTime endDate)
        {
            List<Dto> bookingList = new List<Dto>();
           

            CrystalAction.IAction action = new CrystalLodge.Room.Reservation.Server(null);            
            ReturnObject<List<CrystalAction.Data>> reservationDataList = action.Search(new CrystalAction.Status.Data { Id = bookingStatusId }, startDate, endDate);
            

            foreach (BinAff.Core.Data data in reservationDataList.Value)
            {
                Dto regDto = new Dto
                {
                   BookingFrom = ((Crystal.Lodge.Component.Room.Reservation.Data)data).ActivityDate,
                   NoOfDays = ((Crystal.Lodge.Component.Room.Reservation.Data)data).NoOfDays,
                   NoOfPersons = ((Crystal.Lodge.Component.Room.Reservation.Data)data).NoOfPersons,
                   NoOfRooms = ((Crystal.Lodge.Component.Room.Reservation.Data)data).NoOfRooms,
                   Advance = ((Crystal.Lodge.Component.Room.Reservation.Data)data).Advance,
                   BookingStatusId = ((Crystal.Lodge.Component.Room.Reservation.Data)data).Status.Id,
                   RoomList = GetRoomDtoList(((Crystal.Lodge.Component.Room.Reservation.Data)data).ProductList),
                                        

                    ////call the customer component read method
                    //Customer = ((Crystal.Lodge.Reservation.Data)data).Customer == null ? null : ReadCustomer(((Crystal.Lodge.Reservation.Data)data).Customer.Id),

                };
                //regDto.BookingTo = regDto.BookingFrom.AddDays(regDto.NoOfDays);
                //regDto.Name = regDto.Customer == null ? String.Empty : regDto.Customer.FirstName + " " + regDto.Customer.MiddleName + " " + regDto.Customer.LastName;
                //regDto.ContactNumber = regDto.Customer == null ? String.Empty : regDto.Customer.ContactNumberList[0].Name;
                //regDto.Room = GetRooms(regDto.RoomList);
                
                bookingList.Add(regDto);
            }

            return new ReturnObject<List<Dto>>()
            {
                Value = bookingList,
            };
        }

        private ReturnObject<List<Table>> GetLodgeReservationStatus()
        {

            List<Table> reservationStatusList = new List<Table>();
            //Crystal.Lodge.Reservation.IReservation reservation = new Server(null);

            //ReturnObject<List<Table>> StatusList = reservation.GetAllReservationStatus();

            //foreach (BinAff.Core.Table data in StatusList.Value)
            //{
            //    reservationStatusList.Add(new Table()
            //    {
            //        Id = data.Id,
            //        Name = data.Name,
            //    });
            //}

            return new ReturnObject<List<Table>>()
            {
                Value = reservationStatusList,
            };
        }

        private List<LodgeConfigurationFacade.Room.Dto> GetRoomDtoList(List<Data> RoomDataList)
        {
            List<LodgeConfigurationFacade.Room.Dto> retVal = null;
            if (RoomDataList != null)
            {
                retVal = new List<LodgeConfigurationFacade.Room.Dto>();
                foreach (Data data in RoomDataList)
                {

                    retVal.Add(new LodgeConfigurationFacade.Room.Dto()
                    {
                        Id = data.Id,
                        Number = ((CrystalLodge.Room.Data)data).Number,
                        Name = ((CrystalLodge.Room.Data)data).Name,
                        Description = ((CrystalLodge.Room.Data)data).Description,
                        Building = new LodgeConfigurationFacade.Building.Dto()
                        {
                            Id = ((CrystalLodge.Room.Data)data).Building.Id,                            
                        },
                        StatusId = ((CrystalLodge.Room.Data)data).Status.Id
                    });
                }
            }
            return retVal;
        }
    }

}
