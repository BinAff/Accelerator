using System;

using BinAff.Core;

using RuleCrys = Crystal.Navigator.Rule;

using ModDefFac = Vanilla.Utility.Facade.Module.Definition;
using NavRuleFac = Vanilla.Utility.Facade.Rule;

namespace Vanilla.Navigator.Facade.Splash
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            this.Cache();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }

        public void Cache()
        {
            //BinAff.Facade.Cache.Server.Current.Cache["ComponentDefinition"] = new ModDefFac.Server(null).ReadAll();
            
            BinAff.Facade.Cache.Server.Current.Cache["Main"] = new Vanilla.Utility.Facade.Cache.Dto
            {
                ComponentDefinitionList = new ModDefFac.Server(null).ReadAll(),
                NavigatorRule = this.GetNavigatorRule(),
            };
        }

        public Vanilla.Utility.Facade.Rule.Dto GetNavigatorRule()
        {
            NavRuleFac.FormDto navRuleFormDto = new NavRuleFac.FormDto();
            new NavRuleFac.Server(navRuleFormDto).Read();
            return navRuleFormDto.Dto;
        }
        
    }

}
