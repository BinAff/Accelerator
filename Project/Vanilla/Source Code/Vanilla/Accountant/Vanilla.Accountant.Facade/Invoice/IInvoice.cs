using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Accountant.Facade.Invoice
{

    public interface IInvoice
    {

        List<Table> CalulateTaxList(Double total, List<Taxation.Dto> taxationList);
        //ReturnObject<Crystal.Accountant.Component.Invoice.Data> GetInvoice(String invoiceNumber);
        //Dto GetInvoice(String invoiceNumber);
        List<Payment.Dto> ReadPaymentListForInvoice(String invoiceNumber);

    }

}