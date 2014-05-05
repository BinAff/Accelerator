using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Register
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Artifact.Category Category { get; set; }

        public List<Module.Dto> Modules { get; set; }

    }

}
