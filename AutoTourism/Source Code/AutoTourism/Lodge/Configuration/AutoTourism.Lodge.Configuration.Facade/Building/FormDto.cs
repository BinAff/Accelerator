using System.Collections.Generic;

namespace AutoTourism.Lodge.Configuration.Facade.Building
{

    public class FormDto
    {
        public List<Dto> BuildingList { get; set; }
        public List<BuildingType.Dto> TypeList { get; set; }
    }

}
