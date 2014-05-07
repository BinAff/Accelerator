using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Module
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public List<Module.Dto> FormModuleList { get; set; }
        public List<Module.Dto> CatalogueModuleList { get; set; }
        public List<Module.Dto> ReportModuleList { get; set; }
        public Dto Dto { get; set; }
        public Artifact.FormDto CurrentArtifact { get; set; }
        public Rule.Dto Rule { get; set; }

    }

}
