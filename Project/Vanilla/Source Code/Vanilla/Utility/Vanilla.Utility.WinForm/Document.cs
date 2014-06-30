using System;
using System.Windows.Forms;

using ModFac = Vanilla.Utility.Facade.Module;

namespace Vanilla.Utility.WinForm
{

    public partial class Document : Form
    {

        private Boolean isNewDocument;

        protected Facade.Document.FormDto formDto;
        protected Facade.Document.Server facade;

        public delegate void OnAuditInfoChanged(Document document);
        public event OnAuditInfoChanged AuditInfoChanged;
        protected virtual void RaiseAuditInfoChanged(Document document)
        {
            OnAuditInfoChanged del = AuditInfoChanged;
            if (del != null)
            {
                del(document);
            }
        }

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
                if (this.formDto.Document.ComponentDefinition != null)
                {
                    return this.formDto.Document.ComponentDefinition.Code;
                }
                return null;
            }
        }

        public Document()
        {
            InitializeComponent();
            if (DesignMode) return;
            this.Compose();
        }

        private void Document_Shown(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (this.Artifact == null || this.Artifact.Id == 0)
            {
                this.isNewDocument = true;
            }
            if (this.isNewDocument)
            {
                this.Visible = false;
                SaveDialog saveDialogue = this.GetSaveDialogue();
                if (saveDialogue != null)
                {
                    saveDialogue.Document = this.formDto.Document;
                    saveDialogue.ModuleForFilter = this.Artifact.ComponentDefinition;
                    saveDialogue.ShowDialog(this);
                    if (saveDialogue.IsActionDone)
                    {
                        this.Visible = true;
                        return;
                    }
                }
                this.Close(); //Save dialogue box didn't appear or closed
            }
        }

        private void Document_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isNewDocument && this.IsModified)
            {
                ////this.Visible = false;
                //SaveDialog saveDialogue = this.GetSaveDialogue();
                //if (saveDialogue != null)
                //{
                //    saveDialogue.Document = this.formDto.Document;
                //    saveDialogue.ShowDialog(this);
                //}
                ////this.Visible = true;
            }
        }

        private void Document_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {            
            if (this.AuditInfoChanged != null && this.IsModified) this.AuditInfoChanged(this);
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