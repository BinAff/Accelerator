using System;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Lodge.Observer
{
    public class Reservation : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Room.CheckIn.Server(null));

            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
