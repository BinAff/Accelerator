﻿using System;

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
        /// Is the module is mandatory
        /// </summary>
        internal Boolean IsMandatory { get; set; }

    }

}
