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
            //new Vanilla.Utility.Facade.Cache.Server().Cache();
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            throw new NotImplementedException();
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new NotImplementedException();
        }
        
    }

}
