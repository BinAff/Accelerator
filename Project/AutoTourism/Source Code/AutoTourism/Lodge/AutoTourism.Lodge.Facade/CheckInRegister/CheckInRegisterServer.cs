using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrystalLodge = Crystal.Lodge.Component;
using CrystalAction = Crystal.Customer.Component.Action;
using LodgeFacade = AutoTourism.Lodge.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;


namespace AutoTourism.Lodge.Facade.CheckInRegister
{
    public class CheckInRegisterServer : ICheckInRegister
    {
        ReturnObject<FormDto> ICheckInRegister.LoadCheckInRegisterForm(Int64 reservationStatusId, DateTime startDate, DateTime endDate)
        {
            ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>()
            {
                Value = new FormDto()
                {
                    CheckInRegisterDtoList = this.GetCheckInSearchRecords(reservationStatusId, startDate, endDate).Value,                   
                }
            };

            return ret;
        }

        ReturnObject<List<Dto>> ICheckInRegister.Search(Int64 reservationStatusId, DateTime startDate, DateTime endDate)
        {
            return this.GetCheckInSearchRecords(reservationStatusId, startDate, endDate);           
        }

        private ReturnObject<List<Dto>> GetCheckInSearchRecords(Int64 reservationStatusId, DateTime startDate, DateTime endDate)
        {
            List<Dto> checkInList = new List<Dto>();

            CrystalAction.IAction action = new CrystalLodge.Room.CheckIn.Server(null);
            ReturnObject<List<CrystalAction.Data>> checkInDataList = action.Search(new CrystalAction.Status.Data { Id = reservationStatusId }, startDate, endDate);
            
            foreach (Data data in checkInDataList.Value)
            {
                Dto regDto = new Dto()
                {
                    Id = data.Id,
                    CheckInDate = ((CrystalLodge.Room.CheckIn.Data)data).ActivityDate,                    
                    //InvoiceId = ((Crystal.Lodge.CheckIn.Data)data).InvoiceId,
                    Advance = ((CrystalLodge.Room.CheckIn.Data)data).Advance,
                    Reservation = GetReservationDto(((CrystalLodge.Room.CheckIn.Data)data).Reservation),

                };

                regDto.Name = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.Initial.Name + " " +
                    regDto.Reservation.Customer.FirstName + " " + regDto.Reservation.Customer.MiddleName + " " + regDto.Reservation.Customer.LastName;
                regDto.ContactNumber = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.ContactNumberList[0].Name;
                regDto.StartDate = regDto.Reservation.BookingFrom;
                regDto.EndDate = regDto.Reservation.BookingFrom.AddDays(regDto.Reservation.NoOfDays);
                regDto.Room = GetRooms(regDto.Reservation.RoomList);

                if (((CrystalLodge.Room.CheckIn.Data)data).Reservation.Status.Id == reservationStatusId)
                    checkInList.Add(regDto);
            }

            return new ReturnObject<List<Dto>>()
            {
                Value = checkInList,
            };
        }

        private LodgeFacade.RoomReservation.Dto GetReservationDto(CrystalLodge.Room.Reservation.Data data)
        {
            return new RoomReservation.Dto();
            //ICrud crud = new Crystal.Lodge.Reservation.Server(data);
            //ReturnObject<BinAff.Core.Data> retData = crud.Read();

            //AutoTourism.Facade.LodgeManagement.Reservation.Dto dto = new Reservation.Dto()
            //{
            //    Id = data.Id,
            //    BookingDate = ((Crystal.Lodge.Reservation.Data)data).BookingDate,
            //    BookingFrom = ((Crystal.Lodge.Reservation.Data)data).BookingFrom,
            //    NoOfDays = ((Crystal.Lodge.Reservation.Data)data).NoOfDays,
            //    NoOfPersons = ((Crystal.Lodge.Reservation.Data)data).NoOfPersons,
            //    NoOfRooms = ((Crystal.Lodge.Reservation.Data)data).NoOfRooms,
            //    Advance = ((Crystal.Lodge.Reservation.Data)data).Advance,
            //    BookingStatusId = ((Crystal.Lodge.Reservation.Data)data).BookingStatusId,
            //    RoomList = GetRoomDtoList(((Crystal.Lodge.Reservation.Data)data).RoomList),

            //    //call the customer component read method
            //    Customer = ((Crystal.Lodge.Reservation.Data)data).Customer == null ? null : ReadCustomer(((Crystal.Lodge.Reservation.Data)data).Customer.Id),

            //};

            //return dto;
        }

        private String GetRooms(List<LodgeConfigurationFacade.Room.Dto> roomList)
        {
            if (roomList == null || roomList.Count == 0)
                return String.Empty;

            StringBuilder strbRoom = new StringBuilder();
            foreach (LodgeConfigurationFacade.Room.Dto room in roomList)
                strbRoom.Append(", " + room.Number.ToString());

            return strbRoom.ToString().Substring(1);
        }
    }
}
