using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Customer.Facade
{

    public class Dto
    {

        public Int64 Id { get; set; }

        public Table Initial { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public Table State { get; set; }
        public String City { get; set; }
        public Int32 Pin { get; set; }
        public String Email { get; set; }
        public Table IdentityProofType { get; set; }
        public String IdentityProofName { get; set; }
           
        public List<Table> ContactNumberList { get; set; }

        public List<Lodge.Reservation.Dto> reservationList { get; set; }
        
    }

}
