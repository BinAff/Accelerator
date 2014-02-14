
using System;
using System.Collections.Generic;
using System.Text;

using BinAff.Core;

using CrystalLodge = Crystal.Lodge.Component;
using CrystalAction = Crystal.Customer.Component.Action;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using CrystalReservation = Crystal.Reservation.Component;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using AutoCustomer = AutoTourism.Component.Customer;

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
                    configurationRuleDto = this.ReadConfigurationRule().Value
                }
            };

            return ret;
        }

        ReturnObject<List<Dto>> IReservationRegister.Search(Int64 bookingStatusId, DateTime startDate, DateTime endDate)
        {
            return this.GetBookingSearchRecords(bookingStatusId, startDate, endDate);
        }

        private ReturnObject<List<Dto>> GetBookingSearchRecords(Int64 bookingStatusId, DateTime startDate, DateTime endDate)
        {
            List<Dto> bookingList = new List<Dto>();           

            CrystalAction.IAction action = new CrystalLodge.Room.Reservation.Server(null);            
            ReturnObject<List<CrystalAction.Data>> reservationDataList = action.Search(new CrystalAction.Status.Data { Id = bookingStatusId }, startDate, endDate);
            
            foreach (Data data in reservationDataList.Value)
            {
                Dto regDto = this.Convert(new RoomReservation.ReservationServer(null).Convert(data));
                bookingList.Add(regDto);
            }

            return new ReturnObject<List<Dto>>()
            {
                Value = bookingList,
            };
        }

        private Dto Convert(BinAff.Facade.Library.Dto libDto)
        {
            RoomReservation.Dto reservation = libDto as RoomReservation.Dto;
            Dto reservationDto = new Dto 
            {
                Id = reservation.Id,
                NoOfDays = reservation.NoOfDays,
                NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                BookingFrom = reservation.BookingFrom,
                BookingTo = reservation.BookingFrom.AddDays(reservation.NoOfDays),
                Advance = reservation.Advance,
                AdvanceDisplay = reservation.Advance == 0 ? String.Empty : reservation.Advance.ToString(),
                BookingStatusId = reservation.BookingStatusId,
                RoomList = reservation.RoomList,
                RoomCategory = reservation.RoomCategory,
                RoomType = reservation.RoomType,
                IsAC = reservation.IsAC,
                BookingDate = reservation.BookingDate,
                Room = reservation.RoomList == null ? String.Empty : this.GetRooms(reservation.RoomList)
            };

            AutoCustomer.ICustomer autoCustomer = new AutoCustomer.Server(null);
            reservationDto.Customer = new RoomReservation.ReservationServer(null).ConvertToCustomerDto(autoCustomer.GetCustomerForReservation(reservation.Id));

            reservationDto.ContactNumber = (reservationDto.Customer == null || reservationDto.Customer.ContactNumberList == null) ? String.Empty : this.GetCustomerContactNumber(reservationDto.Customer.ContactNumberList);

            //--every reservation must have a customer
            String Name = (reservationDto.Customer.Initial == null ? String.Empty : reservationDto.Customer.Initial.Name);
            Name += (Name == String.Empty) ? (reservationDto.Customer.FirstName == null ? String.Empty : reservationDto.Customer.FirstName) : " " + (reservationDto.Customer.FirstName == null ? String.Empty : reservationDto.Customer.FirstName);
            Name += (Name == String.Empty) ? (reservationDto.Customer.MiddleName == null ? String.Empty : reservationDto.Customer.MiddleName) : " " + (reservationDto.Customer.MiddleName == null ? String.Empty : reservationDto.Customer.MiddleName);
            Name += (Name == String.Empty) ? (reservationDto.Customer.LastName == null ? String.Empty : reservationDto.Customer.LastName) : " " + (reservationDto.Customer.LastName == null ? String.Empty : reservationDto.Customer.LastName);

            reservationDto.Name = Name;

            return reservationDto;
        }

        private ReturnObject<List<Table>> GetLodgeReservationStatus()
        {
            List<Table> reservationStatusList = new List<Table>();
            ICrud crud = new Crystal.Reservation.Component.Status.Server(null);
            ReturnObject<List<Data>> StatusList = crud.ReadAll();
            foreach (Data data in StatusList.Value)
            {
                reservationStatusList.Add(new Table()
                        {                    
                            Id = data.Id,
                            Name = ((CrystalReservation.Status.Data)data).Name,
                        });
            }

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

        private String GetRooms(List<LodgeConfigurationFacade.Room.Dto> roomList)
        {
            if (roomList == null || roomList.Count == 0)
                return String.Empty;

            StringBuilder strbRoom = new StringBuilder();
            foreach (LodgeConfigurationFacade.Room.Dto room in roomList)
            {
                if (room.Number != null)
                    strbRoom.Append(", " + room.Number.ToString());
            }

            return strbRoom.ToString().IndexOf(",") > -1 ? strbRoom.ToString().Substring(1) : String.Empty;            
        }

        private ReturnObject<RuleFacade.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFacade.RuleServer().ReadConfigurationRule();
        }

        private String GetCustomerContactNumber(List<Table> customerContactNumberList)
        {
            if (customerContactNumberList == null || customerContactNumberList.Count == 0)
                return String.Empty;

            StringBuilder strbContactNumber = new StringBuilder();
            foreach (Table table in customerContactNumberList)
            {
                if (table.Name != null)
                    strbContactNumber.Append(", " + table.Name);
            }

            return strbContactNumber.ToString().IndexOf(",") > -1 ? strbContactNumber.ToString().Substring(1) : String.Empty;  
        }

    }

}
