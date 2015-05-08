using System;
using System.Collections.Generic;
using State = Crystal.Configuration.Component.State;

namespace Retinue.Lodge.Component.Lodge
{

    public class Data : BinAff.Core.Data
    {

        public String Name { get; set; }
        public Byte[] Logo { get; set; }
        public String LicenceNumber { get; set; }
        public String Tan { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public Int64 Pin { get; set; }
        public String ContactName { get; set; }

        public State.Data State { get; set; }
        public List<ContactNumberData> ContactNumberList { get; set; }
        public List<EmailData> EmailList { get; set; }        
        public List<FaxData> FaxList { get; set; }

    }

}
