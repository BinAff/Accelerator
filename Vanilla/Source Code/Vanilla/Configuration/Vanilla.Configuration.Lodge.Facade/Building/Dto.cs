using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Facade.Configuration.Building
{

    public class Dto
    {

        public Int64 Id { get; set; }
        public String Name { get; set; }
        public List<Int32> Floor { get; set; }
        public BuildingType.Dto Type { get; set; }
        public Int32 DefaultFloor { get; set; }
        public Boolean IsDefault { get; set; }
        public Table Status { get; set; } 
       
    }

}
