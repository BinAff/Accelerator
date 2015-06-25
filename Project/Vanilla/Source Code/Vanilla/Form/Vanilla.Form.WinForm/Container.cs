using System;
using System.Collections.Generic;

using BinAff.Core;
using PresLib = BinAff.Presentation.Library;
using BinAff.Presentation.Library;

using AccFac = Vanilla.Guardian.Facade.Account;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ModFac = Vanilla.Utility.Facade.Module;

using UtilWin = Vanilla.Utility.WinForm;
using FrmWin = Vanilla.Form.WinForm;

namespace Vanilla.Form.WinForm
{

    public partial class Container : UtilWin.Container
    {

        private Int32 leftPanelWidth;
        private Int32 formPanellWidth;

        protected Container()
            : base()
        {
            InitializeComponent();
        }

        protected Container(AccFac.Dto account)
            : base(account)
        {
            InitializeComponent();
        }

        private static Container currentInstance;

        public static Container CreateInstance(AccFac.Dto account)
        {
            if (currentInstance == null || currentInstance.IsDisposed) currentInstance = new Container(account);
            return currentInstance;
        }

        public static Container CreateInstance()
        {
            if (currentInstance == null || currentInstance.IsDisposed) currentInstance = new Container();
            return currentInstance;
        }

        #region Events

        private void Container_Load(object sender, EventArgs e)
        {
            this.sCntMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReSize();
            this.leftPanelWidth = this.sCntData.Panel1.Width;
            this.formPanellWidth = this.sCntMain.Panel1.Width;
        }

        private void Container_SizeChanged(object sender, EventArgs e)
        {
            this.ReSize();
        }

        private void Container_Shown(object sender, EventArgs e)
        {

        }

        private void Container_MdiChildActivate(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            (this.documentCollection.Current as Document).RefreshForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            (this.documentCollection.Current as Document).SaveForm();
            if (this.documentCollection.Current.IsModified && (this.documentCollection.Current as Document).IsAttachmentSupported) // && String.Compare(this.AttachmentName, "Attach", true) != 0)
            {
                System.Windows.Forms.DialogResult confirmation = new MessageBox(this).Confirm(new Message("Do yo want to attach any document?", Message.Type.Question));
                if (confirmation == System.Windows.Forms.DialogResult.OK)
                {
                    this.btnAttach.Enabled = true;
                    return;
                }
            }
            if (this.documentCollection.Current.IsModified) this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            (this.documentCollection.Current as Document).DeleteForm();
            this.documentCollection.Remove(this.documentCollection.Current as Document);
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Document attachment = (this.documentCollection.Current as Document).AttachDocument();
            if (attachment.Artifact.Id != 0)
            {
                this.BindAttachmentList(attachment);
            }
        }

        private void btnOpenLink_Click(object sender, EventArgs e)
        {
            (this.documentCollection.Current as Document).PickAnsestor();
        }

        private void btnAddLink_Click(object sender, EventArgs e)
        {
            (this.documentCollection.Current as Document).AddAnsestor();
        }

        private void btnViewLink_Click(object sender, EventArgs e)
        {
            (this.documentCollection.Current as Document).ViewAncestor();
        }

        private void spnlLeftLink_ClosePanel(EventArgs e)
        {
            this.sCntData.SplitterDistance = 0;
            this.sCntData.IsSplitterFixed = true;
            this.sCntData.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        }

        private void spnlLeftLink_ShowPanel(EventArgs e)
        {
            this.OnLeftPanleClick();
            this.sCntData.IsSplitterFixed = false;
            this.sCntData.FixedPanel = System.Windows.Forms.FixedPanel.None;
        }

        private void spnlReference_ClosePanel(EventArgs e)
        {
            this.sCntMain.SplitterDistance = this.sCntMain.Width;
            this.sCntMain.IsSplitterFixed = true;
        }

        private void spnlReference_ShowPanel(EventArgs e)
        {
            this.OnRightPanleClick();
            this.sCntMain.IsSplitterFixed = false;
        }

        private void sCntData_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
        {
            if (this.sCntData.Panel1.Width > 25) //25 is the magic number when Panel1 is hidden
            {
                this.leftPanelWidth = this.sCntData.Panel1.Width;
            }
        }

        private void sCntMain_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
        {
            if (this.sCntMain.Panel2.Width > 25) //25 is the magic number when Panel1 is hidden
            {
                this.formPanellWidth = this.sCntMain.Panel1.Width;
            }
        }

        #endregion

        #region Framework

        protected override void Compose()
        {
            base.facade = new Facade.Container.Server(null);
            base.IsPathShown = true;
        }

        protected override UtilWin.Container CreateExecutableInstance(AccFac.Dto dto)
        {
            return Vanilla.Form.WinForm.Container.CreateInstance(dto);
        }

        protected override UtilWin.OpenDialog GetOpenDialogue()
        {
            return new OpenDialog
            {
                Text = "Open Form",
                Owner = this,
            };
        }

        protected override UtilWin.SaveDialog GetNewDialogue()
        {
            return new SaveDialogue
            {
                Text = "Save Form",
                Owner = this,
            };
        }

        protected override void OnLeftPanleClick()
        {
            this.spnlLeftLink.Show();
            this.sCntData.SplitterDistance = this.leftPanelWidth;
        }

        protected override void OnRightPanleClick()
        {
            this.sCntMain.Panel2.Show();
            this.spnlReference.Show();
            this.sCntMain.SplitterDistance = this.formPanellWidth;
        }

        protected override void AddDocumentAfter(UtilWin.Document document)
        {
            Document doc = document as Document;
            this.pnlDocument.Controls.Add(document);
            document.Dock = System.Windows.Forms.DockStyle.Fill;
            doc.IsVisibleCloseButton = false;
            doc.IsVisibleOkButton = false;

            this.pnlHeading.Controls.Add(document.Heading);
            document.BringToFront();
            doc.ButtonStatusChange += child_ButtonStatusChange;

            this.LoadSummary(document);
            this.LoadReference(document);
        }

        void child_ButtonStatusChange(Document.ButtonType type, Document.ChangeProperty changeProperty, Boolean status)
        {
            System.Windows.Forms.Button button;
            switch (type)
            {
                case Document.ButtonType.Delete:
                    button = this.btnDelete;
                    break;
                case Document.ButtonType.Refresh:
                    button = this.btnRefresh;
                    break;
                case Document.ButtonType.Save:
                    button = this.btnSave;
                    break;
                case Document.ButtonType.Attach:
                    button = this.btnAttach;
                    break;
                case Document.ButtonType.AddAncestor:
                    button = this.btnAddLink;
                    break;
                case Document.ButtonType.PickAncestor:
                    button = this.btnOpenLink;
                    break;
                case Document.ButtonType.ViewAncestor:
                    button = this.btnViewLink;
                    break;
                default:
                    button = this.btnDelete;
                    break;
            }
            switch (changeProperty)
            {
                case Document.ChangeProperty.Enabled:
                    button.Enabled = status;
                    break;
                case Document.ChangeProperty.Visible:
                    button.Visible = status;
                    break;
            }
        }

        #endregion

        protected override void LoadSummary(UtilWin.Document child)
        {
            Document c = child as Document;
            this.btnOpenLink.Enabled = c.IsEnabledPickAncestorButton;
            this.btnAddLink.Enabled = c.IsEnabledAddAncestorButton;
            this.btnViewLink.Enabled = c.IsEnabledViewAncestorButton;

            this.spnlLeftLink.Options = c.SummaryList;
            this.spnlLeftLink.ShowOption(0);
        }

        protected override void LoadReference(UtilWin.Document child)
        {
            if (child.formDto != null && child.formDto.Dto != null)
            {
                this.ucReference.Message = (child.formDto.Dto as Facade.Document.Dto).Remarks;
                this.spnlReference.Options = new List<UtilWin.SidePanel.Option>
                {
                    new Vanilla.Utility.WinForm.SidePanel.Option
                    {
                        Name = "Attachments",
                        Content = this.pnlAttachment,
                        IsFlipped = true,
                    },
                    new Vanilla.Utility.WinForm.SidePanel.Option
                    {
                        Name = "Remarks",
                        Content = this.ucReference,
                        IsFlipped = true,
                    },
                };
                this.spnlReference.ShowOption(0);
                this.HandleAttachment(child as Document);
            }
        }

        #region Attachment

        private void HandleAttachment(Document child)
        {
            this.lblAttachmentHeading.Text = child.AttachmentName;

            this.dgvAttachmentList.AutoGenerateColumns = false;
            this.formDto = new Facade.Container.FormDto
            {
                DocumentFormDto = new Facade.Document.FormDto
                {
                    Document = new ArtfFac.Dto
                    {
                        IsAttachmentSupported = child.IsAttachmentSupported,
                        AttachmentList = child.AttachmentList,
                    }
                }
            };

            this.dgvAttachmentList.Rows.Clear();
            ArtfFac.Dto document = (this.formDto as Facade.Container.FormDto).DocumentFormDto.Document;
            if (document.AttachmentList != null)
            {
                foreach (ArtfFac.Dto attachment in document.AttachmentList)
                {
                    this.dgvAttachmentList.Rows.Add(attachment.FullPath, "Delete");
                }
            }
            this.btnAttach.Enabled = child.IsEnabledAttchment;
            if (document.IsAttachmentSupported)
            {
                this.dgvAttachmentList.Show();
            }
            else
            {
                this.dgvAttachmentList.Hide();
            }
        }

        private void BindAttachmentList(Document attachment)
        {
            ArtfFac.Dto artifact = (this.formDto as Facade.Container.FormDto).DocumentFormDto.Document;
            if (artifact.AttachmentList == null)
            {
                artifact.AttachmentList = new List<ArtfFac.Dto>();
            }
            artifact.AttachmentList.Add(attachment.Artifact);
            this.dgvAttachmentList.Rows.Add(attachment.Artifact.Path, "Delete");
        }

        private void dgvAttachmentList_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (e.ColumnIndex == 1)
            {
                //Delete Attachment
                ArtfFac.Dto document = (this.formDto as Facade.Container.FormDto).DocumentFormDto.Document.AttachmentList[e.RowIndex];

                //Not correct way
                (this.facade as Facade.Container.Server).DeleteAttachment(document, this.documentCollection.Current.facade as Facade.Document.Server);

                if (this.facade.IsError) //Some problem to delete attachment
                {
                    new BinAff.Presentation.Library.MessageBox
                    {
                        Heading = "Error",
                        DialogueType = PresLib.MessageBox.Type.Error
                    }.Show(this.facade.DisplayMessageList);
                    return;
                }

                this.dgvAttachmentList.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dgvAttachmentList_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //If clicking outside any row
            ArtfFac.Dto document = (this.formDto as Facade.Container.FormDto).DocumentFormDto.Document.AttachmentList[e.RowIndex];
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
            this.documentCollection.Current.RaiseAttachmentArtifactLoaded(form);
            form.Show();
        }

        #endregion

        private void ReSize()
        {
            this.sCntMain.Width = this.Width;
            this.sCntMain.SplitterDistance = (Int32)Math.Floor(this.Width * 0.8);
            this.sCntData.SplitterDistance = (Int32)Math.Floor(this.Width * 0.4);
        }

    }

}