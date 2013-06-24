using System;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Lodge.Observer
{
    public class RoomType : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Room.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
