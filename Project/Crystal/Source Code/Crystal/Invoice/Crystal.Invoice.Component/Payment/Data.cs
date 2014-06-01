using System;

namespace Crystal.Invoice.Component.Payment
{

    public class Data : BinAff.Core.Data
    {
        public DateTime Date { get; set; }
        public String CardNumber { get; set; }
        public String Remark { get; set; }
        public Double Amount { get; set; }

        public Type.Data Type { get; set; }

        public Component.Data Invoice { get; set; }

    }

}
