using System;
using System.Configuration;

namespace BinAff.Tool.Installer
{

    public partial class Welcome : Wizard
    {

        public Welcome()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new Prerequisite
            {
                Credential = this.Credential,
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

    }

}
