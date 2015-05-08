using System.Collections.Generic;

namespace Retinue.Lodge.Configuration.Facade.Room
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }
        public List<Dto> DtoList { get; set; }
        public List<Building.Dto> BuildingList { get; set; }
        public List<Room.Category.Dto> CategoryList { get; set; }
        public List<Room.Type.Dto> TypeList { get; set; }

    }

}
