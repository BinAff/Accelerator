using System;

namespace Crystal.Customer.Component.Report
{
    public class Data : Crystal.Report.Component.Data
    {
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
