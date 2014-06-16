using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Invoice.Facade.AdvancePayment
{

    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {

        public List<Table> TypeList { get; set; }

        public List<Dto> PaymentList { get; set; }

    }

}
