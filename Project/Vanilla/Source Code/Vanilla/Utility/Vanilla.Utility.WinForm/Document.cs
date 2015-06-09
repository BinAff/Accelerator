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
        public Facade.Document.Server facade;

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

        public delegate void OnArtifactDeleted(ArtfFac.Dto document);
        public event OnArtifactDeleted ArtifactDeleted;
        protected virtual void RaiseArtifactDeleted(ArtfFac.Dto document)
        {
            OnArtifactDeleted currentEvent = this.ArtifactDeleted;
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
        public virtual void RaiseAttachmentArtifactLoaded(Document document)
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
                    try
                    {
                        saveDialogue.ShowDialog(this);
                        if (saveDialogue.IsActionDone)
                        {
                            this.Visible = true;
                            this.ShowLoading();
                            return;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
                this.Close(); //Save dialogue box didn't appear or closed
            }
            this.LoadData();
            this.LoadFormChildSealed();
        }

        private void Document_Shown(object sender, EventArgs e)
        {
            this.DisableFormControls();
        }

        private void ShowLoading()
        {
            Form loadingForm = new Vanilla.Utility.WinForm.Loading
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
            };
            this.pnlLoading.Dock = DockStyle.Fill;
            this.pnlLoading.BringToFront();
            this.pnlLoading.Controls.Add(loadingForm);
            loadingForm.Show();
            this.pnlLoading.Show();

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                this.LoadData();
            }))
            {
                IsBackground = true,
            };
            t.Start();
            Timer timerLoadHandler = new Timer
            {
                Interval = 1,
            };
            timerLoadHandler.Tick += delegate(object sender, EventArgs e)
            {
                if (!t.IsAlive)
                {
                    this.pnlLoading.Hide();
                    this.LoadFormChildSealed();
                    this.DisableFormControls();
                    timerLoadHandler.Stop();
                }
            };
            timerLoadHandler.Start();
        }

        /// <summary>
        /// Override this method for framework level page load. This should be sealed inside framework
        /// </summary>
        protected virtual void LoadFormChildSealed()
        {
            
        }
        
        protected virtual void DisableFormControls()
        {
        }

        protected void saveDialogue_FolderSaved(Facade.Artifact.Dto document)
        {
            this.ArtifactSaved(document);
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

        protected virtual void LoadData()
        {

        }

    }

}