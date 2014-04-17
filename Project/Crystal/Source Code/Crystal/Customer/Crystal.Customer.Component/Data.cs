using System;
using System.Collections.Generic;

namespace Crystal.Customer.Component
{

    public class Data : BinAff.Core.Data
    {
        
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }        
        public String City { get; set; }
        public Int32 Pin { get; set; }
        public String Email { get; set; }        
        public String IdentityProof { get; set; }

        //public Configuration.Component.Initial.Data Initial { get; set; }
        public Configuration.Component.State.Data State { get; set; }
        public Configuration.Component.IdentityProofType.Data IdentityProofType { get; set; }

        public List<ContactNumber.Data> ContactNumberList { get; set; }

        public List<Characteristic.Data> CharacteristicList { get; set; }
        
    }

}
