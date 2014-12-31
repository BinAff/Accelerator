using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Container
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Vanilla.Utility.Facade.Artifact.Category Category { get; set; }

        public List<Vanilla.Utility.Facade.Module.Dto> Modules { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Modules != null)
            {
                dto.Modules = new List<Vanilla.Utility.Facade.Module.Dto>();
                foreach (Vanilla.Utility.Facade.Module.Dto module in this.Modules)
                {
                    dto.Modules.Add(module.Clone() as Vanilla.Utility.Facade.Module.Dto);
                }
            }
            return dto;
        }

    }

}
