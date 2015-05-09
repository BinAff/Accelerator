using System;

namespace Crystal.Accountant.Component.Tax.Slab
{

    public class Data : BinAff.Core.Data
    {

        public Double Limit { get; set; }
        public Double Amount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }

}
