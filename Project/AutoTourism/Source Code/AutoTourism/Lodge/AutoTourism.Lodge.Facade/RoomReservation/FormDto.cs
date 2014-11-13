﻿using System;
using System.Collections.Generic;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;
using RuleFacade = AutoTourism.Configuration.Rule.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{

    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {

        public RuleFacade.ConfigurationRuleDto ConfigurationRule { get; set; }        
        public List<LodgeConfigurationFacade.Room.Dto> AllRoomList { get; set; }
        public List<LodgeConfigurationFacade.Room.Category.Dto> CategoryList { get; set; }
        public List<LodgeConfigurationFacade.Room.Type.Dto> TypeList { get; set; }

        public List<LodgeConfigurationFacade.Room.Dto> FilteredRoomList { get; set; }
        public List<LodgeConfigurationFacade.Room.Dto> RoomList { get; set; }  //cboRoomList...DataSource;
        public List<LodgeConfigurationFacade.Room.Dto> SelectedRoomList { get; set; } //cboSelectedRoom...DataSource
        public Int32 AvailableRoomCount { get; set; }

        //public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }

    }

}
