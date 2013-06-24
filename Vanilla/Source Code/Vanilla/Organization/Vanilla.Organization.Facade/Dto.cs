using System;
using System.Collections.Generic;

namespace Vanilla.Organization.Facade
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public String Name { get; set; }
        public Byte[] Logo { get; set; }
        public String LicenceNumber { get; set; }
        public String Tan { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public Int64 Pin { get; set; }
        public String ContactName { get; set; }

        public State.Dto State { get; set; }

        public List<ContactNumber.Dto> ContactNumberList { get; set; }
        public List<Email.Dto> EmailList { get; set; }
        public List<Fax.Dto> FaxList { get; set; }
    }
}
