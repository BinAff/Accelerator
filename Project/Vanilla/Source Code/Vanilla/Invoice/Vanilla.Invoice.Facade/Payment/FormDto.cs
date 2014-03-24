using System.Collections.Generic;

namespace Vanilla.Invoice.Facade.Payment
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {
        public Dto dto { get; set; }
        public List<Type.Dto> typeList { get; set; }

        public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }
    }
}
