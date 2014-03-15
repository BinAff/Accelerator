using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Invoice.Facade
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {
        public Dto invoice { get; set; }
    }
}
