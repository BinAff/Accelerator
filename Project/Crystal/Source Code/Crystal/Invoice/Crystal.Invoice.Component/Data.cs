﻿using System;
using System.Collections.Generic;

namespace Crystal.Invoice.Component
{

    public class Data : Crystal.Customer.Component.Action.Data
    {
        
        public Int32 SerialNumber { get; set; }
        public String InvoiceNumber
        {
            get
            {
                return String.Empty;
                //return new Server(this).FormatInvoiceNumber();
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
