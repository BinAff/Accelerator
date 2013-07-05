using System;

namespace Crystal.License.Module
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Module name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Module description
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Is there any form for module
        /// </summary>
        public Boolean IsForm { get; set; }

        /// <summary>
        /// Is there any report for module
        /// </summary>
        public Boolean IsReport { get; set; }

        /// <summary>
        /// Is there any catalogue for module
        /// </summary>
        public Boolean IsCatalogue { get; set; }

    }

}
