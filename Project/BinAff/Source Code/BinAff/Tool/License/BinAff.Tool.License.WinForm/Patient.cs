using System;
using System.Windows.Forms;

namespace BinAff.Tool.License
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            //this.txtAge.Text = DateTime.C (DateTime.Today - dtpDateOfBirth.Value)
        }

    }
}
