using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Customer.Component.Navigator.Form
{

    public abstract class Server : CrystalNavigator.Form.Server
    {

        public Server(Data data)
            : base(data)
        {

        }

        protected abstract override void Compose();

        protected abstract override BinAff.Core.Data CreateDataObject();

        protected abstract override BinAff.Core.Crud CreateInstance(BinAff.Core.Data data);

    }

}
