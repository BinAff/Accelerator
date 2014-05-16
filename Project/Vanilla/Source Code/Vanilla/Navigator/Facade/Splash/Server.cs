using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BinAff.Facade.Cache;

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
            BinAff.Facade.Cache.Server.Current.Cache["ComponentDefinition"] = new Vanilla.Utility.Facade.Module.Definition.Server(null).ReadAll();
        }
        
    }

}
