using System;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class Reference : UserControl
    {

        public String Heading
        {
            get
            {
                return this.lblText.Text;
            }
            set
            {
                this.lblText.Text = value;
            }
        }

        public String Message
        {
            get
            {
                return this.txtMessage.Text;
            }
            set
            {
                this.txtMessage.Text = value;
            }
        }

        private Int32 height;

        public Reference()
        {
            InitializeComponent();
            this.height = this.Height;
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            if (this.btnAct.Text == "+")
            {
                this.Height = this.pnlHeading.Height;
                this.btnAct.Text = "-";
                this.txtMessage.Hide();
            }
            else
            {
                this.Height = this.height;
                this.btnAct.Text = "+";
                this.txtMessage.Show();
            }
        }

    }

}