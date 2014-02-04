using System;
using System.Collections.Generic;

namespace Crystal.Customer.Component.Action
{

    public class Data : BinAff.Core.Data
    {

        public DateTime Date { get; set; }

        public List<BinAff.Core.Data> ProductList { get; set; }

        public Status.Data Status { get; set; }

    }

}
