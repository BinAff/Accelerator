using System;

namespace Vanilla.Invoice.Facade.Seller
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String Liscence { get; set; }
        public String Email { get; set; }
        public String ContactNumber { get; set; }
    }
}
