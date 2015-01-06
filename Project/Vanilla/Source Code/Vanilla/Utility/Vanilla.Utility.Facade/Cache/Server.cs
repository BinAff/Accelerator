using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BinAff.Core;

using ModDefFac = Vanilla.Utility.Facade.Module.Definition;
using NavRuleFac = Vanilla.Utility.Facade.Rule;
using ConfigCrys = Crystal.Configuration.Component;

namespace Vanilla.Utility.Facade.Cache
{
    
    public class Server
    {

        protected Dto cache;

        public Boolean Cache()
        {
            this.cache = this.CreateDataObject();
            BinAff.Facade.Cache.Server.Current.Cache["Main"] = this.cache;
            return this.Refresh();
        }

        protected virtual Dto CreateDataObject()
        {
            return new Dto();
        }

        protected virtual Boolean RefreshHook()
        {
            return true;
        }

        public Boolean Refresh()
        {
            Dto cache = BinAff.Facade.Cache.Server.Current.Cache["Main"] as Dto;
            Task.Factory.StartNew(() =>
            {
                cache.ComponentDefinitionList = new ModDefFac.Server(null).ReadAll();
            });

            Task.Factory.StartNew(() =>
            {
                cache.NavigatorRule = this.GetNavigatorRule();
            });

            Task.Factory.StartNew(() =>
            {
                cache.CountryList = this.ReadAllCountry();
            });

            Task.Factory.StartNew(() =>
            {
                cache.StateList = this.ReadAllState();
            });

            Task.Factory.StartNew(() =>
            {
                cache.IdentityProofTypeList = this.ReadAllIdentityProof();
            });

            Task.WaitAll();

            return this.RefreshHook();
        }

        public NavRuleFac.Dto GetNavigatorRule()
        {
            NavRuleFac.FormDto navRuleFormDto = new NavRuleFac.FormDto();
            new NavRuleFac.Server(navRuleFormDto).Read();
            return navRuleFormDto.Dto;
        }

        private List<Table> ReadAllCountry()
        {
            ICrud crud = new ConfigCrys.Country.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            List<Table> ret = new List<Table>();

            //Populate data in dto from business entity
            foreach (ConfigCrys.Country.Data data in dataList.Value)
            {
                ret.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        private List<Table> ReadAllState()
        {
            ICrud crud = new ConfigCrys.State.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            List<Table> ret = new List<Table>();

            //Populate data in dto from business entity
            foreach (ConfigCrys.State.Data data in dataList.Value)
            {
                ret.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

        private List<Table> ReadAllIdentityProof()
        {
            ICrud crud = new ConfigCrys.IdentityProofType.Server(null);
            ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();

            List<Table> ret = new List<Table>();

            //Populate data in dto from business entity
            foreach (ConfigCrys.IdentityProofType.Data data in dataList.Value)
            {
                ret.Add(new Table
                {
                    Id = data.Id,
                    Name = data.Name
                });
            }

            return ret;
        }

    }

}