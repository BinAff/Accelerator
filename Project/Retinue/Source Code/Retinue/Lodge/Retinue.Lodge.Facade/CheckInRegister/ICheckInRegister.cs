using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Facade.CheckInRegister
{

    public interface ICheckInRegister
    {

        ReturnObject<FormDto> LoadCheckInRegisterForm(Int64 reservationStatusId, DateTime startDate, DateTime endDate);
        ReturnObject<List<Dto>> Search(Int64 reservationStatusId, DateTime startDate, DateTime endDate);
    
    }

}
