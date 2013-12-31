using System;
using System.Windows.Forms;

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
            return new Prerequisite();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

    }

}
