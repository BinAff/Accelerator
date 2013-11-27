using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Container
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Module.FormDto ModuleFormDto { get; set; }

        public Dto Dto { get; set; }

        //public Module.Dto CurrentModuleDef { get; set; }

    }

}
