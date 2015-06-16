using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Facade.Cache;
using BinAff.Presentation.Library.Extension;
using PresLib = BinAff.Presentation.Library;

using AccFac = Vanilla.Guardian.Facade.Account;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using DocFac = Vanilla.Utility.Facade.Document;
using ModFac = Vanilla.Utility.Facade.Module;
using UtilWin = Vanilla.Utility.WinForm;
using FrmWin = Vanilla.Form.WinForm;
using CacheFac = Vanilla.Utility.Facade.Cache;

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

        public List<UtilWin.SidePanel.Option> SummaryList { get; set; }

        public String AttachmentName { get; set; }

        public UtilWin.Reference Reference { get; set; }

        public List<ArtfFac.Dto> AttachmentList
        {
            get
            {
                Vanilla.Form.Facade.Document.FormDto formDto = this.formDto as Vanilla.Form.Facade.Document.FormDto;
                if (this.formDto == null || formDto.Document == null) return null;
                return formDto.Document.AttachmentList;
            }
        }

        public Boolean IsAttachmentSupported
        {
            get
            {
                Vanilla.Form.Facade.Document.FormDto formDto = this.formDto as Vanilla.Form.Facade.Document.FormDto;
                if (this.formDto == null || formDto.Document == null) return false;
                return formDto.Document.IsAttachmentSupported;
            }
        }

        public delegate void OnButtonStatusChange(ButtonType type, ChangeProperty changeProperty, Boolean status);
        public event OnButtonStatusChange ButtonStatusChange;

        private Boolean isEnabledRefreshButton = true;
        public Boolean IsEnabledRefreshButton
        {
            get
            {
                return this.isEnabledRefreshButton;
            }
            protected set
            {
                this.isEnabledRefreshButton = value;
                if (this.ButtonStatusChange != null) this.ButtonStatusChange(ButtonType.Refresh, ChangeProperty.Enabled, value);
            }
        }

        private Boolean isEnabledSaveButton = true;
        public Boolean IsEnabledSaveButton
        {
            get
            {
                return this.isEnabledSaveButton;
            }
            protected set
            {
                this.isEnabledSaveButton = value;
                if (this.ButtonStatusChange != null) this.ButtonStatusChange(ButtonType.Save, ChangeProperty.Enabled, value);
            }
        }

        private Boolean isEnabledDeleteButton = true;
        public Boolean IsEnabledDeleteButton
        {
            get
            {
                return this.isEnabledDeleteButton;
            }
            protected set
            {
                this.isEnabledDeleteButton = value;
                if (this.ButtonStatusChange != null) this.ButtonStatusChange(ButtonType.Delete, ChangeProperty.Enabled, value);
            }
        }

        private Boolean isEnabledPickAncestorButton = true;
        public Boolean IsEnabledPickAncestorButton
        {
            get
            {
                return this.isEnabledPickAncestorButton;
            }
            protected set
            {
                this.isEnabledPickAncestorButton = value;
                if (this.ButtonStatusChange != null) this.ButtonStatusChange(ButtonType.PickAncestor, ChangeProperty.Enabled, value);
            }
        }

        private Boolean isEnabledAddAncestorButton = true;
        public Boolean IsEnabledAddAncestorButton
        {
            get
            {
                return this.isEnabledAddAncestorButton;
            }
            protected set
            {
                this.isEnabledAddAncestorButton = value;
                if (this.ButtonStatusChange != null) this.ButtonStatusChange(ButtonType.AddAncestor, ChangeProperty.Enabled, value);
            }
        }

        private Boolean isEnabledViewAncestorButton = true;
        public Boolean IsEnabledViewAncestorButton
        {
            get
            {
                return this.isEnabledViewAncestorButton;
            }
            protected set
            {
                this.isEnabledViewAncestorButton = value;
                if (this.ButtonStatusChange != null) this.ButtonStatusChange(ButtonType.ViewAncestor, ChangeProperty.Enabled, value);
            }
        }

        private Boolean isEnabledAttchment = true;
        public Boolean IsEnabledAttchment
        {
            get
            {
                return this.isEnabledAttchment;
            }
            set
            {
                this.isEnabledAttchment = value;
                if (this.ButtonStatusChange != null) this.ButtonStatusChange(ButtonType.Attach, ChangeProperty.Enabled, value);
            }
        }

        public Document()
            : base()
        {
            InitializeComponent();
        }

        public Document(ArtfFac.Dto artifact)
            : this()
        {
            base.formDto.Document = artifact;
            if (base.Artifact != null && base.Artifact.ComponentDefinition == null)
            {
                base.Artifact.ComponentDefinition = (BinAff.Facade.Cache.Server.Current.Cache["Main"] as CacheFac.Dto).ComponentDefinitionList.FindLast(
                    (p) => { return p.Code == base.facade.GetComponentCode(); });
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Enter:
                    this.SaveForm();
                    return true;
                case Keys.Control | Keys.Delete:
                    this.DeleteForm();
                    return true;
                case Keys.Control | Keys.F5:
                    this.RefreshForm();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Events

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SaveForm();
            if (this.IsModified) this.Close();
        }

        #endregion

        protected override sealed void LoadFormChildSealed()
        {
            if (this.Artifact != null && this.Artifact.Id != 0)
            {
                //this.SetTitle();
                this.formDto.Document = this.Artifact;
                if (this.Artifact.Module != null)
                {
                    this.formDto.Dto = this.Artifact.Module as DocFac.Dto;
                    this.InitialDto = this.formDto.Dto.Clone() as DocFac.Dto;
                }

                this.LoadForm();
                if (this.formDto.Dto != null)
                {
                    this.PopulateDataToForm();
                    this.SetDefault();
                }
                //if (this.formDto.Dto == null || this.formDto.Dto.Id == 0) this.btnDelete.Enabled = false;

                this.RaiseArtifactSaved(this.formDto.Document);

                if (this.formDto.Document.IsAttachmentSupported) //Attachment is there
                {
                    (this.facade as Facade.Document.Server).RetrieveAttachmentList();
                    if (this.facade.IsError) //Some problem to retrieve attachments
                    {
                        new BinAff.Presentation.Library.MessageBox
                        {
                            Heading = "Error",
                            DialogueType = PresLib.MessageBox.Type.Error
                        }.Show(this.facade.DisplayMessageList);
                        return;
                    }
                }                
            }
        }

        protected override UtilWin.SaveDialog GetSaveDialogue()
        {
            return new SaveDialogue();
        }

        private void SetTitle()
        {
            DocFac.FormDto formDto = this.formDto as DocFac.FormDto;
            DocFac.Dto dto = this.formDto.Dto as DocFac.Dto;

            this.Text += " :: " + this.formDto.DocumentName;
        }

        private Boolean Save()
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

        protected void RegisterArtifactObserver()
        {
            (this.facade as Facade.Document.Server).RegisterArtifactObserver();
        }

        public Document AttachDocument()
        {
            Document attachment = this.GetAttachment();
            attachment.ArtifactSaved += delegate(ArtfFac.Dto document)
            {
                this.RaiseChildArtifactSaved(document);
            };
            attachment.ShowDialog();

            this.RaiseArtifactSaved(this.formDto.Document);
            if (attachment.Artifact.Id != 0)
            {
                //If existing component, save relationship with attachment
                if (this.Artifact.Id != 0)
                {
                    (this.facade as Facade.Document.Server).AddAttachmentLink(attachment.Artifact);
                }
            }
            return attachment;
        }

        /// <summary>
        /// Add method to refresh the form
        /// </summary>
        public void RefreshForm()
        {
            this.RefreshFormBefore();
            if (this.formDto.Dto != null && this.formDto.Dto.Id > 0)
            {
                this.RevertForm();
                this.PopulateDataToForm();
            }
            else
            {
                this.ClearForm();
                this.SetDefault();
            }
            this.RefreshFormAfter();
        }
        /// <summary>
        /// Add method when Ok buton is clicked
        /// </summary>
        public void SaveForm()
        {
            if (this.Save())
            {
                base.Artifact.Module = base.formDto.Dto;
                base.IsModified = true;
            }
        }

        public void DeleteForm()
        {
            String Msg = String.Format("Do you want to delete {0}: {1}?", this.Artifact.Category.ToString(), this.Artifact.FullFileName);
            DialogResult dialogResult = MessageBox.Show(this, Msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.AssignDto();
                if (!this.DeleteBefore()) return;
                base.facade.Delete();
                if (base.facade.IsError)
                {
                    new PresLib.MessageBox
                    {
                        DialogueType = facade.IsError ? PresLib.MessageBox.Type.Error : PresLib.MessageBox.Type.Information,
                        Heading = "Forms",
                    }.Show(base.facade.DisplayMessageList);
                    return;
                }
                this.DeleteAfter();
                this.ArtifactDeleted += delegate(ArtfFac.Dto document)
                {
                    base.RaiseArtifactDeleted(document);
                };
                this.Close();
            }
        }

        /// <summary>
        /// Pick existing ancestor artifact
        /// </summary>
        public void PickAnsestor()
        {
            FrmWin.OpenDialog search = new FrmWin.OpenDialog
            {
                ModuleForFilter = (this.facade as Facade.Document.Server).GetAncestorComponentCode(),
                Mode = FrmWin.OpenDialog.ActionMode.Search,
            };
            search.FolderSaved += delegate(ArtfFac.Dto document)
            {
                base.saveDialogue_FolderSaved(document);
            };
            base.ArtifactSaved += delegate(ArtfFac.Dto document)
            {
                base.RaiseChildArtifactSaved(document);
            };
            search.ShowDialog(this);
            if (search.IsActionDone)
            {
                this.PopulateAnsestorData(search.Document.Module as Facade.Document.Dto);
            }
        }

        /// <summary>
        /// Add new ancestor artifact
        /// </summary>
        public void AddAnsestor()
        {
            Document form = this.GetAnsestorForm();
            form.ArtifactSaved += delegate(ArtfFac.Dto document)
            {
                base.RaiseChildArtifactSaved(document);
            };
            form.ShowDialog(this);
            if (form.Artifact != null && form.Artifact.Module != null)
            {
                this.PopulateAnsestorData(form.Artifact.Module as Facade.Document.Dto);
            }
        }

        /// <summary>
        /// View ancestor form in different window
        /// </summary>
        public void ViewAncestor()
        {
        }

        /// <summary>
        /// Revert form data to initial state when form loaded
        /// </summary>
        protected void RevertForm()
        {
            base.formDto.Dto = this.InitialDto;
            this.PopulateDataToForm();
        }

        #region Mandatory Hooks

        /// <summary>
        /// Get all data from facade and bind form related data to form
        /// </summary>
        protected virtual void LoadForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Bind form controls with data from facade
        /// </summary>
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
        /// Assign Dto from data available in form
        /// </summary>
        protected virtual void AssignDto()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Optional Hook

        protected virtual void RefreshFormBefore()
        {

        }

        protected virtual void RefreshFormAfter()
        {

        }

        protected virtual void SetDefault()
        {
            
        }

        protected virtual void PopulateAnsestorData(Facade.Document.Dto dto)
        {
            
        }

        protected virtual Document GetAnsestorForm()
        {
            return new Document();
        }

        protected virtual Boolean SaveBefore()
        {
            return true;
        }

        protected virtual Boolean SaveAfter()
        {
            return true;
        }

        protected virtual Boolean DeleteBefore()
        {
            return true;
        }

        protected virtual Boolean DeleteAfter()
        {
            return true;
        }

        protected virtual Document GetAttachment()
        {
            return new Document();
        }

        #endregion

        #region Visual Control

        protected void AddToolStripSeparator()
        {
            this.toolStrip.Items.Add(new ToolStripSeparator());
        }

        protected ToolStripButton AddToolStripButton(String name, String fontName, String toolStripText)
        {
            ToolStripButton toolStripButton = new ToolStripButton
            {
                Text = name,
                AutoSize = false,
                Size = new Size(28, 28),
                Font = new Font(fontName, (float)18.25, FontStyle.Regular, GraphicsUnit.Point),
                DisplayStyle = ToolStripItemDisplayStyle.Text,
                ToolTipText = toolStripText,
            };
            this.toolStrip.Items.Add(toolStripButton);
            return toolStripButton;
        }

        #endregion

        public enum ChangeProperty
        {
            Enabled,
            Visible,
        }

        public enum ButtonType
        {
            Delete,
            Save,
            Refresh,
            Attach,
            PickAncestor,
            AddAncestor,
            ViewAncestor,
        }

    }

}