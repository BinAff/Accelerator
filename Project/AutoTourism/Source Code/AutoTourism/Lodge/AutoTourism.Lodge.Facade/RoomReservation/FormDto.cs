﻿using System.Collections.Generic;
using BinAff.Core;

using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }
        public RuleFacade.ConfigurationRuleDto configurationRuleDto { get; set; }        
        public List<LodgeConfigurationFacade.Room.Dto> roomList { get; set; }
        public List<LodgeConfigurationFacade.Room.Category.Dto> CategoryList { get; set; }
        public List<LodgeConfigurationFacade.Room.Type.Dto> TypeList { get; set; }

        //public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }

    }
}
