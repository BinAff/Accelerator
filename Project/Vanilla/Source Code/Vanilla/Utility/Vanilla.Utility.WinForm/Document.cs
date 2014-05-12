using System;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class Document : Form
    {

        protected Facade.Document.FormDto formDto;
        protected Facade.Document.Server facade;

        public String Version
        {
            get
            {
                if (this.formDto != null && this.formDto.Document != null)
                {
                    return this.formDto.Document.Version.ToString();
                }
                return String.Empty;
            }
        }
        
        public String CreatedBy
        {
            get
            {
                if (this.formDto != null && this.formDto.Document != null && this.formDto.Document.CreatedBy != null)
                {
                    return this.formDto.Document.CreatedBy.Name;
                }
                return String.Empty;
            }
        }

        public String CreatedAt
        {
            get
            {
                if (this.formDto != null && this.formDto.Document != null)
                {
                    return this.formDto.Document.CreatedAt.ToString();
                }
                return String.Empty;
            }
        }

        public String ModifiedBy
        {
            get
            {
                if (this.formDto != null && this.formDto.Document != null && this.formDto.Document.ModifiedBy != null)
                {
                    return this.formDto.Document.ModifiedBy.Name;
                }
                return String.Empty;
            }
        }

        public String ModifiedAt
        {
            get
            {
                if (this.formDto != null && this.formDto.Document != null)
                {
                    return this.formDto.Document.ModifiedAt.ToString();
                }
                return String.Empty;
            }
        }

        public Boolean IsModified { get; protected set; }

        public String DocumentPath
        {
            get
            {
                return this.formDto.DocumentPath;
            }
        }

        public String ArtifactComponentTypeName
        {
            get
            {
                Facade.Module.Helper helper = new Facade.Module.Helper(new Facade.Module.Dto
                {
                    Code = this.formDto.Document.ComponentDefinition.Code,
                }, this.formDto.Document.Category);
                return helper.ArtifactComponentType + ", " + helper.ArtifactComponentAssembly;
            }
        }

        public Document()
        {
            InitializeComponent();
            this.Compose();
        }

        protected virtual void Compose()
        {
            
        }

    }

}
