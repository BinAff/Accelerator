using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crystal.Report.Component
{
    public abstract class Server : BinAff.Core.Crud
    {
        public Server(Data data)
            : base(data)
        {

        }
    }
}
