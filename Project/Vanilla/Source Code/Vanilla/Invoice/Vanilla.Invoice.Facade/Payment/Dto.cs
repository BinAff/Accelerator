using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Invoice.Facade.Payment
{
    public class Dto : Vanilla.Form.Facade.Document.Dto
    {
        public DateTime date { get; set; }
        public String cardNumber { get; set; }
        public String remark { get; set; }
        public Double amount {get;set;}
        public String paymentType { get; set; }

        public Type.Dto Type { get; set; }
    }
    
}
