
using System;
using System.Collections.Generic;

using BinAff.Core;

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

            //Crystal.Lodge.Reservation.IReservation reservation = new Server(null);
            //ReturnObject<List<BinAff.Core.Data>> reservationDataList = reservation.GetBookingSearch(bookingStatusId, startDate, endDate);

            //foreach (BinAff.Core.Data data in reservationDataList.Value)
            //{
            //    Dto regDto = new Dto()
            //    {
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
            //    regDto.BookingTo = regDto.BookingFrom.AddDays(regDto.NoOfDays);
            //    regDto.Name = regDto.Customer == null ? String.Empty : regDto.Customer.FirstName + " " + regDto.Customer.MiddleName + " " + regDto.Customer.LastName;
            //    regDto.ContactNumber = regDto.Customer == null ? String.Empty : regDto.Customer.ContactNumberList[0].Name;
            //    regDto.Room = GetRooms(regDto.RoomList);
            //    bookingList.Add(regDto);
            //}

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
    }

}
