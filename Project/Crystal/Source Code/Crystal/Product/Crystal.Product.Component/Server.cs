using System;

namespace Crystal.Product.Component
{

    public abstract class Server : BinAff.Core.Observer.ObserverSubjectCrud
    {

        public Server(Data data)
            : base(data)
        {

        }

    }

}
