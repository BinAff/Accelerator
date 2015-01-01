using System.Collections.Generic;
using System;

namespace Vanilla.Invoice.Facade
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        public String InvoiceNumber { get; set; }
        public Double Advance { get; set; }
        public Double Discount { get; set; }
        public Buyer.Dto Buyer { get; set; }
        public Seller.Dto Seller { get; set; }
        public DateTime Date { get; set; }
        public List<LineItem.Dto> ProductList { get; set; }
        //public List<Taxation.Dto> taxationList { get; set; }
        //public List<Payment.Dto> paymentList { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Buyer != null) dto.Buyer = this.Buyer.Clone() as Buyer.Dto;
            if (this.Seller != null) dto.Seller = this.Seller.Clone() as Seller.Dto;
            if (this.ProductList != null)
            {
                dto.ProductList = new List<LineItem.Dto>();
                foreach (LineItem.Dto product in this.ProductList)
                {
                    dto.ProductList.Add((product != null) ? product.Clone() as LineItem.Dto : null);
                }
            }
            return dto;
        }

    }

}
