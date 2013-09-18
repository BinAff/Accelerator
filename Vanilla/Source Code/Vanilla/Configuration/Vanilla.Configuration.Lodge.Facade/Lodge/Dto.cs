using System;
using System.Collections.Generic;
using BinAff.Core;
using State = Vanilla.Configuration.Facade.State;

namespace Vanilla.Configuration.Lodge.Facade.Lodge
{
    public class Dto
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public Byte[] logo { get; set; }
        public String LicenceNumber { get; set; }
        public String Tan { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public State.Dto State { get; set; }
        public Int64 Pin { get; set; }
        public String ContactName { get; set; }

        public List<ContactNumberDto> ContactNumberList { get; set; }
        public List<FaxDto> FaxList { get; set; }
        public List<EmailDto> EmailList { get; set; }
    }  

}
