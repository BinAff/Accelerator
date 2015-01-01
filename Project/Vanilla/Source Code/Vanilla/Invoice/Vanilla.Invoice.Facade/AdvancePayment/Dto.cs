using System;

using BinAff.Core;

namespace Vanilla.Invoice.Facade.AdvancePayment
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
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

        public Table Type { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Type != null) dto.Type = this.Type.Clone();
            return dto;
        }

    }
    
}
