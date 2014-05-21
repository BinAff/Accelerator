using System;

using BinAff.Core;
using PresLib = BinAff.Presentation.Library;

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
            if (String.IsNullOrEmpty(message))
            {
                new PresLib.MessageBox().Show(new Message
                {
                    Category = Message.Type.Error,
                    Description = message,
                });
            }
            this.Register.AddDocument();
            //Save artifact in current location
            //this.Register.ShowDocument();
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