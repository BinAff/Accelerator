using System.Collections.Generic;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {
        public Dto Dto { get; set; }
        public RuleFacade.ConfigurationRuleDto configurationRuleDto { get; set; }
        public List<LodgeConfigurationFacade.Room.Dto> roomList { get; set; }
    }
}
