using System;
using System.Collections.Generic;

namespace Vanilla.Invoice.Facade.Receipt
{
    public class Dto
    {
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public double Advance { get; set; }
        public double Discount { get; set; }
        public Buyer.Dto Buyer { get; set; }
        public Seller.Dto Seller { get; set; }
        
        public List<LineItem.Dto> ProductList { get; set; }
    }
}
