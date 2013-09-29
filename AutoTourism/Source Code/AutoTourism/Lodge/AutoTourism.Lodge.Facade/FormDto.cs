using BinAff.Core;
using System.Collections.Generic;

namespace AutoTourism.Lodge.Facade
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Lodge { get; set; }
        public List<Dto> LodgeList { get; set; }
        public List<Table> StateList { get; set; }

    }

}
