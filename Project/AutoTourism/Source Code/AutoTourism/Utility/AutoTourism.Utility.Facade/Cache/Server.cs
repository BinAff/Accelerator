using System;
using System.Collections.Generic;

using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;

namespace AutoTourism.Utility.Facade.Cache
{

    public class Server
    {

        public Boolean Cache()
        {
            BinAff.Facade.Cache.Server.Current.Cache["Autotourism"] = new Dto
            {
                RoomList = new RoomFac.Server(null).ReadAll<RoomFac.Dto>(),
            };
            return true;
        }

        public Boolean Refresh()
        {
            Dto cache = BinAff.Facade.Cache.Server.Current.Cache["Autotourism"] as Dto;
            cache.RoomList = new RoomFac.Server(null).ReadAll<RoomFac.Dto>();
            return true;
        }

    }

}
