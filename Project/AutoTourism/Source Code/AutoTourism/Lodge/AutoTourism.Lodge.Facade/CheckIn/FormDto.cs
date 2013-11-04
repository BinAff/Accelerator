using System.Collections.Generic;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class FormDto
    {
        public Dto CheckInDto { get; set; }
        public List<LodgeConfigurationFacade.Room.Dto> roomList { get; set; }
    }
}
