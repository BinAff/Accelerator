using System;

namespace Crystal.Invoice.Component.Taxation
{

    public class Data : BinAff.Core.Data
    {

        public String Name { get; set; }
        public Double Amount { get; set; }
        public Boolean isPercentage { get; set; }

    }

}
