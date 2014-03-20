﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Invoice.Facade.Taxation
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public String Name { get; set; }
        public Double Amount { get; set; }
        public Boolean isPercentage { get; set; }
    }
}
