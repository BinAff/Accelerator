using System;
using System.Collections.Generic;
using BinAff.Core;

namespace Crystal.Invoice.Component
{
    public interface IInvoice
    {
        ReturnObject<List<BinAff.Core.Data>> GetList(DateTime startDate, DateTime endDate);
    }
}
