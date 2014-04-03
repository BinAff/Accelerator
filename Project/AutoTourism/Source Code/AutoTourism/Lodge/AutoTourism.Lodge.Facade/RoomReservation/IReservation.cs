using System;
using System.Collections.Generic;

using BinAff.Core;

using LodgeConfFac = AutoTourism.Lodge.Configuration.Facade;
using CustomerFacade = AutoTourism.Customer.Facade;
using LodgeFacade = AutoTourism.Lodge.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{

    public interface IReservation
    {

        ReturnObject<Boolean> ChangeReservationStatus();
        ReturnObject<List<LodgeConfFac.Room.Dto>> GetBookedRooms(DateTime startDate, DateTime endDate);
        Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeConfFac.Room.Dto room, Int64 categoryId, Int64 typeId, Int32 acPreference);
        List<LodgeConfFac.Room.Dto> GetFilteredRoomsWithCategoryTypeAndACPreference(List<LodgeConfFac.Room.Dto> roomList, Int64 categoryId, Int64 typeId, Int32 acPreference);
        Int32 GetNoOfRoomsBookedBetweenTwoDates(DateTime startDate, DateTime endDate, Int64 reservationId);
        Int32 GetNoOfRoomsBookedBetweenTwoDates(DateTime startDate, DateTime endDate, Int64 reservationId, Int64 categoryId, Int64 typeId, Int32 acPreference);
        CustomerFacade.Dto CloneCustomer(CustomerFacade.Dto customerDto);
        LodgeFacade.RoomReservation.Dto CloneReservaion(LodgeFacade.RoomReservation.Dto reservationDto);

    }

}
