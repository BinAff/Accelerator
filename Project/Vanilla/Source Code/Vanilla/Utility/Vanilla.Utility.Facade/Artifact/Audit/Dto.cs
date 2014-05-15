using System;

namespace Vanilla.Utility.Facade.Artifact.Audit
{

    public class Dto
    {

        /// <summary>
        /// Version number
        /// </summary>
        public Int32 Version { get; set; }

        /// <summary>
        /// Created by user
        /// </summary>
        public BinAff.Core.Table CreatedBy { get; set; }

        /// <summary>
        /// Modified by User
        /// </summary>
        public BinAff.Core.Table ModifiedBy { get; set; }

        /// <summary>
        /// Time when artifact created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when artifact last modified
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

    }

}
