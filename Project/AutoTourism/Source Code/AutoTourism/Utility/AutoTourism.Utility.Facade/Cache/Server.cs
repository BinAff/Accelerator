using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Task.Factory.StartNew(() =>
            {
                cache.RoomList = new RoomFac.Server(null).ReadAll<RoomFac.Dto>();
            });

            Task.Factory.StartNew(() =>
            {
                cache.RoomCategoryList = new RoomFac.Category.Server(null).ReadAll<RoomFac.Category.Dto>();
                cache.RoomCategoryList.Insert(0, new RoomFac.Category.Dto
                {
                    Name = "All"
                });
            });

            Task.Factory.StartNew(() =>
            {
                cache.RoomTypeList = new RoomFac.Type.Server(null).ReadAll<RoomFac.Type.Dto>();
                cache.RoomTypeList.Insert(0, new RoomFac.Type.Dto
                {
                    Name = "All"
                });
            });

            Task.WaitAll();
            return true;
        }

    }

}
