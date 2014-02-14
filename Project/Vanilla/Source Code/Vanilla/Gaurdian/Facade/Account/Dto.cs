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

        public Profile.Dto Profile { get; set; }

        /// <summary>
        /// Original list of roles
        /// </summary>
        public List<Role.Dto> RoleList { get; set; }

        /// <summary>
        /// Answer for security question
        /// </summary>
        public SecurityAnswer.Dto SecurityAnswer { get; set; }

        public BinAff.Facade.Library.Dto Extension { get; set; }

        public LoginHistory.Dto LoginInfo { get; set; }

        public List<LoginHistory.Dto> LoginHistory { get; set; }

    }

}
