using System;
using System.Collections.Generic;

using FacLib = BinAff.Facade.Library;

using ModDefFac = Vanilla.Utility.Facade.Module.Definition;

namespace Vanilla.Utility.Facade.Artifact
{

    public class Dto : BinAff.Facade.Library.Dto
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
        /// Virtual extension of Artifact
        /// </summary>
        public String Extension { get; set; }

        public String FullFileName
        {
            get
            {
                if (this.Style == Type.Document)
                {
                    return this.FileName + "." + this.Extension;
                }
                else
                {
                    return this.FileName;
                }
            }
        }

        public String FullPath
        {
            get
            {
                if (this.Style == Type.Document)
                {
                    return this.Path + "." + this.Extension;
                }
                else
                {
                    return this.Path;
                }
            }
        }

        /// <summary>
        /// Type of Arctifact
        /// </summary>
        public Type Style { get; set; }

        public Category Category { get; set; }

        public Boolean IsAttachmentSupported { get; set; }

        public List<Dto> Children { get; set; }

        /// <summary>
        /// Attached module data
        /// </summary>
        public FacLib.Dto Module { get; set; }

        /// <summary>
        /// Attached module data
        /// </summary>
        public ModDefFac.Dto ComponentDefinition { get; set; }

        public FacLib.Dto Parent { get; set; }

        public Audit.Dto AuditInfo { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Children != null)
            {
                dto.Children = new List<Dto>();
                foreach (Dto child in this.Children)
                {
                    dto.Children.Add(child.Clone() as Dto);
                }
            }
            dto.Module = this.Module.Clone();
            dto.ComponentDefinition = this.ComponentDefinition.Clone() as ModDefFac.Dto;
            dto.Parent = this.Parent.Clone();
            dto.AuditInfo = this.AuditInfo.Clone();
            return dto;
        }

    }

}
