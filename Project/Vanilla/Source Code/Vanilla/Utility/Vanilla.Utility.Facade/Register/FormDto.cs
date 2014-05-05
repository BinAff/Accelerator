namespace Vanilla.Utility.Facade.Register
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Module.FormDto ModuleFormDto { get; set; }

        public Dto Dto { get; set; }

        public Rule.Dto Rule { get; set; }

    }

}
