using System;

namespace Vanilla.Utility.Facade.Report
{

    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime Date { get; set; }
        public Category.Dto category { get; set; }
    }
}
