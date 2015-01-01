using System;
using System.Collections.Generic;

using FrmFac = Vanilla.Form.Facade.Document;

namespace Vanilla.Invoice.Facade.Payment
{

    public class Dto : FrmFac.Dto
    {

        /// <summary>
        /// Date of payment
        /// </summary>
        public DateTime Date { get; set; }

        public List<LineItem> LineItemList { get; set; }

        public Double TotalAmount
        {
            get
            {
                Double totalAmount = 0;
                if (this.LineItemList != null && this.LineItemList.Count > 0)
                {
                    foreach (LineItem lineItem in this.LineItemList)
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
            if (this.LineItemList != null)
            {
                dto.LineItemList = new List<LineItem>();
                foreach (LineItem lineItem in this.LineItemList)
                {
                    dto.LineItemList.Add((lineItem != null) ? lineItem.Clone() as LineItem : null);
                }
            }
            return dto;
        }

    }
    
}
