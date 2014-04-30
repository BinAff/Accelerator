using System;
using System.Collections.Generic;

namespace Vanilla.Report.Facade.Document
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }

        public List<BinAff.Facade.Library.Dto> ReportData { get; set; }

        public String DocumentName { get; set; }

        public String ModuleName { get; set; }

        public Category.Dto Category { get; set; }

    }
}
