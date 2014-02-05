using System;
using System.Collections.Generic;

using CrysConf = Crystal.Configuration.Component;

namespace Crystal.Guardian.Component.Account.Profile
{

    /// <summary>
    /// User Profile 
    /// </summary>
    /// <remarks>
    /// Profile is depended on User component
    /// </remarks>
    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// User identifier
        /// </summary>
        public Int64 UserId { get; set; }

        /// <summary>
        /// Initial of user
        /// </summary>
        public CrysConf.Initial.Data Initial { get; set; }

        public String Name
        {
            get
            {
                return this.FirstName
                    + (String.IsNullOrEmpty(this.MiddleName) ? "" : " " + this.MiddleName)
                    + (String.IsNullOrEmpty(this.LastName)?  "" : " " + this.LastName);
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
        public List<BinAff.Core.Data> ContactNumberList { get; set; }

        public BinAff.Core.Data Extension { get; set; }

    }

}
