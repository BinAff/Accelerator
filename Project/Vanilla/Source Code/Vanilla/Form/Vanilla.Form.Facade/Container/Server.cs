using System;

using BinAff.Core;

using VanAcc = Vanilla.Guardian.Facade.Account;
using ContFac = Vanilla.Utility.Facade.Container;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

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

        public override ArtfFac.Category GetCategory()
        {
            return ArtfFac.Category.Form;
        }

    }

}
