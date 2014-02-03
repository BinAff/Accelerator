using System;
using System.Windows.Forms;

namespace BinAff.Tool.Installer
{

    public partial class Validator : Wizard
    {

        public Validator()
            :base()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new Success();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

        private void Validator_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.ValidateInstallation())
            {
                this.btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("Validation failed. Please reinstall the application.");
            }
        }

        private Boolean ValidateInstallation()
        {
            return true;
        }

    }

}
