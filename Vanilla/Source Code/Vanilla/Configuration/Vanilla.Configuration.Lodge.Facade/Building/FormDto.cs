using System.Collections.Generic;

namespace AutoTourism.Facade.Configuration.Building
{

    public class FormDto
    {
        public List<Dto> BuildingList { get; set; }
        public List<BuildingType.Dto> TypeList { get; set; }
    }

}
