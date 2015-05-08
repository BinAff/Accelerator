using System;
using System.Collections.Generic;

namespace Crystal.Organization.Component.Unit
{

    public class Data : BinAff.Core.Data
    {

        public String Name { get; set; }

        public Status.Data Status { get; set; }

        public Type.Data Type { get; set; }

        public List<BinAff.Core.Data> ClosureReasonList { get; set; }

        public Crystal.Organization.Component.Data Organization { get; set; }

    }

}
