﻿using System;
using System.Collections.Generic;

namespace Crystal.Invoice.Component.Payment
{

    public class Data : BinAff.Core.Data
    {

        internal Int32 SerialNumber { get; set; }

        public String ReceiptNumber
        {
            get
            {
                return new Server(this).FormatRecieptNumber();
            }
        }

        public DateTime Date { get; set; }

        public List<BinAff.Core.Data> LineItemList { get; set; }

        public Component.Data Invoice { get; set; }

    }

}