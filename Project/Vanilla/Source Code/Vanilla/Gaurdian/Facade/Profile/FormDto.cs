using System.Collections.Generic;
using BinAff.Core;

namespace Vanilla.Guardian.Facade.Profile
{
    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }

        public List<Table> InitialList { get; set; }

    }
}
