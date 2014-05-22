using System;

namespace Vanilla.Utility.Facade.Rule
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        /// <summary>
        /// Module separetor
        /// </summary>
        public String ModuleSeperator { get; set; }

        /// <summary>
        /// Path seperator
        /// </summary>
        public String PathSeperator { get; set; }
    }
}
