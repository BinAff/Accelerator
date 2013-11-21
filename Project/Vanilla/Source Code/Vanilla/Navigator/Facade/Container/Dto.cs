using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Container
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Facade.Artifact.Category Category { get; set; }

        public List<Module.Dto> Modules { get; set; }

    }

}
