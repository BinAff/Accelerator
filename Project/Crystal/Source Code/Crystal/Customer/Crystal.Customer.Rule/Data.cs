using System;

namespace Crystal.Customer.Rule
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Mandatoriness of PIN
        /// </summary>
        public Boolean IsPinNumber { get; set; }

        /// <summary>
        /// Minimum two contact number
        /// </summary>
        public Boolean IsAlternateContactNumber { get; set; }

        /// <summary>
        /// Mandatoriness of Email
        /// </summary>
        public Boolean IsEmail { get; set; }

        /// <summary>
        /// Mandatoriness of identity proof
        /// </summary>
        public Boolean IsIdentityProof { get; set; }

    }

}
