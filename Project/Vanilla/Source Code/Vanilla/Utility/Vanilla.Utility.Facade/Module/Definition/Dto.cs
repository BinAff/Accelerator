using System;

namespace Vanilla.Utility.Facade.Module.Definition
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }

        public String Code { get; set; }

        public String Description { get; set; }

        public String ComponentFormType { get; set; }

        public BinAff.Facade.Library.Dto ComponentFormDto { get; set; }

        public Category.Dto Category { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.ComponentFormDto != null) dto.ComponentFormDto = this.ComponentFormDto.Clone();
            if (this.Category != null) dto.Category = this.Category.Clone() as Category.Dto;
            return dto;
        }

    }

}
