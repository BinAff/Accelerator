using System;
using System.Collections.Generic;

namespace Vanilla.Invoice.Facade.Payment
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {
        //public Dto dto { get; set; }
        public List<Type.Dto> typeList { get; set; }
        //public List<LineItem.Dto> ProductList { get; set; }
        //public Double Advance { get; set; }
        //public List<Taxation.Dto> TaxationList { get; set; }

        //public String InvoiceNumber { get; set; }
        //public List<Dto> PaymentList { get; set; }
        //public Double Discount { get; set; }
        //public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }    
    }
}
