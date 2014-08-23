using System;
using System.Windows.Forms;
using System.Drawing;

using BinAff.Core;
using BinAff.Facade.Cache;
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

        protected String AncestorName
        {
            set
            {
                this.btnAddAncestor.ToolTipText += " " + value;
                this.btnPickAncestor.ToolTipText += " " + value;
            }
        }

        protected String AttachmentName
        {
            private get
            {
                return this.btnAttach.ToolTipText;
            }
            set
            {
                this.btnAttach.ToolTipText += " " + value;
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
            if (base.Artifact != null && base.Artifact.ComponentDefinition == null)
            {
                base.Artifact.ComponentDefinition = (BinAff.Facade.Cache.Server.Current.Cache["Main"] as CacheFac.Dto).ComponentDefinitionList.FindLast(
                    (p) => { return p.Code == base.facade.GetComponentCode(); });
            }
        }

        #region Events

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
                this.RaiseArtifactSaved(this.formDto.Document);

                if (String.Compare(this.AttachmentName, "Attach", true) != 0) //Attachment is there
                {
                    if (this.Artifact.Module != null && this.Artifact.Module.Id != 0)
                    {
                        this.btnAttach.Enabled = true;
                        this.btnExpandCollapse.Enabled = true;
                    }
                    (this.facade as Facade.Document.Server).RetrieveAttachmentList();
                    //formDto.AttachmentSummeryList = base.GetAttachmentList();
                    this.dgvAttachmentList.ReadOnly = true;
                    this.dgvAttachmentList.AutoGenerateColumns = false;
                    this.dgvAttachmentList.Columns[0].DataPropertyName = "Path";
                    this.dgvAttachmentList.Columns[1].DataPropertyName = "Action";

                    this.dgvAttachmentList.DataSource = this.formDto.AttachmentSummeryList;
                }
            }
        }
        //public delegate void AsyncProcessDelegate();
        //private delegate void SafeWinFormsThreadDelegate();
        //protected void RunAsyncOperation(AsyncProcessDelegate callback)
        //{
        //    System.Threading.WaitCallback d = delegate(object not_used)
        //    {
        //        try
        //        {
        //            callback.Invoke();

        //        }
        //        finally
        //        {
        //            this.Invoke(new SafeWinFormsThreadDelegate(EndAsyncIndication));
        //        }
        //    };

        //    BeginAsyncIndication();
        //    System.Threading.ThreadPool.QueueUserWorkItem(d);
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Ok();
            if (this.IsModified && String.Compare(this.AttachmentName, "Attach", true) != 0)
            {
                DialogResult answer = MessageBox.Show("Do yo want to attach any document?", "Question", MessageBoxButtons.YesNo);
                if (answer == System.Windows.Forms.DialogResult.Yes)
                {
                    this.btnAttach.Enabled = true;
                    return;
                }
            }
            this.Close();
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

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Document attachment = this.AttachDocument();
            this.RaiseArtifactSaved(this.formDto.Document);
            if (attachment.Artifact.Id != 0) 
            {
                //If existing component, save relationship with attachment
                if (this.Artifact.Id != 0)
                {
                    (this.facade as Facade.Document.Server).AddAttachmentLink(attachment.Artifact);
                }

                this.BindAttachmentList(attachment);
            }
        }

        private void btnExpandCollapseAttachment_Click(object sender, EventArgs e)
        {
            if (this.btnExpandCollapse.Text == "×")
            {
                this.pnlAttachment.Visible = true;
                this.pnlAttachment.BringToFront();
                this.pnlAttachment.Width = 415;
                this.pnlAttachment.Height = 160;
                if (this.Width < this.pnlAttachment.Width) this.pnlAttachment.Width = this.Width - 2;
                if (this.Height < this.pnlAttachment.Height) this.pnlAttachment.Height = this.Height - 2;
                this.pnlAttachment.Left = this.Width - this.pnlAttachment.Width - 12;
                this.pnlAttachment.Top = this.toolStrip.Bottom + 2;
                this.btnExpandCollapse.Text = "Ö";
                this.btnExpandCollapse.ToolTipText = "Hide Attachments";
            }
            else
            {
                this.pnlAttachment.Visible = false;
                this.btnExpandCollapse.Text = "×";
                this.btnExpandCollapse.ToolTipText = "Show Attachments";
            }
        }

        private void dgvAttachmentList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ArtfFac.Dto document = this.formDto.AttachmentSummeryList[e.RowIndex].Artifact;
            ModFac.Server server = new ModFac.Server(new ModFac.FormDto
            {
                Dto = new ModFac.Dto
                {
                    Code = document.ComponentDefinition.Code,
                },
                CurrentArtifact = new ArtfFac.FormDto
                {
                    Dto = document,
                },
            });
            document = server.ReadArtifact();

            Type type = Type.GetType(document.ComponentDefinition.ComponentFormType, true);
            FrmWin.Document form = (FrmWin.Document)Activator.CreateInstance(type, document);
            form.MdiParent = this.MdiParent;
            this.RaiseAttachmentArtifactLoaded(form);
            form.Show();
        }

        #endregion

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

        private void BindAttachmentList(Document attachment)
        {
            if (this.formDto.AttachmentSummeryList == null)
            {
                this.formDto.AttachmentSummeryList = new System.Collections.Generic.List<DocFac.AttachmentSummery>();
            }
            this.formDto.AttachmentSummeryList.Add(new DocFac.AttachmentSummery
            {
                Artifact = attachment.Artifact,
                Path = attachment.Artifact.FullPath,
                Action = "Delete",
            });
            this.dgvAttachmentList.DataSource = null;
            this.dgvAttachmentList.DataSource = this.formDto.AttachmentSummeryList;
            this.btnExpandCollapse.Enabled = true;
        }

        /// <summary>
        /// Add method when Ok buton is clicked
        /// </summary>
        protected virtual void Ok()
        {
            if (this.Save())
            {
                base.Artifact.Module = base.formDto.Dto;
                base.IsModified = true;
            }
        }
        
        private Boolean Save()
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

        protected void RegisterArtifactObserver()
        {
            (this.facade as Facade.Document.Server).RegisterArtifactObserver();
        }

        private Document AttachDocument()
        {
            Document attachment = this.GetAttachment();
            attachment.ArtifactSaved += attachment_ArtifactSaved;
            attachment.ShowDialog();

            return attachment;
        }

        private void attachment_ArtifactSaved(ArtfFac.Dto document)
        {
            this.RaiseChildArtifactSaved(document);
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
                this.PopulateDataToForm();
            }
            else
            {
                this.ClearForm();
            }
            this.RefreshFormAfter();
        }

        #region Mandatory Hooks
        
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


        #endregion

        #region Optional Hook

        protected virtual void RefreshFormBefore()
        {

        }

        protected virtual void RefreshFormAfter()
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

        protected virtual Boolean SaveBefore()
        {
            return true;
        }

        protected virtual Boolean SaveAfter()
        {
            return true;
        }

        protected virtual Document GetAttachment()
        {
            return new Document();
        }

        #endregion

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
            this.btnAddAncestor.Select();
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
            this.btnPickAncestor.Select();
        }

        protected void EnableAttachButton()
        {
            this.btnAttach.Enabled = true;
        }

        protected void DisableAttachButton()
        {
            this.btnAttach.Enabled = false;
        }

        protected void EnableShowAttachmentButton()
        {
            this.btnExpandCollapse.Enabled = true;
        }

        protected void DisableShowAttachmentButton()
        {
            this.btnExpandCollapse.Enabled = false;
        }

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

    }

}