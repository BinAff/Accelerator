using System;

namespace Crystal.License.Module
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Module name
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// Module name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Module description
        /// </summary>
        internal String Description { get; set; }

        /// <summary>
        /// Is there any form for module
        /// </summary>
        internal Boolean IsForm { get; set; }

        /// <summary>
        /// Is there any report for module
        /// </summary>
        internal Boolean IsReport { get; set; }

        /// <summary>
        /// Is there any catalogue for module
        /// </summary>
        internal Boolean IsCatalogue { get; set; }

    }

}
