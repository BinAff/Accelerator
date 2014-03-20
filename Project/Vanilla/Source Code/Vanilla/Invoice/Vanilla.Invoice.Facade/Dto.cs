using System.Collections.Generic;

namespace Vanilla.Invoice.Facade
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public double advance { get; set; }
        public Buyer.Dto buyer { get; set; }
        public Seller.Dto seller { get; set; }
        public List<LineItem.Dto> productList { get; set; }
        public List<Taxation.Dto> taxationList { get; set; }
    }
}
