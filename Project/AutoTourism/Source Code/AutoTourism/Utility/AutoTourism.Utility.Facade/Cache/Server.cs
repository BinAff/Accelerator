using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;

namespace AutoTourism.Utility.Facade.Cache
{

    public class Server : Vanilla.Utility.Facade.Cache.Server
    {

        protected override Vanilla.Utility.Facade.Cache.Dto CreateDataObject()
        {
            return new Dto();
        }

        protected override Boolean RefreshHook()
        {
            Dto cache = base.cache as Dto;
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

            Task.Factory.StartNew(() =>
            {
                cache.CustomerRule = this.ReadCustomerRule();
            });

            Task.WaitAll();
            return true;
        }

        private AutoTourism.Configuration.Rule.Facade.CustomerRuleDto ReadCustomerRule()
        {
            return new AutoTourism.Configuration.Rule.Facade.RuleServer().ReadCustomerRule().Value;
        }

    }

}
