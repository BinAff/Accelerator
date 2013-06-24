using System;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Organization.Observer
{
    public class Organization : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Crystal.Lodge.Component.Building.Server(null));

            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
