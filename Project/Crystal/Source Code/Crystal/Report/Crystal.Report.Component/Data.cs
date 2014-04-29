using System;

namespace Crystal.Report.Component
{

    public class Data : BinAff.Core.Data
    {

        public String Path { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String DataSource { get; set; }
        public DateTime Date { get; set; }
        public Category.Data Category { get; set; }

    }

}
