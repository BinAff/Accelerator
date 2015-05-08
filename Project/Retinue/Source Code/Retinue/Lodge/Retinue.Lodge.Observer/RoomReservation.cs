using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Retinue.Lodge.Observer
{

    public class RoomReservation : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Room.CheckIn.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
