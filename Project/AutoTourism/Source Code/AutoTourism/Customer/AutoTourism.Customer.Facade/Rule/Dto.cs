namespace AutoTourism.Customer.Facade.Rule
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public bool IsAlternateContactNumber { get; set; }
        public bool IsEmail { get; set; }
        public bool IsIdentityProof { get; set; }
        public bool IsPinNumber { get; set; }

    }

}
