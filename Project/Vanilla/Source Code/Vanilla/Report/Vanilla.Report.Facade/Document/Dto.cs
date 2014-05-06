using System;
using System.Collections.Generic;

using DocFac = Vanilla.Utility.Facade.Document;

namespace Vanilla.Report.Facade.Document
{

    public class Dto : DocFac.Dto
    {

        public DateTime Date { get; set; }
        public Category.Dto Category { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public String ReportFilePath { get; set; }
        public String ReportName { get; set; }
        public String DataSource { get; set; }

    }

}
