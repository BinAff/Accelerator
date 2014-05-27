using System;

namespace AutoTourism.Lodge.Facade.Taxation
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public Double Amount { get; set; }
        public Boolean IsPercentage { get; set; }

    }

}
