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
        
        protected Container()
            : base()
        {
            InitializeComponent();
            this.Text = "Forms";
        }

        protected Container(AccFac.Dto account)
            : base(account)
        {
            InitializeComponent();
            this.Text = "Forms";
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

        private void Container_Load(object sender, EventArgs e)
        {

        }

        private void Container_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Document).RefreshForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Document current = this.ActiveMdiChild as Document;
            current.SaveForm();
            if (current.IsModified && current.IsAttachmentSupported) // && String.Compare(this.AttachmentName, "Attach", true) != 0)
            {
                System.Windows.Forms.DialogResult confirmation = new MessageBox(this).Confirm(new Message("Do yo want to attach any document?", Message.Type.Question));
                if (confirmation == System.Windows.Forms.DialogResult.OK)
                {
                    this.btnAttach.Enabled = true;
                    return;
                }
            }
            if (current.IsModified) this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            (this.ActiveMdiChild as Document).DeleteForm();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Document attachment = (this.ActiveMdiChild as Document).AttachDocument();
            if (attachment.Artifact.Id != 0)
            {
                this.BindAttachmentList(attachment);
            }
        }

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
        }

        protected override void OnRightPanleClick()
        {
            this.spnlRightLink.Show();
        }

        private void Container_MdiChildActivate(object sender, EventArgs e)
        {
            Document child = this.ActiveMdiChild as Document;
            child.ButtonStatusChange += child_ButtonStatusChange;

            this.lblAttachmentHeading.Text = child.AttachmentName;
            this.spnlLeftLink.Options[0].Name = child.AncestorName;
            this.spnlLeftLink.Options[1].Name = child.NextName;


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
            if (document.IsAttachmentSupported)
            {
                this.dgvAttachmentList.Show();
            }
            else
            {
                this.dgvAttachmentList.Hide();
            }
            //Select attachment tab by default
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
                (this.facade as Facade.Container.Server).DeleteAttachment(document, (this.ActiveMdiChild as Document).facade as Facade.Document.Server);

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
            form.MdiParent = this;
            (this.ActiveMdiChild as Document).RaiseAttachmentArtifactLoaded(form);
            form.Show();
        }

    }

}