using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinAff.Core;

namespace Vanilla.Invoice.Facade
{
    public interface IInvoice
    {
        List<Table> CalulateTaxList(Double total, List<Taxation.Dto> taxationList);
        ReturnObject<Crystal.Invoice.Component.Data> GetInvoice(String invoiceNumber);
    }
}
