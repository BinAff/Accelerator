using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Lodge.Observer
{

    public class Room : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Room.CheckIn.Server(null));
            component.RegisterObserver(new Component.Room.Reservation.Server(null));
            component.RegisterObserver(new Component.Room.Tariff.Server(null));

            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
