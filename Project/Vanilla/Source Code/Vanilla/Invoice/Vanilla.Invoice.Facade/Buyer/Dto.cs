using System;

namespace Vanilla.Accountant.Facade.Buyer
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String ContactNumber { get; set; }
    }
}
