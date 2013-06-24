using System;

namespace BinAff.Core.Observer
{

    public interface IRegistrar
    {

        ReturnObject<Boolean> Register(Observer.ISubject component);

    }

}
