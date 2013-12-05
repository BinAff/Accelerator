using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Guardian.Facade.Register
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }

        public List<Role.Dto> RoleList { get; set; }

        public Rule.Dto Rule { get; set; }

    }

}
