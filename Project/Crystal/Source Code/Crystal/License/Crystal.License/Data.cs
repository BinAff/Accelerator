using System;
using System.Collections.Generic;

namespace Crystal.License
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// List of licensed forms
        /// </summary>
        public List<BinAff.Core.Data> FormList { get; internal set; }

        /// <summary>
        /// List of licensed reports
        /// </summary>
        public List<BinAff.Core.Data> ReportList { get; internal set; }

        /// <summary>
        /// List of licensed catalogues
        /// </summary>
        public List<BinAff.Core.Data> CatalogueList { get; internal set; }

    }

}
