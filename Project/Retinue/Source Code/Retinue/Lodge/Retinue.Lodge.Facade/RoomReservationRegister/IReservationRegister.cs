using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Facade.RoomReservationRegister
{

    public interface IReservationRegister
    {

        ReturnObject<FormDto> LoadRegisterForm(Int64 statusId, DateTime startDate, DateTime endDate);
        ReturnObject<List<Dto>> Search(Int64 statusId, DateTime startDate, DateTime endDate);

    }

}
