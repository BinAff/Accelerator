using System;
using BinAff.Core;
using System.Collections.Generic;

namespace Retinue.Lodge.Component.Room
{
    public interface IRoom
    {
        ReturnObject<Boolean> Open();
        ReturnObject<Boolean> Close();
        //ReturnObject<Boolean> UpdateRoomStatus();
        List<Data> GetCheckedInRoomsForBuilding();
        List<Data> GetBookedRoomsForBuilding();
        List<Data> GetOpenRoomsForBuilding();
        List<Data> GetCloseRoomsForBuilding();
    }
}
