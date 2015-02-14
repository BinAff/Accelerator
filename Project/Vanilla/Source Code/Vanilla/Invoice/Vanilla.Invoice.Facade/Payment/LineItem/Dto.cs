using System;

using BinAff.Core;

namespace Vanilla.Invoice.Facade.Payment.LineItem
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Table Type { get; set; }

        public String TypeName
        {
            get
            {
                return this.Type.Name;
            }
        }

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

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Type != null) dto.Type = this.Type.Clone();
            return dto;
        }

    }

}
