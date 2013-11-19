using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Navigator.Facade.Module
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public List<Module.Dto> FormModuleList { get; set; }
        public List<Module.Dto> CatalogueModuleList { get; set; }
        public List<Module.Dto> ReportModuleList { get; set; }
        public Dto Dto { get; set; }

    }

}
