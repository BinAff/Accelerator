using System.Collections.Generic;

namespace AutoTourism.Lodge.Configuration.Facade.Room
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Room { get; set; }
        public List<Dto> RoomList { get; set; }
        public List<Building.Dto> BuildingList { get; set; }
        public List<AutoTourism.Lodge.Configuration.Facade.Room.Category.Dto> CategoryList { get; set; }
        public List<Room.Type.Dto> TypeList { get; set; }

    }

}
