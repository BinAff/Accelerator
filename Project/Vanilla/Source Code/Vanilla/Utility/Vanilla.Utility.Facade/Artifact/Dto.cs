using System;
using System.Collections.Generic;

using FacLib = BinAff.Facade.Library;

using ModDefFac = Vanilla.Utility.Facade.Module.Definition;

namespace Vanilla.Utility.Facade.Artifact
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        private String fileName;
        /// <summary>
        /// File name associaated with Artifact
        /// </summary>
        public String FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                if (value != null && this.fileName != value)
                {
                    this.fileName = value;
                }
            }
        }

        private String path;
        /// <summary>
        /// Virtual path of Artifact
        /// </summary>
        public String Path
        {
            get
            {
                return this.path;
            }
            set
            {
                if (value != null && this.path != value)
                {
                    this.path = value;
                }
            }
        }

        private String extension;
        /// <summary>
        /// Virtual extension of Artifact
        /// </summary>
        public String Extension
        {
            get
            {
                return this.extension;
            }
            set
            {
                if (value != null && this.extension != value)
                {
                    this.extension = value;
                }
            }
        }

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

        private Type style;
        /// <summary>
        /// Type of Arctifact
        /// </summary>
        public Type Style
        {
            get
            {
                return this.style;
            }
            set
            {
                if (this.style != value)
                {
                    this.style = value;
                }
            }
        }

        private Category category;
        public Category Category
        {
            get
            {
                return this.category;
            }
            set
            {
                if (this.category != value)
                {
                    this.category = value;
                }
            }
        }

        public Boolean IsAttachmentSupported { get; set; }

        //private Int32 version;
        ///// <summary>
        ///// Version number
        ///// </summary>
        //public Int32 Version
        //{
        //    get
        //    {
        //        return this.version;
        //    }
        //    set
        //    {
        //        if (this.version != value)
        //        {
        //            this.version = value;
        //        }
        //    }
        //}

        //private BinAff.Core.Table createdBy;
        ///// <summary>
        ///// Created by user
        ///// </summary>
        //public BinAff.Core.Table CreatedBy
        //{
        //    get
        //    {
        //        return this.createdBy;
        //    }
        //    set
        //    {
        //        if (value != null && this.createdBy != value)
        //        {
        //            this.createdBy = value;
        //        }
        //    }
        //}

        //private BinAff.Core.Table modifiedBy;
        ///// <summary>
        ///// Modified by User
        ///// </summary>
        //public BinAff.Core.Table ModifiedBy
        //{
        //    get
        //    {
        //        return this.modifiedBy;
        //    }
        //    set
        //    {
        //        if (value != null && this.modifiedBy != value)
        //        {
        //            this.modifiedBy = value;
        //        }
        //    }
        //}

        //private DateTime createdAt;
        ///// <summary>
        ///// Time when artifact created
        ///// </summary>
        //public DateTime CreatedAt
        //{
        //    get
        //    {
        //        return this.createdAt;
        //    }
        //    set
        //    {
        //        if (value != null && this.createdAt != value)
        //        {
        //            this.createdAt = value;
        //        }
        //    }
        //}

        //private DateTime? modifiedAt;
        ///// <summary>
        ///// Time when artifact last modified
        ///// </summary>
        //public DateTime? ModifiedAt
        //{
        //    get
        //    {
        //        return this.modifiedAt;
        //    }
        //    set
        //    {
        //        if (value != null && this.modifiedAt != value)
        //        {
        //            this.modifiedAt = value;
        //        }
        //    }
        //}

        private List<Dto> children;
        public List<Dto> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                if (value != null && this.children != value)
                {
                    this.children = value;
                }
            }
        }

        private FacLib.Dto module;
        /// <summary>
        /// Attached module data
        /// </summary>
        public FacLib.Dto Module
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

        private ModDefFac.Dto componentDef;
        /// <summary>
        /// Attached module data
        /// </summary>
        public ModDefFac.Dto ComponentDefinition
        {
            get
            {
                return this.componentDef;
            }
            set
            {
                if (value != null && this.componentDef != value)
                {
                    this.componentDef = value;
                }
            }
        }

        private FacLib.Dto parent;
        public FacLib.Dto Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                if (value != null && this.parent != value)
                {
                    this.parent = value;
                }
            }
        }

        public Audit.Dto AuditInfo { get; set; }

        public object Clone()
        {
            Dto artf = this.MemberwiseClone() as Dto;
            artf.AuditInfo.CreatedBy = this.AuditInfo.CreatedBy.Clone() as BinAff.Core.Table;
            artf.AuditInfo.ModifiedBy = this.AuditInfo.ModifiedBy.Clone() as BinAff.Core.Table;
            if (this.Children != null && this.Children.Count > 0)
            {
                artf.Children = new List<Dto>();
                foreach (Dto dto in this.Children)
                {
                    artf.Children.Add(dto.Clone() as Dto);
                }
            }
            artf.Module = this.Module.Clone() as FacLib.Dto;
            artf.ComponentDefinition = this.ComponentDefinition.Clone() as ModDefFac.Dto;
            artf.Parent = this.Parent.Clone() as FacLib.Dto;
            return artf;
        }

    }

}
