using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Lodge.Facade
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public Byte[] logo { get; set; }
        public String LicenceNumber { get; set; }
        public String Tan { get; set; }
        public String Address { get; set; }
        public String City { get; set; }        
        public Table State { get; set; }
        public Int64 Pin { get; set; }
        public String ContactName { get; set; }

        public List<Table> ContactNumberList { get; set; }
        public List<Table> FaxList { get; set; }
        public List<Table> EmailList { get; set; }

    }  

}
