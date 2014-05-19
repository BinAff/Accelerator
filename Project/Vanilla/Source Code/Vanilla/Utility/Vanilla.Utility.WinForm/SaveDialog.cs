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
            //Save artifact in current location
            //this.Register.ShowDocument();
        }

        private void SaveDialog_Load(object sender, EventArgs e)
        {
            this.Register.DialogueMode = DialogueMode.Save;
        }

    }

}
