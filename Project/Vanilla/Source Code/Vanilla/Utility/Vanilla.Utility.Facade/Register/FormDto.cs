using UtilFac = Vanilla.Utility.Facade;

namespace Vanilla.Navigator.Facade.Register
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public UtilFac.Module.FormDto ModuleFormDto { get; set; }

        public Dto Dto { get; set; }

        public UtilFac.Rule.Dto Rule { get; set; }

    }

}
