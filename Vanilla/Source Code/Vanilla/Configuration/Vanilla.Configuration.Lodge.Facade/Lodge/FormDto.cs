using System.Collections.Generic;
using State = Vanilla.Configuration.Facade.State;

namespace Vanilla.Configuration.Lodge.Facade.Lodge
{
    public class FormDto
    {
        public Dto Lodge { get; set; }
        public List<Dto> LodgeList { get; set; }
        public List<State.Dto> StateList { get; set; }
    }
}
