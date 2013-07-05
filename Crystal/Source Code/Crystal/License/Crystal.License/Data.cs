using System;
using System.Collections.Generic;

namespace Crystal.License
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// List of licensed forms
        /// </summary>
        public List<Document.Data> FormList { get; internal set; }

        /// <summary>
        /// List of licensed reports
        /// </summary>
        public List<Document.Data> ReportList { get; internal set; }

        /// <summary>
        /// List of licensed catalogues
        /// </summary>
        public List<Document.Data> CatalogueList { get; internal set; }

    }

}
