using System;
using System.Collections.Generic;
using LodgeConfigFac = Retinue.Lodge.Configuration.Facade;
using RuleFacade = Retinue.Configuration.Rule.Facade;

namespace Retinue.Lodge.Facade.RoomReservation
{

    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {

        public RuleFacade.ConfigurationRuleDto ConfigurationRule { get; set; }        
        public List<LodgeConfigFac.Room.Dto> AllRoomList { get; set; }
        public List<LodgeConfigFac.Room.Category.Dto> CategoryList { get; set; }
        public List<LodgeConfigFac.Room.Type.Dto> TypeList { get; set; }

        public List<LodgeConfigFac.Room.Dto> FilteredRoomList { get; set; }
        public List<LodgeConfigFac.Room.Dto> RoomList { get; set; }  //cboRoomList...DataSource;
        public List<LodgeConfigFac.Room.Dto> SelectedRoomList { get; set; } //cboSelectedRoom...DataSource
        public Int32 AvailableRoomCount { get; set; }

        //public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }

    }

}
