using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Lodge.Facade.RoomReservationRegister
{
    public interface IReservationRegister
    {
        ReturnObject<FormDto> LoadRegisterForm(Int64 statusId, DateTime startDate, DateTime endDate);
        ReturnObject<List<Dto>> Search(Int64 statusId, DateTime startDate, DateTime endDate);
    }
}
