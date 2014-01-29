using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Container
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Vanilla.Utility.Facade.Module.FormDto ModuleFormDto { get; set; }

        public Dto Dto { get; set; }

        public Vanilla.Utility.Facade.Rule.Dto Rule { get; set; }

    }

}
