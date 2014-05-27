using System;
using System.Collections.Generic;

namespace Crystal.Organization.Component
{
    public class Data : BinAff.Core.Data
    {
        public String Name { get; set; }
        public Byte[] Logo { get; set; }
        public String LicenceNumber { get; set; }
        public String Tan { get; set; }
        public String LuxuryTaxNumber { get; set; }
        public String ServiceTaxNumber { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public Int64 Pin { get; set; }
        public String ContactName { get; set; }

        public Crystal.Configuration.Component.State.Data State { get; set; }

        public List<BinAff.Core.Data> ContactNumberList { get; set; }    
        public List<BinAff.Core.Data> EmailList { get; set; }
        public List<BinAff.Core.Data> FaxList { get; set; }    
    }
}
