using System;
using System.Collections.Generic;

using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;

namespace AutoTourism.Utility.Facade.Cache
{

    public class Server
    {

        public Boolean Cache()
        {
            BinAff.Facade.Cache.Server.Current.Cache["AutoTourism"] = new Dto();
            return Refresh();
        }

        public Boolean Refresh()
        {
            Dto cache = BinAff.Facade.Cache.Server.Current.Cache["AutoTourism"] as Dto;
            cache.RoomList = new RoomFac.Server(null).ReadAll<RoomFac.Dto>();
            cache.RoomCategoryList = new RoomFac.Category.Server(null).ReadAll<RoomFac.Category.Dto>();
            cache.RoomTypeList = new RoomFac.Type.Server(null).ReadAll<RoomFac.Type.Dto>();
            return true;
        }

    }

}
