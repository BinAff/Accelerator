using System;
using System.Collections.Generic;

namespace Crystal.Invoice.Component.LineItem
{

    public class Data : BinAff.Core.Data
    {
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Description { get; set; }
        public Double UnitRate { get; set; }
        public Int32 Count { get; set; }
        public Double Total { get; set; }

        public List<BinAff.Core.Data> TaxList { get; set; }

    }

}
