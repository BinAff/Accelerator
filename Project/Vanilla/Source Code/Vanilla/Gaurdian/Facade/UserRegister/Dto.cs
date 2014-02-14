using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.UserRegister
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String LoginId { get; set; }
        public List<Role.Dto> RoleList { get; set; }
        public List<Role.Dto> LoginHistory { get; set; } //Componet not created for login history

    }

}
