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
        Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeConfigurationFacade.Room.Dto room, Int64 categoryId, Int64 typeId, Int32 acPreference);
        List<LodgeConfigurationFacade.Room.Dto> GetFilteredRoomsWithCategoryTypeAndACPreference(List<LodgeConfigurationFacade.Room.Dto> roomList, Int64 categoryId, Int64 typeId, Int32 acPreference);
        Int32 GetNoOfRoomsBookedBetweenTwoDates(DateTime startDate, DateTime endDate, Int64 reservationId);
        Int32 GetNoOfRoomsBookedBetweenTwoDates(DateTime startDate, DateTime endDate, Int64 reservationId, Int64 categoryId, Int64 typeId, Int32 acPreference);
    }
}
