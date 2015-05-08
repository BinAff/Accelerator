using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Organization.Observer
{

    public class UnitType : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Crystal.Organization.Component.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
