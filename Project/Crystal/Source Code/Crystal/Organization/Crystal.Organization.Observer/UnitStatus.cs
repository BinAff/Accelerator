using System;

using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Organization.Observer
{

    public class UnitStatus : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Crystal.Organization.Component.Server(null) as ObserverCrud);
            return new ReturnObject<Boolean> { Value = true };
        }

    }

}