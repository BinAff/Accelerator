using System;

using ContFac = Vanilla.Utility.Facade.Container;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

namespace Vanilla.CommercialInstrument.Facade.Container
{

    public class Server : ContFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        protected override String GetRecentFileNodeName()
        {
            return "Commercial Instrument";
        }

        public override ArtfFac.Category GetCategory()
        {
            return ArtfFac.Category.Form;
        }

    }

}
