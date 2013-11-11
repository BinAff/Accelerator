using System;
using BinAff.Core;
using System.Collections.Generic;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public interface IReservation
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Save(Dto dto);
        //ReturnObject<List<Dto>> GetBooking(Int64 customerId);
        
       
        //ReturnObject<RoomReservationRegisterFormDto> LoadRegisterForm(Int64 statusId, DateTime startDate, DateTime endDate);

        ReturnObject<Boolean> ChangeReservationStatus(Dto dto);
    }
}
