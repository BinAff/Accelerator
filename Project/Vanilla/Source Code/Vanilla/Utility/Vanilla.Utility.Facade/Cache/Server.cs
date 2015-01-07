using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BinAff.Core;
using ConfigCrys = Crystal.Configuration.Component;

using ModDefFac = Vanilla.Utility.Facade.Module.Definition;
using NavRuleFac = Vanilla.Utility.Facade.Rule;
using StateFac = Vanilla.Configuration.Facade.State;
using CountryFac = Vanilla.Configuration.Facade.Country;
using IdProofTypeFac = Vanilla.Configuration.Facade.IdentityProofType;

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
                cache.CountryList = new CountryFac.Server(null).ReadAll<CountryFac.Dto>().ConvertAll((p) =>
                {
                    return new Table { Id = p.Id, Name = p.Name };
                });
            });

            Task.Factory.StartNew(() =>
            {
                cache.StateList = new StateFac.Server(null).ReadAll<StateFac.Dto>().ConvertAll((p) =>
                {
                    return new Table { Id = p.Id, Name = p.Name };
                });
                //cache.StateList = this.AssignFacadeServer(new StateFac.Server(null), (p) =>
                //{
                //    return new Table { Id = p.Id, Name = (p as StateFac.Dto).Name };
                //});
            });

            Task.Factory.StartNew(() =>
            {
                cache.IdentityProofTypeList = new IdProofTypeFac.Server(null).ReadAll<IdProofTypeFac.Dto>().ConvertAll((p) =>
                {
                    return new Table { Id = p.Id, Name = p.Name };
                });
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

        protected List<T> AssignFacadeServer<T>(BinAff.Facade.Library.Server facade, System.Converter<BinAff.Facade.Library.Dto, T> converter)
        {
            return facade.ReadAll<StateFac.Dto>().ConvertAll<T>((p) => { return converter(p); });
        }

    }

}