
using System;
using System.Collections.Generic;
using LodgeConfFac = AutoTourism.Lodge.Configuration.Facade;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using InvFac = Vanilla.Invoice.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;


namespace AutoTourism.Lodge.Facade.CheckIn
{

    public class FormDto : Vanilla.Form.Facade.Document.FormDto
    {
        //public Dto dto { get; set; }
        //public LodgeFac.RoomReservationRegister.Dto roomReservationRegisterDto { get; set; } 
        public RuleFac.ConfigurationRuleDto ConfigurationRuleDto { get; set; }
        public List<LodgeConfFac.Room.Dto> AllRoomList { get; set; }
        public List<LodgeConfFac.Room.Category.Dto> CategoryList { get; set; }
        public List<LodgeConfFac.Room.Type.Dto> TypeList { get; set; }

        public InvFac.Dto InvoiceDto { get; set; }
        public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }

        public List<LodgeConfigurationFacade.Room.Dto> FilteredRoomList { get; set; }
        public List<LodgeConfigurationFacade.Room.Dto> RoomList { get; set; }  //cboRoomList...DataSource;
        public List<LodgeConfigurationFacade.Room.Dto> SelectedRoomList { get; set; } //cboSelectedRoom...DataSource
        public Int32 AvailableRoomCount { get; set; }       

    }

}
