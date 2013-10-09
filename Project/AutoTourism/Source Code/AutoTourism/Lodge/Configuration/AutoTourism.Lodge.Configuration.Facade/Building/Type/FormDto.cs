using System.Collections.Generic;

namespace AutoTourism.Lodge.Configuration.Facade.Building.Type
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto BuildingType { get; set; }
        public List<Dto> BuildingTypeList { get; set; }

    }

}
