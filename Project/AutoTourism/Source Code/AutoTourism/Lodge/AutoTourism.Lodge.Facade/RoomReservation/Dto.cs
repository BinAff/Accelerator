﻿using System;
using System.Collections.Generic;

using BinAff.Core;
using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public class Dto : BinAff.Facade.Library.Dto
    {        
        public DateTime BookingDate { get; set; }
        public DateTime BookingFrom { get; set; }
        public Int16 NoOfDays { get; set; }
        public Int16 NoOfPersons { get; set; }
        public Int16 NoOfRooms { get; set; }
        public Double Advance { get; set; }
        public Int64 BookingStatusId { get; set; }

        public Table RoomCategory { get; set; }
        public Table RoomType { get; set; }
        public Boolean IsAC { get; set; }
        public Boolean isCheckedIn { get; set; }

        public List<LodgeConfigurationFacade.Room.Dto> RoomList { get; set; }
        public CustomerFacade.Dto Customer { get; set; }

        public String ArtifactPath { get; set; }
    }
}
