using System;

namespace Vanilla.Customer.Facade.Rule
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Boolean IsPinNumber { get; set; }
        public Boolean IsAlternateContactNumber { get; set; }
        public Boolean IsEmail { get; set; }
        public Boolean IsIdentityProof { get; set; }

    }

}
