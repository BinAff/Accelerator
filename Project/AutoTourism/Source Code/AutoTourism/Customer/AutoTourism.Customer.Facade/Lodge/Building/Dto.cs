
using System;
using System.Collections.Generic;

using BinAff.Core;
namespace AutoTourism.Customer.Facade.Lodge.Building
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public String Name { get; set; }
        public List<Table> FloorList { get; set; }
        public Table Type { get; set; }        
        public Table Status { get; set; } 
    }
}
