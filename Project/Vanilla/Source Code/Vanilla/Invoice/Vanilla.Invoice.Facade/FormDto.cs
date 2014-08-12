using BinAff.Core;
using System.Collections.Generic;

namespace Vanilla.Invoice.Facade
{
    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {
        //public Dto dto { get; set; }
        public List<Table> paymentTypeList { get; set; }

        public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }
    }
}


