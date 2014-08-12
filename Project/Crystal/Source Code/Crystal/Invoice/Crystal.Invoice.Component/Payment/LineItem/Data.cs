using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystal.Invoice.Component.Payment.LineItem
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Reference for payment as for example chek number or last four digit of credit card number
        /// </summary>
        public String Reference { get; set; }

        /// <summary>
        /// Amount paid
        /// </summary>
        public Double Amount { get; set; }

        /// <summary>
        /// Type of payment as Credit card, Debit Crad, etc.
        /// </summary>
        public Type.Data Type { get; set; }

        /// <summary>
        /// Remark for the payment
        /// </summary>
        public String Remark { get; set; }

    }

}
