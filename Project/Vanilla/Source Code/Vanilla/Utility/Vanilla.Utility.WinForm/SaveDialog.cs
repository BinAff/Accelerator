using System;

using BinAff.Core;
using BinAff.Facade.Cache;
using PresLib = BinAff.Presentation.Library;

using Fac = Vanilla.Utility.Facade.SaveDialog;
using ArtfFac = Vanilla.Utility.Facade.Artifact;
using ModDefFac = Vanilla.Utility.Facade.Module.Definition;

namespace Vanilla.Utility.WinForm
{

    public partial class SaveDialog : Dialog
    {

        public SaveDialog()
            : base()
        {
            InitializeComponent();
        }

        private void SaveDialog_Load(object sender, EventArgs e)
        {
            this.Register.DialogueMode = DialogueMode.Save;
        }

        protected override String SetActionName()
        {
            return "Save";
        }

        protected override void DoAction()
        {
            String message = this.ValidateData();
            if (!String.IsNullOrEmpty(message))
            {
                new PresLib.MessageBox().Show(new Message
                {
                    Category = Message.Type.Error,
                    Description = message,
                });
            }
            Fac.FormDto formDto = new Fac.FormDto
            {
                Dto = new Fac.Dto
                {
                    DocumentName = base.DocumentName,
                    Parent = base.Register.CurrentArtifact,
                }
            };
            new Fac.Server(formDto).Add();
            this.Document = formDto.Document;
        }

        private String ValidateData()
        {
            if(String.IsNullOrEmpty(base.DocumentName))
            {
                return "Document name cannot be empty.";
            }
            if (this.Register.IsDocumentExistsInFolder(base.DocumentName))
            {
                return "Name already exists in current folder.";
            }
            return String.Empty; ;
        }

    }

}