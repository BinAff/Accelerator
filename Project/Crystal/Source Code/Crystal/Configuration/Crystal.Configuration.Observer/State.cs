using System;

using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Configuration.Observer
{

    public class State : IRegistrar
    {

        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            //component.RegisterObserver(new AutoTourism.Component.Customer.Server(null));
            //component.RegisterObserver(new Crystal.Organization.Component.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
