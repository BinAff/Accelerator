using System.Collections.Generic;

namespace AutoTourism.Lodge.Configuration.Facade.Room
{
    public class FormDto
    {
        //public Dto Room { get; set; }
        public List<Dto> RoomList { get; set; }
        public List<Building.Dto> BuildingList { get; set; }
        public List<RoomCategory.Dto> CategoryList { get; set; }
        public List<RoomType.Dto> TypeList { get; set; }
    }
}
