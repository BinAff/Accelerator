using System;

namespace Vanilla.Utility.Facade.Report
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public DateTime Date { get; set; }
        public Category.Dto Category { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            dto.Category = this.Category.Clone() as Category.Dto;
            return dto;
        }

    }

}
