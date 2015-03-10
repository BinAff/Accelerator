using System;
using System.Collections.Generic;

namespace Vanilla.Invoice.Facade.LineItem
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Description { get; set; }
        public Double UnitRate { get; set; }
        public Int32 Count { get; set; }
        public Double Total
        {
            get
            {
                return this.UnitRate * this.Count;
            }
        }

        public Double LuxuaryTax { get; set; }
        public Double ServiceTax { get; set; }
        public Double GrandTotal { get; set; }

        public Int64 RoomCategoryId { get; set; }
        public Int64 RoomTypeId { get; set; }
        public Boolean RoomIsAC { get; set; }

        public List<BinAff.Facade.Library.Dto> TaxList { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.TaxList != null)
            {
                dto.TaxList = new List<BinAff.Facade.Library.Dto>();
                foreach (Taxation.Dto tax in this.TaxList)
                {
                    dto.TaxList.Add((tax != null) ? tax.Clone() as Taxation.Dto : null);
                }
            }
            return dto;
        }

    }

}
