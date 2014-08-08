using System;

using BinAff.Core;

using FrmFac = Vanilla.Form.Facade.Document;

namespace Vanilla.Invoice.Facade.Payment
{

    public class Dto : FrmFac.Dto
    {

        /// <summary>
        /// Date of payment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Card number / Check number / DD Number
        /// </summary>
        public String ReferenceNumber { get; set; }

        /// <summary>
        /// Advance amount
        /// </summary>
        public Double Amount { get; set; }

        /// <summary>
        /// Additional remarks
        /// </summary>
        public String Remark { get; set; }

        public String PaymentType { get; set; }

        public Table Type { get; set; }

    }
    
}
