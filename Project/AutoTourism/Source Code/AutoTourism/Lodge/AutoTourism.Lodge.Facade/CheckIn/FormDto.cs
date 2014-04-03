using System.Collections.Generic;
using LodgeConfFac = AutoTourism.Lodge.Configuration.Facade;
using RuleFac = AutoTourism.Configuration.Rule.Facade;

namespace AutoTourism.Lodge.Facade.CheckIn
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto dto { get; set; }
        //public LodgeFac.RoomReservationRegister.Dto roomReservationRegisterDto { get; set; } 
        public RuleFac.ConfigurationRuleDto configurationRuleDto { get; set; }
        public List<LodgeConfFac.Room.Dto> roomList { get; set; }
        public List<LodgeConfFac.Room.Category.Dto> CategoryList { get; set; }
        public List<LodgeConfFac.Room.Type.Dto> TypeList { get; set; }

    }

}
