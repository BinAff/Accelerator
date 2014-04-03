using System.Collections.Generic;

namespace AutoTourism.Lodge.Configuration.Facade.Tariff
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto dto { get; set; }
        public List<Dto> TariffList { get; set; }
        public List<Room.Category.Dto> CategoryList { get; set; }
        public List<Room.Type.Dto> TypeList { get; set; }

    }

}
