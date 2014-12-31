using System;
using System.Collections.Generic;

namespace Vanilla.Invoice.Facade.Receipt
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public double Advance { get; set; }
        public double Discount { get; set; }
        public Buyer.Dto Buyer { get; set; }
        public Seller.Dto Seller { get; set; }
        
        public List<LineItem.Dto> ProductList { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            dto.Buyer = this.Buyer.Clone() as Buyer.Dto;
            dto.Seller = this.Seller.Clone() as Seller.Dto;
            if (this.ProductList != null)
            {
                dto.ProductList = new List<LineItem.Dto>();
                foreach (LineItem.Dto product in this.ProductList)
                {
                    dto.ProductList.Add(product.Clone() as LineItem.Dto);
                }
            }
            return dto;
        }

    }

}
