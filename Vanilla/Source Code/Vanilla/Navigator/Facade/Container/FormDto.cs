using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Container
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public List<Module.Dto> CurrentModules { get; set; }
        public List<Module.Dto> FormModules { get; internal set; }
        public List<Module.Dto> CatalogueModules { get; internal set; }
        public List<Module.Dto> ReportModules { get; internal set; }

    }

}
