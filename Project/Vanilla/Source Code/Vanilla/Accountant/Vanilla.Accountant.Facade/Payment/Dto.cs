using System;
using System.Collections.Generic;

using BinAff.Core;

using FrmFac = Vanilla.Form.Facade.Document;

namespace Vanilla.Accountant.Facade.Payment
{

    public class Dto : FrmFac.Dto
    {

        public String ReceiptNumber { get; set; }

        /// <summary>
        /// Date of payment
        /// </summary>
        public DateTime Date { get; set; }

        public Table Status { get; set; }

        public List<LineItem.Dto> LineItemList { get; set; }

        public Invoice.Dto Invoice { get; set; }

        public Double TotalAmount
        {
            get
            {
                Double totalAmount = 0;
                if (this.LineItemList != null && this.LineItemList.Count > 0)
                {
                    foreach (LineItem.Dto lineItem in this.LineItemList)
                    {
                        totalAmount += lineItem.Amount;
                    }
                }
                return totalAmount;
            }
        }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Status != null) dto.Status = this.Status.Clone();
            if (this.LineItemList != null)
            {
                dto.LineItemList = new List<LineItem.Dto>();
                foreach (LineItem.Dto lineItem in this.LineItemList)
                {
                    dto.LineItemList.Add((lineItem != null) ? lineItem.Clone() as LineItem.Dto : null);
                }
            }
            if (this.Invoice != null) this.Invoice.Clone();
            return dto;
        }

    }
    
}
