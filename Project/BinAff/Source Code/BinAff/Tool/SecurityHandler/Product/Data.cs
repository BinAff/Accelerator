using System;
using System.Collections.Generic;

namespace BinAff.Tool.SecurityHandler.Product
{

    public class Data : BinAff.Core.Data
    {

        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public List<BinAff.Core.Data> ModuleList { get; set; }

    }

}
