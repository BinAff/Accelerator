using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.Account
{


    public class Dto : BinAff.Facade.Library.Dto
    {

        /// <summary>
        /// User log in identifier
        /// </summary>
        public String LoginId { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// Original list of roles
        /// </summary>
        public List<Role.Dto> RoleList { get; set; }

    }

}
