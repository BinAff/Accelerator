using System;
using System.Collections.Generic;

namespace BinAff.Tool.SecurityHandler.Module
{

    public class Data : BinAff.Core.Data
    {

        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean IsMandatory { get; set; }
        public List<Core.Data> ComponentList { get; set; }

    }

}
