using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.Account
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }
        public List<Role.Dto> RoleList { get; set; }
        public Rule.Dto Rule { get; set; }

    }

}
