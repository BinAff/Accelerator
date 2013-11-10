
using System;

using BinAff.Core;

namespace AutoTourism.Lodge.Facade.CheckInRegister
{
    public interface ICheckInRegister
    {
        ReturnObject<FormDto> LoadCheckInRegisterForm(Int64 reservationStatusId, DateTime startDate, DateTime endDate);
    }
}
