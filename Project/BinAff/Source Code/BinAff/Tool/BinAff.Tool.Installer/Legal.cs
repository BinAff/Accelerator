using System;

namespace BinAff.Tool.Installer
{

    public partial class Legal : Wizard
    {

        public Legal()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new Prerequisite();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

        private void chkAccept_CheckedChanged(object sender, EventArgs e)
        {
            this.btnNext.Enabled = this.chkAccept.Checked;
        }

    }

}
