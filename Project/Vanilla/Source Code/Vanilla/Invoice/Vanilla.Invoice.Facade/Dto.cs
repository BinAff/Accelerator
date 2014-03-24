using System.Collections.Generic;

namespace Vanilla.Invoice.Facade
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public string invoiceNumber { get; set; }
        public double advance { get; set; }
        public double discount { get; set; }
        public Buyer.Dto buyer { get; set; }
        public Seller.Dto seller { get; set; }
        public List<LineItem.Dto> productList { get; set; }
        public List<Taxation.Dto> taxationList { get; set; }
        public List<Payment.Dto> paymentList { get; set; } 
    }
}
