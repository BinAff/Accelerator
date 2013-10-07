using System;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Autotourism.Component.Configuration.Observer
{
    public class Initial : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Autotourism.Component.Customer.Server(null));            
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
