using System;
using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Module
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }

        public List<Artifact.Dto> ArtifactList { get; set; }

    }

}
