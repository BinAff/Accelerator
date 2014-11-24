using System;
using System.Windows.Forms;

using ModFac = Vanilla.Utility.Facade.Module;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using System.ComponentModel;

namespace Vanilla.Utility.WinForm
{

    public partial class Document : Form
    {

        private Boolean isNewDocument;

        protected Facade.Document.FormDto formDto;
        protected Facade.Document.Server facade;

        public delegate void OnAuditInfoChanged(ArtfFac.Dto artifact);
        public event OnAuditInfoChanged AuditInfoChanged;
        protected virtual void RaiseAuditInfoChanged(ArtfFac.Dto artifact)
        {
            OnAuditInfoChanged currentEvent = this.AuditInfoChanged;
            if (currentEvent != null)
            {
                currentEvent(artifact);
            }
        }

        public delegate void OnArtifactSaved(ArtfFac.Dto document);
        public event OnArtifactSaved ArtifactSaved;
        protected virtual void RaiseArtifactSaved(ArtfFac.Dto document)
        {
            OnArtifactSaved currentEvent = this.ArtifactSaved;
            if (currentEvent != null)
            {
                currentEvent(document);
            }
        }

        public delegate void OnChildArtifactSaved(ArtfFac.Dto document);
        public event OnChildArtifactSaved ChildArtifactSaved;
        protected virtual void RaiseChildArtifactSaved(ArtfFac.Dto document)
        {
            OnChildArtifactSaved currentEvent = this.ChildArtifactSaved;
            if (currentEvent != null)
            {
                currentEvent(document);
            }
        }

        public delegate void OnAttachmentArtifactLoaded(Document document);
        public event OnAttachmentArtifactLoaded AttachmentArtifactLoaded;
        protected virtual void RaiseAttachmentArtifactLoaded(Document document)
        {
            OnAttachmentArtifactLoaded currentEvent = this.AttachmentArtifactLoaded;
            if (currentEvent != null)
            {
                currentEvent(document);
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

        private void Document_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (this.Artifact == null || this.Artifact.Id == 0) this.isNewDocument = true;
            if (this.isNewDocument)
            {
                this.Visible = false;
                SaveDialog saveDialogue = this.GetSaveDialogue();
                saveDialogue.FolderSaved += saveDialogue_FolderSaved;

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
            this.ShowLoading();
        }

        private void ShowLoading()
        {
            Form loadingForm = new Vanilla.Utility.WinForm.Loading
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
            };
            this.pnlLoading.Controls.Add(loadingForm);
            loadingForm.Show();
            this.pnlLoading.Show();
            this.pnlLoading.BringToFront();

            this.timerLoadHandler.Start();
        }

        /// <summary>
        /// Override this method for framework level page load. This should be sealed inside framework
        /// </summary>
        protected virtual void LoadFormChildSealed()
        {
            
        }

        void saveDialogue_FolderSaved(Facade.Artifact.Dto document)
        {
            this.ArtifactSaved(document);
        }

        private void timerLoadHandler_Tick(object sender, EventArgs e)
        {
            //BackgroundWorker childLoader = new BackgroundWorker();
            //childLoader.RunWorkerCompleted += childLoader_RunWorkerCompleted;
            //childLoader.RunWorkerAsync();
            this.LoadFormChildSealed();
            this.pnlLoading.Hide();
            this.timerLoadHandler.Stop();
        }

        //void childLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    this.LoadFormChildSealed();
        //}

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
            if (this.AuditInfoChanged != null && this.IsModified) this.AuditInfoChanged(this.Artifact);
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