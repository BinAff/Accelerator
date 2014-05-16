using System.Collections.Generic;
using System;

namespace Vanilla.Invoice.Facade
{
    public class Dto : Vanilla.Form.Facade.Document.Dto
    {
        public string invoiceNumber { get; set; }
        public double advance { get; set; }
        public double discount { get; set; }
        public Buyer.Dto buyer { get; set; }
        public Seller.Dto seller { get; set; }
        public DateTime date { get; set; }
        public List<LineItem.Dto> productList { get; set; }
        public List<Taxation.Dto> taxationList { get; set; }
        public List<Payment.Dto> paymentList { get; set; }  
    }
}
