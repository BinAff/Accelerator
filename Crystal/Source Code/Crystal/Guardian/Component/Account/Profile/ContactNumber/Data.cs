using System;

namespace Crystal.Guardian.Component.Account.Profile.ContactNumber
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// User Identifier
        /// </summary>
        public Int64 UserId { get; set; }

        /// <summary>
        /// Contact number of user profile
        /// </summary>
        public String ContactNumber { get; set; }

    }

}
