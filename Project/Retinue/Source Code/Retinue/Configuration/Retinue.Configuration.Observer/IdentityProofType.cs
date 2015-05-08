using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Retinue.Component.Configuration.Observer
{

    public class IdentityProofType : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Retinue.Customer.Component.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
