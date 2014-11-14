using System.Collections.Generic;

namespace AutoTourism.Utility.Facade.Cache
{

    public class Dto : Vanilla.Utility.Facade.Cache.Dto
    {

        public List<Lodge.Configuration.Facade.Room.Category.Dto> RoomCategoryList { get; set; }
        public List<Lodge.Configuration.Facade.Room.Type.Dto> RoomTypeList { get; set; }
        public List<Lodge.Configuration.Facade.Room.Dto> RoomList { get; set; }

    }

}
