using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Accountant.Component.Invoice
{

    public interface IInvoice
    {

        //ReturnObject<List<Data>> GetList(DateTime startDate, DateTime endDate);
        ReturnObject<Data> GetInvoice(String invoiceNumber);
        List<Crystal.Accountant.Component.Payment.Data> ReadInvoicePayment(String invoiceNumber);

    }

}
