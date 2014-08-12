using System;

using BinAff.Core;

namespace Vanilla.Invoice.Facade.Payment
{

    public class LineItem : BinAff.Facade.Library.Dto
    {

        /// <summary>
        /// Card number / Check number / DD Number
        /// </summary>
        public String Reference { get; set; }

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
