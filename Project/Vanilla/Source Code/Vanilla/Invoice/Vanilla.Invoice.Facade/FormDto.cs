using BinAff.Core;
using System.Collections.Generic;

namespace Vanilla.Accountant.Facade
{

    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {

        public List<Table> paymentTypeList { get; set; }

        public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }

    }

}


