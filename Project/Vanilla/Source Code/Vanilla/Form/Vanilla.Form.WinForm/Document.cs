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

        protected String AncestorName
        {
            set
            {
                this.toolTip.SetToolTip(this.btnAddAncestor, this.toolTip.GetToolTip(this.btnAddAncestor) + " " + value);
                this.toolTip.SetToolTip(this.btnPickAncestor, this.toolTip.GetToolTip(this.btnPickAncestor) + " " + value);
            }
        }
        
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
            this.btnExpandCollapse.BringToFront();
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Ok();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshForm();
        }

        private void btnPickAncestor_Click(object sender, EventArgs e)
        {
            this.PickAnsestor();
        }

        private void btnAddAncestor_Click(object sender, EventArgs e)
        {
            this.AddAnsestor();
        }

        private void btnExpandCollapse_Click(object sender, EventArgs e)
        {
            if (this.btnExpandCollapse.Text == "×")
            {
                this.pnlAttachment.Visible = true;
                this.pnlAttachment.BringToFront();
                this.pnlAttachment.Left = this.pnlRight.Right - this.pnlAttachment.Size.Width;
                this.btnExpandCollapse.Text = "Ö";
            }
            else
            {
                this.pnlAttachment.Visible = false;
                this.btnExpandCollapse.Text = "×";
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
            //this.PopulateDataToForm();

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

        /// <summary>
        /// Add method to refresh the form
        /// </summary>
        protected void RefreshForm()
        {
            this.RefreshFormBefore();
            if (this.formDto.Dto != null && this.formDto.Dto.Id > 0)
            {
                this.RevertForm();
                //this.AssignDto();
                this.PopulateDataToForm();
            }
            else
            {
                this.ClearForm();
            }
            this.RefreshFormAfter();
        }

        protected virtual void RefreshFormBefore()
        {
            
        }

        protected virtual void RefreshFormAfter()
        {
            
        }

        /// <summary>
        /// Add method when Ok buton is clicked
        /// </summary>
        protected virtual void Ok()
        {

        }

        /// <summary>
        /// Add method to pick existing ancestor artifact
        /// </summary>
        protected virtual void PickAnsestor()
        {
            
        }

        /// <summary>
        /// Add method to add new ancestor artifact
        /// </summary>
        protected virtual void AddAnsestor()
        {
            
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

        #region Visual Control

        protected void EnableRefreshButton()
        {
            this.btnRefresh.Enabled = true;
        }

        protected void DisableRefreshButton()
        {
            this.btnRefresh.Enabled = false;
        }

        protected void EnableOkButton()
        {
            this.btnOk.Enabled = true;
        }

        protected void DisableOkButton()
        {
            this.btnOk.Enabled = false;
        }

        protected void EnableAddAncestorButton()
        {
            this.btnAddAncestor.Enabled = true;
        }

        protected void DisableAddAncestorButton()
        {
            this.btnAddAncestor.Enabled = false;
        }

        protected void FocusAddAncestor()
        {
            this.btnAddAncestor.Focus();
        }

        protected void EnablePickAncestorButton()
        {
            this.btnPickAncestor.Enabled = true;
        }

        protected void DisablePickAncestorButton()
        {
            this.btnPickAncestor.Enabled = false;
        }

        protected void FocusPickAncestor()
        {
            this.btnPickAncestor.Focus();
        }

        #endregion

    }

}
