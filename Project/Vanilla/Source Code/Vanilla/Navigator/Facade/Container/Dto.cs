using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Container
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Vanilla.Utility.Facade.Artifact.Category Category { get; set; }

        public List<Vanilla.Utility.Facade.Module.Dto> Modules { get; set; }

    }

}
