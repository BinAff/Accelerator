using System.Collections.Generic;

namespace Retinue.Lodge.Configuration.Facade.Tariff
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }
        public List<Dto> TariffList { get; set; }
        public List<Room.Category.Dto> CategoryList { get; set; }
        public List<Room.Type.Dto> TypeList { get; set; }

    }

}