using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinAff.Core;

namespace Crystal.Reservation.Component
{
    public interface IReservation
    {
         ReturnObject<List<Data>> Search(Status.Data status, DateTime startDate, DateTime endDate);
         ReturnObject<Boolean> UpdateStatus(Status.Data status);
    }
}
