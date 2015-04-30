using System;

namespace Vanilla.Invoice.WinForm
{
    public class Data
    {
        public String Start { get; set; }
        public String End { get; set; }
        public String Description { get; set; }
        public Double UnitRate { get; set; }
        public Double Count { get; set; }
        
        public Double Total
        {
            get
            {
                return this.UnitRate * this.Count;
            }
        }
        public Double LuxuaryTax { get; set; }
        public Double ServiceTax { get; set; }
        public Double GrandTotal
        {
            get
            {
                return this.Total + this.ServiceTax + this.LuxuaryTax;
            }
        }

        //L-lineItem, A-Advance, D-Discount, T-Total, Tx-Tax, Gt-GrandTotal
        public String colId { get; set; }
        public String name { get; set; }
        public String value { get; set; }
    }
}
