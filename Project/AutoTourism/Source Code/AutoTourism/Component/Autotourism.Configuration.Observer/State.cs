using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace AutoTourism.Component.Configuration.Observer
{

    public class State : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new AutoTourism.Component.Customer.Server(null));
            component.RegisterObserver(new Crystal.Organization.Component.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
