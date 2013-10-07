using System;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Lodge.Observer
{
    public class BuildingType : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Component.Building.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
