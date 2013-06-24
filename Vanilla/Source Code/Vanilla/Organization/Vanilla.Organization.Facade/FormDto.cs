using System.Collections.Generic;

namespace Vanilla.Organization.Facade
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {
        public List<State.Dto> StateList { get; set; }
        public Dto Dto { get; set; }
    }
}
