using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Customer.Facade
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set;}
        public List<Dto> DtoList { get; set; }

        public List<Table> InitialList { get; set; }
        public List<Table> StateList { get; set; }
        public List<Table> IdentityProofTypeList { get; set; }

    }

}
