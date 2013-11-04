using System;
using BinAff.Core;
using System.Collections.Generic;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public interface ICheckIn
    {
        ReturnObject<FormDto> LoadForm();
        ReturnObject<Boolean> Save(Dto dto);

        ReturnObject<List<CheckInRegisterDto>> Search(Int64 reservationStatusId, DateTime startDate, DateTime endDate);
        ReturnObject<CheckInRegisterFormDto> LoadCheckInRegisterForm(Int64 reservationStatusId, DateTime startDate, DateTime endDate);
    }
}
