using System;
using System.Collections.Generic;
using BinAff.Core;

namespace Vanilla.Invoice.Facade
{

    public interface IInvoice
    {

        List<Table> CalulateTaxList(Double total, List<Taxation.Dto> taxationList);
        //ReturnObject<Crystal.Invoice.Component.Data> GetInvoice(String invoiceNumber);
        Dto GetInvoice(String invoiceNumber);
        Int64 GetInvoiceId(String invoiceNumber);
        List<Payment.Dto> ReadPaymentListForInvoice(String invoiceNumber);

    }

}
