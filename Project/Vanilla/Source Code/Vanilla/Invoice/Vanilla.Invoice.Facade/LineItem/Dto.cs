
using System;
namespace Vanilla.Invoice.Facade.LineItem
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String description { get; set; }
        public Double unitRate { get; set; }
        public Int32 count { get; set; }
        public Double total { get; set; }

        public Double LuxuaryTax { get; set; }
        public Double ServiceTax { get; set; }
        public Double GrandTotal { get; set; }

        public Int64 roomCategoryId { get; set; }
        public Int64 roomTypeId { get; set; }
        public Boolean roomIsAC { get; set; }
    }
}
