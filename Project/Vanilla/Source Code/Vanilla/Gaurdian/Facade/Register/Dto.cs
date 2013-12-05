using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.Register
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String LoginId { get; set; }

        public String Password { get; set; }

        public List<Role.Dto> RoleList { get; set; }

    }

}
