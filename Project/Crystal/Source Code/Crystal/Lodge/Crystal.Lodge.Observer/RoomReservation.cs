
using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Lodge.Observer
{
    public class RoomReservation : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Room.CheckIn.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
