using System;

namespace BinAff.Core.Observer
{
    public interface IObserver
    {
        ReturnObject<Boolean> Update(Data subject);
    }
}
