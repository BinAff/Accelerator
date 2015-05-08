using System;

namespace Vanilla.Accountant.Facade.Taxation
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public Double Amount { get; set; }
        public Boolean IsPercentage { get; set; }

    }

}
