using System;
using System.Collections.Generic;

namespace Vanilla.Report.Facade.Document
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Path { get; set; }
        public String ReportName { get; set; }
        public String DataSource { get; set; }
        public DateTime Date { get; set; }
        public Category.Dto Category { get; set; }

    }

}
