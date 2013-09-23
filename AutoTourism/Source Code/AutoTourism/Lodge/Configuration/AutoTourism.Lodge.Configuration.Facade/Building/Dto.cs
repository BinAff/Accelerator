using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Lodge.Configuration.Facade.Building
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public List<Int32> FloorList { get; set; }        

        public BuildingType.Dto Type { get; set; }
        public Int32 DefaultFloor { get; set; }
        public Boolean IsDefault { get; set; }
        public Table Status { get; set; } 

       
    }

}
