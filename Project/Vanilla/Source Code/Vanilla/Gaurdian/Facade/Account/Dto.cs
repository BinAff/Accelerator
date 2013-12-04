﻿using System;
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

        public BinAff.Core.Table Initial { get; set; }

        public String Name
        {
            get
            {
                return this.FirstName
                    + (String.IsNullOrEmpty(this.MiddleName) ? "" : " " + this.MiddleName)
                    + (String.IsNullOrEmpty(this.LastName) ? "" : " " + this.LastName);
            }
        }

        /// <summary>
        /// First name of user
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// Middle name of user
        /// </summary>
        public String MiddleName { get; set; }

        /// <summary>
        /// Last name of user
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// Date of birth of user
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// List of contact numbers of user
        /// </summary>
        public List<BinAff.Core.Table> ContactNumberList { get; set; }

        public BinAff.Facade.Library.Dto Extension { get; set; }

    }

}
