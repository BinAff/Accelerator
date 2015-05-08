using System;
using System.Collections.Generic;

namespace Crystal.Accountant.Component.Taxation
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Name of the tax
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Tax amount
        /// </summary>
        public Double Amount { get; set; }

        /// <summary>
        /// Tax amount is in percentage or not
        /// </summary>
        public Boolean IsPercentage { get; set; }

        /// <summary>
        /// List of slabs
        /// </summary>
        internal List<BinAff.Core.Data> SlabList { get; set; }

    }

}
