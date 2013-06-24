using System;
using System.Collections.Generic;

namespace Vanilla.Customer.Facade
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Initial.Dto Initial { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public State.Dto State { get; set; }
        public String City { get; set; }
        public Int32 Pin { get; set; }
        public String Email { get; set; }
        public IdentityProofType.Dto IdentityProofType { get; set; }
        public String IdentityProofName { get; set; }

        public List<ContactNumber.Dto> ContactNumberList { get; set; }

    }

}
