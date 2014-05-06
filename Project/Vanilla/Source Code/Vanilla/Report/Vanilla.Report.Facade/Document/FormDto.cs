using System;
using System.Collections.Generic;

using DocFac = Vanilla.Utility.Facade.Document;

namespace Vanilla.Report.Facade.Document
{
    public class FormDto : DocFac.FormDto
    {

        public List<BinAff.Facade.Library.Dto> ReportData { get; set; }

        public String ModuleName { get; set; }

        public Category.Dto Category { get; set; }

    }
}
