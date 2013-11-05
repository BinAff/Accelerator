using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Customer.Facade.Lodge.Room
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public String Number { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Table Category { get; set; }
        public Table Type { get; set; }
        public Building.Dto Building { get; set; }
        public Table Floor { get; set; }
        public Boolean IsAirconditioned { get; set; }
        public Table Status { get; set; }
        public List<Image.Dto> ImageList { get; set; }        
    }
}
