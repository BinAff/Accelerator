using System;

namespace Vanilla.Invoice.WinForm
{
    public class Data
    {
        public String Start { get; set; }
        public String End { get; set; }
        public String Description { get; set; }
        public String UnitRate { get; set; }
        public String Count { get; set; }
        public String Total { get; set; }

        public String LuxuaryTax { get; set; }
        public String ServiceTax { get; set; }
        public String GrandTotal { get; set; }

        //L-lineItem, A-Advance, D-Discount, T-Total, Tx-Tax, Gt-GrandTotal
        public String colId { get; set; }
        public String name { get; set; }
        public String value { get; set; }
    }
}
