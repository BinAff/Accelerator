using System;
using System.Collections.Generic;

namespace Vanilla.Accountant.Facade.Receipt
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public DateTime Date { get; set; }
        public String InvoiceNumber { get; set; }
        public Double Advance { get; set; }
        public Double Discount { get; set; }
        public Invoice.Buyer.Dto Buyer { get; set; }
        public Invoice.Seller.Dto Seller { get; set; }
        
        public List<Invoice.LineItem.Dto> ProductList { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Buyer != null) dto.Buyer = this.Buyer.Clone() as Invoice.Buyer.Dto;
            if (this.Seller != null) dto.Seller = this.Seller.Clone() as Invoice.Seller.Dto;
            if (this.ProductList != null)
            {
                dto.ProductList = new List<Invoice.LineItem.Dto>();
                foreach (Invoice.LineItem.Dto product in this.ProductList)
                {
                    dto.ProductList.Add((product != null) ? product.Clone() as Invoice.LineItem.Dto : null);
                }
            }
            return dto;
        }

    }

}