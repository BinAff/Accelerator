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
        /// Extension of document
        /// </summary>
        public String Extension { get; set; }

        /// <summary>
        /// Virtual path of Artifact
        /// </summary>
        public String Path { get; set; }

        public String FullPath
        {
            get
            {
                return this.Path + "." + this.Extension;
            }
        }

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

        public Data Parent { get; set; }

        public BinAff.Core.Data ComponentData { get; set; }

        public Crystal.License.Component.Data ComponentDefinition { get; set; }

        public Category Category { get; set; }

        public Boolean IsAttachmentSupported { get; set; }

        public Int16 AttachmentCount { get; set; }

        public List<Data> AttachmentList { get; set; }

    }

}
