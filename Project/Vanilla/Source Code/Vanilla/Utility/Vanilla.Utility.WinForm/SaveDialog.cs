using System;

namespace Vanilla.Utility.WinForm
{

    public partial class SaveDialog : Dialog
    {

        public SaveDialog()
            : base()
        {
            InitializeComponent();
        }

        protected override String SetActionName()
        {
            return "Save";
        }

        protected override void DoAction()
        {
            if (!this.ValidateData())
            {
                //Show message
            }
            //Save artifact in current location
            //this.Register.ShowDocument();
        }

        private Boolean ValidateData()
        {
            if(String.IsNullOrEmpty(base.DocumentName))
            {
                return false;
            }
            if (this.Register.IsExistsInFolder(base.DocumentName))
            {
                return false;
            }
            return true;
        }

        private void SaveDialog_Load(object sender, EventArgs e)
        {
            this.Register.DialogueMode = DialogueMode.Save;
        }

    }

}
