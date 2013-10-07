
using System;

using BinAff.Core;
using BinAff.Core.Observer;


namespace Crystal.Invoice.Observer
{
    public class PaymentType : IRegistrar
    {
        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {                   
            component.RegisterObserver(new Component.Payment.Server(null));
            return new ReturnObject<Boolean> { Value = true };
        }
    }
}
