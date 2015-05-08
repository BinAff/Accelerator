using System;

using BinAff.Core;
using BinAff.Core.Observer;

namespace Crystal.Accountant.Observer
{

    public class PaymentType : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            component.RegisterObserver(new Crystal.Accountant.Component.Payment.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }

    }

}
