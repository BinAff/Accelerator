using System;
using System.Collections.Generic;

using GaurdianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Name of Artifact
        /// </summary>
        public String Name { get; set; }

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
        public Int32 Version { get; set; }

        /// <summary>
        /// Created by user
        /// </summary>
        public GaurdianAcc.Data CreatedBy { get; set; }

        /// <summary>
        /// Modified by User
        /// </summary>
        public GaurdianAcc.Data ModifiedBy { get; set; }

        /// <summary>
        /// Time when artifact created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Time when artifact last modified
        /// </summary>
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Children of srtifact
        /// </summary>
        public List<Data> Children { get; set; }

        internal Int64 ParentId { get; set; }

        public enum Type
        {
            Document,
            Directory
        }

    }

}
