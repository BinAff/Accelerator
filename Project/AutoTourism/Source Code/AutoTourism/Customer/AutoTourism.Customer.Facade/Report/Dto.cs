using System;

namespace AutoTourism.Customer.Facade.Report
{
    public class Dto : Vanilla.Utility.Facade.Report.Dto
    {
        //public DateTime date { get; set; }       
        //public Vanilla.Report.Facade.Category.Dto category { get; set; }

        public String Initial { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public Int32 Pin { get; set; }
        public String Email { get; set; }
        public String IdentityProofType { get; set; }
        public String IdentityProofName { get; set; }
        public String ContactNumber { get; set; }
    }
}
