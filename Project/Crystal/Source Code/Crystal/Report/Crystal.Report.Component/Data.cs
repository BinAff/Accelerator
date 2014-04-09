using System;

namespace Crystal.Report.Component
{
    public class Data : BinAff.Core.Data
    {
        public DateTime Date { get; set; }
        //public DateTime FromDate { get; set; }
        //public DateTime ToDate { get; set; }

        public Category.Data category { get; set; }
    }
}
