using System;
using BinAff.Core;
using System.Collections.Generic;
using LodgeConfigurationFacade = AutoTourism.Lodge.Configuration.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{
    public interface IReservation
    {
        ReturnObject<Boolean> ChangeReservationStatus();
        ReturnObject<List<LodgeConfigurationFacade.Room.Dto>> GetBookedRooms(DateTime startDate, DateTime endDate);
    }
}
