using System.Collections.Generic;

using BinAff.Core;

using ModFac = Vanilla.Utility.Facade.Module;

using RuleFac = Retinue.Configuration.Rule.Facade;

namespace Retinue.Customer.Facade
{

    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {

        public RuleFac.CustomerRuleDto RuleDto { get; set; }
        public List<Dto> DtoList { get; set; }

        //public List<Table> InitialList { get; set; }
        public List<Table> CountryList { get; set; }
        public List<Table> StateList { get; set; }
        public List<Table> IdentityProofTypeList { get; set; }

        public ModFac.FormDto ModuleFormDto { get; set; }

    }

}
