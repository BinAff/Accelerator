using System;

using BinAff.Core;

using VanAcc = Vanilla.Guardian.Facade.Account;
using ContFac = Vanilla.Utility.Facade.Container;

namespace Vanilla.Form.Facade.Container
{

    public class Server : ContFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        protected override String GetRecentFileNodeName()
        {
            return "Form";
        }

    }

}
