using System;
using System.Collections.Generic;

namespace Crystal.License
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// List of licensed forms
        /// </summary>
        public List<Module.Data> FormList { get; internal set; }

        /// <summary>
        /// List of licensed reports
        /// </summary>
        public List<Module.Data> ReportList { get; internal set; }

        /// <summary>
        /// List of licensed catalogues
        /// </summary>
        public List<Module.Data> CatalogueList { get; internal set; }

    }

}
