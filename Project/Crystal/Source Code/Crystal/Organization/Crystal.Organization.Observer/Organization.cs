using System;

using BinAff.Core.Observer;
using BinAff.Core;

namespace Crystal.Organization.Observer
{

    public class Organization : IRegistrar
    {

        ReturnObject<Boolean> IRegistrar.Register(ISubject component)
        {
            //component.RegisterObserver(new Retinue.Lodge.Component.Building.Server(null));
            component.RegisterObserver(this.CreateUnitInstance());

            return new ReturnObject<Boolean> { Value = true };
        }

        protected virtual ObserverCrud CreateUnitInstance()
        {
            throw new NotImplementedException();
        }

    }

}
