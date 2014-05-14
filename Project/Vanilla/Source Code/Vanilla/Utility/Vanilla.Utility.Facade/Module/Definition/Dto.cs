using System;

namespace Vanilla.Utility.Facade.Module.Definition
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }

        public String Code { get; set; }

        public String ComponentFormType { get; set; }

        public BinAff.Facade.Library.Dto ComponentFormDto { get; set; }

        public Category.Dto Category { get; set; }

        public object Clone()
        {
            Dto modDef = this.MemberwiseClone() as Dto;
            modDef.ComponentFormDto = this.ComponentFormDto.Clone() as BinAff.Facade.Library.Dto;
            modDef.Category = this.Category.Clone() as Category.Dto;
            return modDef;
        }

    }

}
