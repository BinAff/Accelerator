
using System;
using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Lodge.Observer
{
    public class RoomCheckIn : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            //add checkin obervers
            //component.RegisterObserver(new Component.Room.CheckIn.Server(null));

            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
