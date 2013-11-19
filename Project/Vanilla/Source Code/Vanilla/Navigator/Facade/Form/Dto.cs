using System;
using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Form
{

    public class Dto : Vanilla.Navigator.Facade.Artifact.Dto
    {

        private BinAff.Facade.Library.Dto module;
        /// <summary>
        /// Attached module data
        /// </summary>
        public BinAff.Facade.Library.Dto Module
        {
            get
            {
                return this.module;
            }
            set
            {
                if (value != null && this.module != value)
                {
                    this.module = value;
                }
            }
        }

    }

}
