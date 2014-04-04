using System;

namespace Vanilla.Invoice.Facade.Report
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime date { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }

        public Vanilla.Report.Facade.Category.Dto category { get; set; }
    }
}
