using System;
using System.Collections.Generic;
using BinAff.Core;

namespace AutoTourism.Facade.Configuration.Room
{
    public class Dto
    {
        public Int64 Id { get; set; }
        public String Number { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Building.Dto Building { get; set; }
        public Int32 Floor { get; set; }
        public RoomCategory.Dto Category { get; set; }
        public RoomType.Dto Type { get; set; }
        public Boolean IsAirconditioned { get; set; }
        public Boolean IsDormitory { get; set; }
        public Int64 StatusId { get; set; }

        public List<ImageDto> ImageList { get; set; }
        
    }  

}
