using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Register
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Artifact.Category Category { get; set; }

        public List<Module.Dto> Modules { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Modules != null)
            {
                dto.Modules = new List<Module.Dto>();
                foreach (Module.Dto module in this.Modules)
                {
                    dto.Modules.Add(module.Clone() as Module.Dto);
                }
            }
            return dto;
        }

    }

}
