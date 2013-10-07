using BinAff.Core.Observer;
using BinAff.Core;
using System;

namespace Crystal.Lodge.Observer
{
    public class RoomStatus : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Room.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
