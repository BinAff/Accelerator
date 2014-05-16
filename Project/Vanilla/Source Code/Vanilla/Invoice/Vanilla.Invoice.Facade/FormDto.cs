using System.Collections.Generic;

namespace Vanilla.Invoice.Facade
{
    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {
        //public Dto dto { get; set; }
        public List<Payment.Type.Dto> paymentTypeList { get; set; }

        public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }
    }
}


