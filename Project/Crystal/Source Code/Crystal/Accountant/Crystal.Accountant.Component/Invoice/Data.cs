using System;
using System.Collections.Generic;

namespace Crystal.Accountant.Component.Invoice
{

    public class Data : Crystal.Customer.Component.Action.Data
    {
        
        public Int32 SerialNumber { get; internal set; }

        public String InvoiceNumber
        {
            get
            {
                return BinAff.Utility.Common.GenerateCode("INV", this.SerialNumber, "-", 5); //Should come from rule
            }
        }

        public Double Advance { get; set; }
        public Double Discount { get; set; }
        public Seller Seller { get; set; }
        public Buyer Buyer { get; set; }

        public List<BinAff.Core.Data> LineItemList { get; set; }              
        public List<BinAff.Core.Data> TaxList { get; set; }
        public List<BinAff.Core.Data> PaymentList { get; set; }

    }

}