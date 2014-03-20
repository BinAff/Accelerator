using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystal.Invoice.Component.InvoiceContainer
{
    public abstract class Validator : Crystal.Customer.Component.Characteristic.Validator
    {
        public Validator(Data data)
            : base(data)
        {

        }
    }
}
