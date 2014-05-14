using System;

namespace Vanilla.Utility.Facade.Module.Category
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public String Extension { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }

}
