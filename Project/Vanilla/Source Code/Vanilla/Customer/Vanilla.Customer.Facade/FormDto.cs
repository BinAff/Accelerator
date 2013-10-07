using System.Collections.Generic;

namespace Vanilla.Customer.Facade
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public List<Initial.Dto> InitialList { get; set; }

        public List<State.Dto> StateList { get; set; }

        public List<IdentityProofType.Dto> IdentityProofTypeList { get; set; }

        public Dto Dto { get; set; }

        public Rule.Dto Rule { get; set; }

    }

}
