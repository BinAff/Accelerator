using System.Collections.Generic;

namespace Retinue.Utility.Facade.Cache
{

    public class Dto : Vanilla.Utility.Facade.Cache.Dto
    {

        public List<Retinue.Lodge.Configuration.Facade.Room.Category.Dto> RoomCategoryList { get; set; }
        public List<Retinue.Lodge.Configuration.Facade.Room.Type.Dto> RoomTypeList { get; set; }
        public List<Retinue.Lodge.Configuration.Facade.Room.Dto> RoomList { get; set; }

        public Retinue.Configuration.Rule.Facade.CustomerRuleDto CustomerRule { get; set; }

    }

}
