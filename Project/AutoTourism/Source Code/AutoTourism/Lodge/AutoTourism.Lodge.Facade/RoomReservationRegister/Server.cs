using System;
using System.Collections.Generic;
using System.Text;

using BinAff.Core;

using LodgeCrys = Crystal.Lodge.Component;
using ActionCrys = Crystal.Customer.Component.Action;
using RoomRsvCrys = Crystal.Reservation.Component;

using LodgeConfFac = AutoTourism.Lodge.Configuration.Facade;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using CustAuto = AutoTourism.Component.Customer;

namespace AutoTourism.Lodge.Facade.RoomReservationRegister
{

    public class Server : IReservationRegister
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

            ActionCrys.IAction action = new LodgeCrys.Room.Reservation.Server(null);            
            ReturnObject<List<ActionCrys.Data>> reservationDataList = action.Search(new ActionCrys.Status.Data { Id = bookingStatusId }, startDate, endDate);
            
            foreach (Data data in reservationDataList.Value)
            {
                Dto regDto = this.Convert(new RoomReservation.Server(null).Convert(data));
                
                //Filter reservation :  avoid reservations without customer
                if (regDto.Customer != null && !regDto.isCheckedIn)              
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
                //NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                BookingFrom = reservation.BookingFrom,
                BookingTo = reservation.BookingFrom.AddDays(reservation.NoOfDays),
                NoOfMale = reservation.NoOfMale,
                NoOfFemale = reservation.NoOfFemale,
                NoOfChild = reservation.NoOfChild,
                NoOfInfant = reservation.NoOfInfant,
                Remark = reservation.Remark,
                ReservationNo = reservation.ReservationNo,
                //Advance = reservation.Advance,
                //AdvanceDisplay = reservation.Advance == 0 ? String.Empty : reservation.Advance.ToString(),
                BookingStatusId = reservation.BookingStatusId,
                RoomList = reservation.RoomList,
                RoomCategory = reservation.RoomCategory,
                RoomType = reservation.RoomType,
                ACPreference = reservation.ACPreference,
                BookingDate = reservation.BookingDate,
                isCheckedIn = reservation.isCheckedIn,
                Room = reservation.RoomList == null ? String.Empty : this.GetRooms(reservation.RoomList)
            };

            CustAuto.ICustomer CustAuto = new CustAuto.Server(null);
                      
            reservationDto.Customer = new RoomReservation.Server(null).ConvertToCustomerDto(CustAuto.GetCustomerForReservation(reservation.Id));

            reservationDto.ContactNumber = (reservationDto.Customer == null || reservationDto.Customer.ContactNumberList == null) ? String.Empty : this.GetCustomerContactNumber(reservationDto.Customer.ContactNumberList);

            //--every reservation must have a customer            
            reservationDto.Name = reservationDto.Customer == null ? String.Empty : reservationDto.Customer.Name;

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
                            Name = ((RoomRsvCrys.Status.Data)data).Name,
                        });
            }

            return new ReturnObject<List<Table>>()
            {
                Value = reservationStatusList,
            };
        }

        private List<LodgeConfFac.Room.Dto> GetRoomDtoList(List<Data> RoomDataList)
        {
            List<LodgeConfFac.Room.Dto> retVal = null;
            if (RoomDataList != null)
            {
                retVal = new List<LodgeConfFac.Room.Dto>();
                foreach (Data data in RoomDataList)
                {

                    retVal.Add(new LodgeConfFac.Room.Dto()
                    {
                        Id = data.Id,
                        Number = ((LodgeCrys.Room.Data)data).Number,
                        Name = ((LodgeCrys.Room.Data)data).Name,
                        Description = ((LodgeCrys.Room.Data)data).Description,
                        Building = new LodgeConfFac.Building.Dto()
                        {
                            Id = ((LodgeCrys.Room.Data)data).Building.Id,                            
                        },
                        StatusId = ((LodgeCrys.Room.Data)data).Status.Id
                    });
                }
            }
            return retVal;
        }

        private String GetRooms(List<LodgeConfFac.Room.Dto> roomList)
        {
            if (roomList == null || roomList.Count == 0)
                return String.Empty;

            StringBuilder strbRoom = new StringBuilder();
            foreach (LodgeConfFac.Room.Dto room in roomList)
            {
                if (room.Number != null)
                    strbRoom.Append(", " + room.Number.ToString());
            }

            return strbRoom.ToString().IndexOf(",") > -1 ? strbRoom.ToString().Substring(1) : String.Empty;            
        }

        private ReturnObject<RuleFac.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFac.RuleServer().ReadConfigurationRule();
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
