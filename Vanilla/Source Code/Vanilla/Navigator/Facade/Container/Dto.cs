using System;
using System.Collections.Generic;
using Vanilla.Navigator.Facade.Module;

namespace Vanilla.Navigator.Facade.Container
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Group Group { get; set; }

        public List<Module.Dto> Modules { get; set; }

    }

}
