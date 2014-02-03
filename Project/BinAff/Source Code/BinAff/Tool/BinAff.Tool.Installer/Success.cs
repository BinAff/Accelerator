using System;

namespace BinAff.Tool.Installer
{

    public partial class Success : Wizard
    {

        public Success()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
