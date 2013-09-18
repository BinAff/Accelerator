using System.Collections.Generic;

namespace Vanilla.Configuration.Lodge.Facade.Building
{

    public class FormDto
    {
        public List<Dto> BuildingList { get; set; }
        public List<BuildingType.Dto> TypeList { get; set; }
    }

}
