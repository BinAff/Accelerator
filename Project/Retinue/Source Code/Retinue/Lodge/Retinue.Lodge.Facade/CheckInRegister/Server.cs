using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Text;

using CrystalLodge = Retinue.Lodge.Component;
using CrystalAction = Crystal.Customer.Component.Action;
using LodgeFacade = Retinue.Lodge.Facade;
using LodgeConfFac = Retinue.Lodge.Configuration.Facade;

using RoomDtlsFac = Retinue.Lodge.Facade.RoomReservation.RoomDetails;

namespace Retinue.Lodge.Facade.CheckInRegister
{

    public class Server : ICheckInRegister
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
                    //InvoiceId = ((Retinue.Lodge.CheckIn.Data)data).InvoiceId,
                    //Advance = ((CrystalLodge.Room.CheckIn.Data)data).Advance,
                    Reservation = GetReservationDto(((CrystalLodge.Room.CheckIn.Data)data).Reservation),

                };

                regDto.Name = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.Name;
                //regDto.Name = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.Initial.Name + " " +
                //    regDto.Reservation.Customer.FirstName + " " + regDto.Reservation.Customer.MiddleName + " " + regDto.Reservation.Customer.LastName;
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
            //ICrud crud = new Retinue.Lodge.Reservation.Server(data);
            //ReturnObject<BinAff.Core.Data> retData = crud.Read();

            //Retinue.Facade.LodgeManagement.Reservation.Dto dto = new Reservation.Dto()
            //{
            //    Id = data.Id,
            //    BookingDate = ((Retinue.Lodge.Reservation.Data)data).BookingDate,
            //    BookingFrom = ((Retinue.Lodge.Reservation.Data)data).BookingFrom,
            //    NoOfDays = ((Retinue.Lodge.Reservation.Data)data).NoOfDays,
            //    NoOfPersons = ((Retinue.Lodge.Reservation.Data)data).NoOfPersons,
            //    NoOfRooms = ((Retinue.Lodge.Reservation.Data)data).NoOfRooms,
            //    Advance = ((Retinue.Lodge.Reservation.Data)data).Advance,
            //    BookingStatusId = ((Retinue.Lodge.Reservation.Data)data).BookingStatusId,
            //    RoomList = GetRoomDtoList(((Retinue.Lodge.Reservation.Data)data).RoomList),

            //    //call the customer component read method
            //    Customer = ((Retinue.Lodge.Reservation.Data)data).Customer == null ? null : ReadCustomer(((Retinue.Lodge.Reservation.Data)data).Customer.Id),

            //};

            //return dto;
        }

        private String GetRooms(List<RoomDtlsFac.Dto> productList)
        {
            if (productList == null || productList.Count == 0)
                return String.Empty;

            StringBuilder strbRoom = new StringBuilder();
            foreach (RoomDtlsFac.Dto room in productList)
                strbRoom.Append(", " + room.Room.Number.ToString());

            return strbRoom.ToString().Substring(1);
        }

    }

}
