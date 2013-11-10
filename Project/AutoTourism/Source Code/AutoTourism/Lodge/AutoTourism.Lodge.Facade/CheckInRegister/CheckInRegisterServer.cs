using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private ReturnObject<List<Dto>> GetCheckInSearchRecords(Int64 reservationStatusId, DateTime startDate, DateTime endDate)
        {
            List<Dto> checkInList = new List<Dto>();
            //Crystal.Lodge.CheckIn.ICheckIn checkIn = new Server(null);

            //ReturnObject<List<BinAff.Core.Data>> checkInDataList = checkIn.GetCheckInSearch(startDate, endDate);

            //foreach (BinAff.Core.Data data in checkInDataList.Value)
            //{
            //    CheckInRegisterDto regDto = new CheckInRegisterDto()
            //    {
            //        Id = data.Id,
            //        CheckInDate = ((Crystal.Lodge.CheckIn.Data)data).Date,
            //        InvoiceId = ((Crystal.Lodge.CheckIn.Data)data).InvoiceId,
            //        Advance = ((Crystal.Lodge.CheckIn.Data)data).Advance,
            //        Reservation = GetReservationDto(((Crystal.Lodge.CheckIn.Data)data).Reservation),

            //    };

            //    regDto.Name = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.Initial.Name + " " +
            //        regDto.Reservation.Customer.FirstName + " " + regDto.Reservation.Customer.MiddleName + " " + regDto.Reservation.Customer.LastName;
            //    regDto.ContactNumber = regDto.Reservation.Customer == null ? String.Empty : regDto.Reservation.Customer.ContactNumberList[0].Name;
            //    regDto.StartDate = regDto.Reservation.BookingFrom;
            //    regDto.EndDate = regDto.Reservation.BookingFrom.AddDays(regDto.Reservation.NoOfDays);
            //    regDto.Room = GetRooms(regDto.Reservation.RoomList);

            //    if (((Crystal.Lodge.CheckIn.Data)data).Reservation.BookingStatusId == reservationStatusId)
            //        checkInList.Add(regDto);
            //}

            return new ReturnObject<List<Dto>>()
            {
                Value = checkInList,
            };
        }
    }
}
