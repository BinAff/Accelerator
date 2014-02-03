using System;
using System.Windows.Forms;

namespace BinAff.Tool.Installer
{

    public partial class Wizard : Form
    {

        public Wizard NextForm { get; set; }
        public Wizard LastForm { get; set; }
        public Creadential Credential { get; set; }

        public Wizard()
        {
            InitializeComponent();
            this.Credential = new Creadential();
        }

        protected void Next()
        {
            if (this.NextForm == null)
            {
                this.NextForm = this.AssignNextForm();
                this.NextForm.LastForm = this;
            }
            this.NextForm.Show();
            this.Hide();
        }

        protected virtual Wizard AssignNextForm()
        {
            throw new NotImplementedException();
        }

        protected void Back()
        {
            this.LastForm.Show();
            this.Hide();
        }

        private void Wizard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        protected String GenerateErrorMessage(String message, Exception ex)
        {
            return "Installation cannot be continued..." + Environment.NewLine + message + Environment.NewLine
                    + "Technical Details: " + Environment.NewLine + ex.Message + Environment.NewLine
                    + "Stack Trace:" + Environment.NewLine + ex.StackTrace;
        }

    }

}
