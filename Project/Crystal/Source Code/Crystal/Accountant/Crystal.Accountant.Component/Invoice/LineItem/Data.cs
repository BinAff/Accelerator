using System;
using System.Collections.Generic;

namespace Crystal.Accountant.Component.Invoice.LineItem
{

    public class Data : BinAff.Core.Data
    {
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Description { get; set; }
        public Double UnitRate { get; set; }
        public Int32 Count { get; set; }
        public Double ExtraRate { get; set; }
        public Int32 ExtraCount { get; set; }

        public List<BinAff.Core.Data> TaxList { get; set; }

        public override BinAff.Core.Data Clone()
        {
            Data data = base.Clone() as Data;
            if (this.TaxList != null)
            {
                data.TaxList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data tax in this.TaxList)
                {
                    data.TaxList.Add((tax != null) ? tax.Clone() : null);
                }
            }
            return data;
        }

    }

}