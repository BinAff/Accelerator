using System;

namespace Crystal.Invoice.Component.AdvancePayment
{

    public class Data : BinAff.Core.Data
    {

        public DateTime Date { get; set; }
        public String CardNumber { get; set; }
        public String Remark { get; set; }
        public Double Amount { get; set; }
        public Payment.Type.Data Type { get; set; }
        public Component.Data Invoice { get; set; }

    }

}
