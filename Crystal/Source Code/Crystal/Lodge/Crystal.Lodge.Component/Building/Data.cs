using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Lodge.Component.Building
{

    public class Data : BinAff.Core.Data
    {

        public String Name { get; set; }     
       
        //-- This will be part of rule -- need to take care in Release2 --------
        //public Int32 DefaultFloor { get; set; }        
        //public Boolean IsDefault { get; set; }     

        public List<BinAff.Core.Data> FloorList { get; set; }
        public Type.Data Type { get; set; }
        public Status.Data Status { get; set; }
        public List<BinAff.Core.Data> ClosureReasonList { get; set; }

        public Organization.Component.Data Organization { get; set; }
      
    }

}
