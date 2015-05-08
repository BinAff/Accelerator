using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Retinue.Lodge.Observer
{

    public class RoomCheckIn : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            //add checkin obervers
            //component.RegisterObserver(new Component.Room.CheckIn.Server(null));

            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
