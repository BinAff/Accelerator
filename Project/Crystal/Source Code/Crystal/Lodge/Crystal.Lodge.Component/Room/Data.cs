using System;
using System.Collections.Generic;

namespace Crystal.Lodge.Component.Room
{

    public class Data : Product.Component.Data
    {      
        public Building.Data Building { get; set; }
        public Building.Floor.Data Floor { get; set; }
        public Category.Data Category { get; set; }
        public Type.Data Type { get; set; }
        public Boolean IsAirConditioned { get; set; }
        public Status.Data Status { get; set; }

        public List<BinAff.Core.Data> ImageList { get; set; }
        public List<BinAff.Core.Data> ClosureReasonList { get; set; }
        
    }

}
