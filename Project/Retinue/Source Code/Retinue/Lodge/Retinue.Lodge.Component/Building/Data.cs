using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Lodge.Component.Building
{

    public class Data : Crystal.Organization.Component.Unit.Data
    {   
       
        //-- This will be part of rule -- need to take care in Release2 --------
        //public Int32 DefaultFloor { get; set; }        
        //public Boolean IsDefault { get; set; }

        public List<BinAff.Core.Data> FloorList { get; set; }
      
    }

}
