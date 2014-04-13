
using System;
namespace Vanilla.Utility.Facade.Report
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime date { get; set; }
        public Category.Dto category { get; set; }
    }
}
