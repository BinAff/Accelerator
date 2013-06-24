using System.Collections.Generic;
using BinAff.Core;
using System;

namespace Crystal.Activity.Component
{

    public abstract class Server : Crystal.Customer.Component.Action.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override Crud CreateInstance(BinAff.Core.Data data);

        protected override void CreateChildren()
        {
            base.CreateChildren();
        }


    }

}
