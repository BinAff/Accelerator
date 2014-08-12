using System;
using System.Collections.Generic;

namespace Crystal.Invoice.Component.Payment
{

    public class Data : BinAff.Core.Data
    {

        public DateTime Date { get; set; }

        public List<BinAff.Core.Data> LineItemList { get; set; }

        public Component.Data Invoice { get; set; }

    }

}
