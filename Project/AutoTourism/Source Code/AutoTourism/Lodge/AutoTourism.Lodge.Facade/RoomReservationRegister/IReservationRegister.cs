using System;

using BinAff.Core;

namespace AutoTourism.Lodge.Facade.RoomReservationRegister
{
    public interface IReservationRegister
    {
        ReturnObject<FormDto> LoadRegisterForm(Int64 statusId, DateTime startDate, DateTime endDate);
    }
}
