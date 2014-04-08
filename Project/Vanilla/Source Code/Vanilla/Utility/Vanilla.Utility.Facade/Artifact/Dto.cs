﻿using System;
using System.Collections.Generic;

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

        private Int32 version;
        /// <summary>
        /// Version number
        /// </summary>
        public Int32 Version
        {
            get
            {
                return this.version;
            }
            set
            {
                if (this.version != value)
                {
                    this.version = value;
                }
            }
        }

        private BinAff.Core.Table createdBy;
        /// <summary>
        /// Created by user
        /// </summary>
        public BinAff.Core.Table CreatedBy
        {
            get
            {
                return this.createdBy;
            }
            set
            {
                if (value != null && this.createdBy != value)
                {
                    this.createdBy = value;
                }
            }
        }

        private BinAff.Core.Table modifiedBy;
        /// <summary>
        /// Modified by User
        /// </summary>
        public BinAff.Core.Table ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                if (value != null && this.modifiedBy != value)
                {
                    this.modifiedBy = value;
                }
            }
        }

        private DateTime createdAt;
        /// <summary>
        /// Time when artifact created
        /// </summary>
        public DateTime CreatedAt
        {
            get
            {
                return this.createdAt;
            }
            set
            {
                if (value != null && this.createdAt != value)
                {
                    this.createdAt = value;
                }
            }
        }

        private DateTime? modifiedAt;
        /// <summary>
        /// Time when artifact last modified
        /// </summary>
        public DateTime? ModifiedAt
        {
            get
            {
                return this.modifiedAt;
            }
            set
            {
                if (value != null && this.modifiedAt != value)
                {
                    this.modifiedAt = value;
                }
            }
        }

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

        private Vanilla.Utility.Facade.Module.Definition.Dto componentDef;
        /// <summary>
        /// Attached module data
        /// </summary>
        public Vanilla.Utility.Facade.Module.Definition.Dto ComponentDefinition
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

        private BinAff.Facade.Library.Dto parent;
        public BinAff.Facade.Library.Dto Parent
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
    }
}
