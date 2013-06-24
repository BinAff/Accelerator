using BinAff.Core.Observer;
using BinAff.Core;
using System;

namespace Crystal.Lodge.Observer 
{
    public class BuildingStatus : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Building.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
