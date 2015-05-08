using System;

namespace Retinue.Configuration.Rule.Facade
{

    public class CustomerRuleDto
    {

        public Boolean IsAlternateContactNumber { get; set; }
        public Boolean IsEmail { get; set; }
        public Boolean IsIdentityProof { get; set; }
        public Boolean IsPinNumber { get; set; }

    }
    
}
