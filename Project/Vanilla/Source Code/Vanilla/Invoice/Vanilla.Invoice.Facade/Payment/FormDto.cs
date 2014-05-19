using System.Collections.Generic;

namespace Vanilla.Invoice.Facade.Payment
{
    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {
        //public Dto dto { get; set; }
        public List<Type.Dto> typeList { get; set; }

        public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }
    }
}
