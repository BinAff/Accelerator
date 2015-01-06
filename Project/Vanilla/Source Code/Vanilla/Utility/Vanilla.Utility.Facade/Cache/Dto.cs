using BinAff.Core;
using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Cache
{

    public class Dto
    {

        public List<Module.Definition.Dto> ComponentDefinitionList { get; set; }
        public List<Table> CountryList { get; set; }
        public List<Table> StateList { get; set; }
        public List<Table> IdentityProofTypeList { get; set; }

        public Rule.Dto NavigatorRule { get; set; }

    }

}
