using System.Collections.Generic;

using UtilFac = Vanilla.Utility.Facade;

namespace Vanilla.Navigator.Facade.SearchResult
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }

        public List<UtilFac.Artifact.Dto> ArtifactList { get; set; }

    }

}
