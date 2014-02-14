using System;
using System.Collections.Generic;

namespace Crystal.Guardian.Component.Account
{

    /// <summary>
    /// User description
    /// </summary>
    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// User's login identifier
        /// </summary>
        public String LoginId { get; set; }

        /// <summary>
        /// Account password
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// Profile of user
        /// </summary>
        public Profile.Data Profile { get; set; }

        /// <summary>
        /// List of user role
        /// </summary>
        public List<BinAff.Core.Data> RoleList { get; set; }

        /// <summary>
        /// List of security answers
        /// </summary>
        public List<BinAff.Core.Data> SecurityAnswerList { get; set; }

        public LoginHistory.Data LoginInfo { get; set; }

        public List<BinAff.Core.Data> LoginHistory { get; set; }

    }

}
