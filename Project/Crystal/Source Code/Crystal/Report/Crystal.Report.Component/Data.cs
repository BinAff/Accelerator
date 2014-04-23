﻿using System;

namespace Crystal.Report.Component
{

    public class Data : BinAff.Core.Data
    {

        public String Path { get; set; }
        public String DataSource { get; set; }
        public DateTime Date { get; set; }
        public Category.Data Category { get; set; }

    }

}
