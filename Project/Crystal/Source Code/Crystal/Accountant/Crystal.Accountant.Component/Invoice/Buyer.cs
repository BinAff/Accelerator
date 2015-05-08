using System;

namespace Crystal.Accountant.Component.Invoice
{

    public class Buyer : BinAff.Core.Data
    {

        public String Name { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String ContactNumber { get; set; }

    }

}
