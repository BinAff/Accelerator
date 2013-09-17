using System.Collections.Generic;

namespace AutoTourism.Facade.Configuration.Lodge
{
    public class FormDto
    {
        public Dto Lodge { get; set; }
        public List<Dto> LodgeList { get; set; }
        public List<State.Dto> StateList { get; set; }
    }
}
