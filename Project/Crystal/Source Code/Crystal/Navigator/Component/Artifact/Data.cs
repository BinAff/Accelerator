using System;
using System.Collections.Generic;

using GuardianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public class Data : BinAff.Core.Data
    {
        
        /// <summary>
        /// File name associaated with Artifact
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// Virtual path of Artifact
        /// </summary>
        public String Path { get; set; }

        /// <summary>
        /// Type of Arctifact
        /// </summary>
        public Type Style { get; set; }

        /// <summary>
        /// Version number
        /// </summary>
        public Int32 Version { get; internal set; }

        /// <summary>
        /// Created by user
        /// </summary>
        public GuardianAcc.Data CreatedBy { get; set; }

        /// <summary>
        /// Modified by User
        /// </summary>
        public GuardianAcc.Data ModifiedBy { get; set; }

        /// <summary>
        /// Time when artifact created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when artifact last modified
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Children of srtifact
        /// </summary>
        public List<BinAff.Core.Data> Children { get; set; }

        public Int64? ParentId { get; set; }

        public BinAff.Core.Data ModuleData { get; set; }

        public Category Category { get; set; }

    }

}
