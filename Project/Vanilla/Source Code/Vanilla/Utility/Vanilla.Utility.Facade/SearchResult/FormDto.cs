using System.Collections.Generic;

namespace Vanilla.Utility.Facade.SearchResult
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }

        public Artifact.Dto CurrentArtifact { get; set; }

        public List<Artifact.Dto> ArtifactList { get; set; }

    }

}
