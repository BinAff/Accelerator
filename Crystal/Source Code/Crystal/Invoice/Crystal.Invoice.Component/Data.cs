using System;
using System.Collections.Generic;

namespace Crystal.Invoice.Component
{

    public class Data : BinAff.Core.Data
    {
        public DateTime Date { get; set; }
        public String InvoiceNumber { get; set; }
        public Double Advance { get; set; }
        public Double Discount { get; set; }
        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }

        public List<BinAff.Core.Data> LineItem { get; set; }              
        public List<BinAff.Core.Data> Taxation { get; set; }
        public List<BinAff.Core.Data> Payment { get; set; }
    }

}
