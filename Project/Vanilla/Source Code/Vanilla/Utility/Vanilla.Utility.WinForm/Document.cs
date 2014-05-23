using System;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class Document : Form
    {

        protected Facade.Document.FormDto formDto;
        protected Facade.Document.Server facade;

        public delegate void OnAuditInfoChanged(Document document);
        public event OnAuditInfoChanged AuditInfoChanged;

        public Facade.Artifact.Dto Artifact
        {
            get
            {
                if (this.formDto != null)
                {
                    return this.formDto.Document;
                }
                return null;
            }
        }

        public Facade.Artifact.Audit.Dto AuditInfo
        {
            get
            {
                if (this.formDto != null && this.formDto.Document != null)
                {
                    return this.formDto.Document.AuditInfo;
                }
                return null;
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

        public String ComponentCode
        {
            get
            {
                return this.formDto.Document.ComponentDefinition.Code;
            }
        }

        public Document()
        {
            InitializeComponent();
            this.Compose();
        }

        private void Document_Shown(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (this.Artifact == null || this.Artifact.Id == 0)
            {
                this.Visible = false;
                SaveDialog saveDialogue = this.GetSaveDialogue();
                if (saveDialogue != null)
                {
                    saveDialogue.ShowDialog(this);
                    BinAff.Facade.Library.Dto module = this.formDto.Document.Module;
                    this.formDto.Document = saveDialogue.Document;
                    this.formDto.Document.Module = module;
                }
                this.Visible = true;
            }
        }

        private void Document_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if(this.AuditInfoChanged != null) this.AuditInfoChanged(this);
        }

        protected virtual void Compose()
        {
            
        }

        protected virtual SaveDialog GetSaveDialogue()
        {
            return null;
        }

    }

}