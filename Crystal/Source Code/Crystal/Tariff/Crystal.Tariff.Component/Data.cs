using System;
using System.Collections.Generic;

namespace Crystal.Tariff.Component
{

    public class Data : BinAff.Core.Data
    {

        public Product.Component.Data Product { get; set; }
        public Double Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

}
