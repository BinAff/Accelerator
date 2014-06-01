using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Invoice.Component
{

    public interface IInvoice
    {

        //ReturnObject<List<Data>> GetList(DateTime startDate, DateTime endDate);
        ReturnObject<Data> GetInvoice(String invoiceNumber);
        Int64 GetInvoiceId(String invoiceNumber);
    }

}
