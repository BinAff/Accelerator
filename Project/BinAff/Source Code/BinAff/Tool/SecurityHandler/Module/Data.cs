using System;

namespace BinAff.Tool.SecurityHandler.Module
{

    public class Data : BinAff.Core.Data
    {

        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean IsForm { get; set; }
        public Boolean IsReport { get; set; }
        public Boolean IsCatalogue { get; set; }

    }

}
