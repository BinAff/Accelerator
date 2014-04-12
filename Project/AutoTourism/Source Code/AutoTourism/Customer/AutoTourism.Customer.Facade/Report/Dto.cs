using System;

namespace AutoTourism.Customer.Facade.Report
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime date { get; set; }
       
        public Vanilla.Report.Facade.Category.Dto category { get; set; }
    }
}
