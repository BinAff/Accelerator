using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinAff.Core;

namespace Crystal.Customer.Component.Action
{
    public interface IAction
    {
         ReturnObject<List<Data>> Search(Status.Data status, DateTime startDate, DateTime endDate);
         ReturnObject<Boolean> UpdateStatus(Status.Data status);
    }
}
