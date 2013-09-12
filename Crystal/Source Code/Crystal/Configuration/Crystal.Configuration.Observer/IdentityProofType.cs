using System;
using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Configuration.Observer
{
    public class IdentityProofType : IRegistrar
    {
        ReturnObject<bool> IRegistrar.Register(ISubject component)
        {
            //component.RegisterObserver(new Autotourism.Component.Customer.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
