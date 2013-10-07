using System;
using System.Collections.Generic;

namespace Crystal.Activity.Component
{

    public abstract class Data : Crystal.Customer.Component.Action.Data
    {
        public DateTime ActivityDate { get; set; }

    }

}
