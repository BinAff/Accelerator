using System.Collections.Generic;

using UtilFac = Vanilla.Utility.Facade;

namespace Vanilla.Navigator.Facade.Register
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public UtilFac.Artifact.Category Category { get; set; }

        public List<UtilFac.Module.Dto> Modules { get; set; }

    }

}
