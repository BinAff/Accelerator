using System;

namespace Crystal.Customer.Rule
{
    public class Data : BinAff.Core.Data
    {
        public Boolean IsPinNumber { get; set; }
        public Boolean IsAlternateContactNumber { get; set; }
        public Boolean IsEmail { get; set; }
        public Boolean IsIdentityProof { get; set; }
    }
}
