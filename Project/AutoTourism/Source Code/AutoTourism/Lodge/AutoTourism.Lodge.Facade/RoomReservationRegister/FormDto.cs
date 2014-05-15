using BinAff.Core;
using System.Collections.Generic;

using RuleFacade = AutoTourism.Configuration.Rule.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservationRegister
{

    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {

        public List<Dto> RoomReservationDtoList { get; set; }
        public List<Table> StatusList { get; set; }
        public RuleFacade.ConfigurationRuleDto configurationRuleDto { get; set; }

    }

}
