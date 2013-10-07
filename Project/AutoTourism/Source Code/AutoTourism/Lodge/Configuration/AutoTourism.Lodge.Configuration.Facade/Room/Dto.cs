using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Lodge.Configuration.Facade.Room
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Number { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Room.Category.Dto Category { get; set; }
        public Room.Type.Dto Type { get; set; }
        public Building.Dto Building { get; set; }
        public Table Floor { get; set; }                
        public Boolean IsAirconditioned { get; set; }       
        public Int64 StatusId { get; set; }
        public List<Image.Dto> ImageList { get; set; }
        //public Boolean IsDormitory { get; set; }
        
    }  

}
