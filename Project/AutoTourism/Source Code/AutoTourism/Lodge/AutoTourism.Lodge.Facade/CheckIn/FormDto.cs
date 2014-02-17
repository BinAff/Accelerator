using System.Collections.Generic;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {
        public Dto dto { get; set; }
        //public LodgeFacade.RoomReservationRegister.Dto roomReservationRegisterDto { get; set; } 
        public RuleFacade.ConfigurationRuleDto configurationRuleDto { get; set; }
        public List<LodgeConfigurationFacade.Room.Dto> roomList { get; set; }
        public List<LodgeConfigurationFacade.Room.Category.Dto> CategoryList { get; set; }
        public List<LodgeConfigurationFacade.Room.Type.Dto> TypeList { get; set; }
    }
}
