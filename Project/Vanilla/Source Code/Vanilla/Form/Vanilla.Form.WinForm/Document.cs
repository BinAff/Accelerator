using System;

using BinAff.Core;
using BinAff.Facade.Cache;
using PresLib = BinAff.Presentation.Library;

using AccFac = Vanilla.Guardian.Facade.Account;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using DocFac = Vanilla.Utility.Facade.Document;
using UtilWin = Vanilla.Utility.WinForm;

namespace Vanilla.Form.WinForm
{

    public partial class Document : UtilWin.Document
    {

        protected System.Drawing.Color MandatoryColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(255, 255, 240, 240);
            }
        }
        
        protected DocFac.Dto InitialDto { get; private set; }

        public delegate void OnArtifactSaved(ArtfFac.Dto document);
        public event OnArtifactSaved ArtifactSaved;

        public delegate void OnChildArtifactSaved(ArtfFac.Dto document);
        public event OnChildArtifactSaved ChildArtifactSaved;
        protected virtual void RaiseChildArtifactSaved(ArtfFac.Dto document)
        {
            OnChildArtifactSaved del = ChildArtifactSaved;
            if (del != null)
            {
                del(document);
            }
        }

        public Document()
            : base()
        {
            InitializeComponent();
        }

        public Document(ArtfFac.Dto artifact)
            :this()
        {
            base.formDto.Document = artifact;
        }

        private void Document_Shown(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (this.Artifact != null && this.Artifact.Id != 0)
            {
                this.SetTitle();
                this.formDto.Document = this.Artifact;
                if (this.Artifact.Module != null)
                {
                    this.formDto.Dto = this.Artifact.Module as DocFac.Dto;
                    this.InitialDto = this.CloneDto(this.formDto.Dto);
                }
                this.LoadForm();
                if (this.formDto.Dto != null)
                {
                    this.PopulateDataToForm();
                }
                if(this.ArtifactSaved != null) this.ArtifactSaved(this.formDto.Document);
            }
        }

        protected override Vanilla.Utility.WinForm.SaveDialog GetSaveDialogue()
        {
            return new SaveDialogue();
        }

        private void SetTitle()
        {
            DocFac.FormDto formDto = this.formDto as DocFac.FormDto;
            DocFac.Dto dto = this.formDto.Dto as DocFac.Dto;

            this.Text += " :: " + this.formDto.DocumentName;
        }

        protected void RegisterArtifactObserver()
        {
            (this.facade as Facade.Document.Server).RegisterArtifactObserver();
        }

        protected Boolean Save()
        {
            if (!this.ValidateForm()) return false;
            if (!this.SaveBefore()) return false;

            this.AssignDto();

            if (base.formDto.Dto.Id == 0)
            {
                base.formDto.Document.AuditInfo.CreatedBy = new Table
                {
                    Id = (Server.Current.Cache["User"] as AccFac.Dto).Id,
                    Name = (Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                };
                base.formDto.Document.AuditInfo.CreatedAt = DateTime.Now;
            }
            else
            {
                base.formDto.Document.AuditInfo.ModifiedBy = new Table
                {
                    Id = (Server.Current.Cache["User"] as AccFac.Dto).Id,
                    Name = (Server.Current.Cache["User"] as AccFac.Dto).Profile.Name
                };
                base.formDto.Document.AuditInfo.ModifiedAt = DateTime.Now;
            }
            this.RegisterArtifactObserver();
            if (base.formDto.Dto.Id == 0)
            {
                base.facade.Add();
            }
            else
            {
                base.facade.Change();
            }
            if (base.facade.IsError)
            {
                new PresLib.MessageBox
                {
                    DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                    Heading = "Forms",
                }.Show(base.facade.DisplayMessageList);
                return false;
            }

            return this.SaveAfter();
        }

        protected void RefreshFrom()
        {
            if (this.formDto.Dto.Id > 0)
            {
                this.RevertForm();
                this.AssignDto();
            }
            else
            {
                this.ClearForm();
            }
        }

        protected virtual void LoadForm()
        {
            throw new NotImplementedException();
        }

        protected virtual void PopulateDataToForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate data filled in form
        /// </summary>
        /// <returns></returns>
        protected virtual Boolean ValidateForm()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Clear all data on form
        /// </summary>
        protected virtual void ClearForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Revert form data to initial state when form loaded
        /// </summary>
        protected virtual void RevertForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assign Dto from data available in form
        /// </summary>
        protected virtual void AssignDto()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clone an existing Dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        protected virtual DocFac.Dto CloneDto(DocFac.Dto source)
        {
            throw new NotImplementedException();
        }

        protected virtual Boolean SaveBefore()
        {
            return true;
        }

        protected virtual Boolean SaveAfter()
        {
            return true;
        }

    }

}
