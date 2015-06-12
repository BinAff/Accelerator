using System;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class DocumentHeading : UserControl
    {

        public String Heading
        {
            get
            {
                return this.lblHeading.Text;
            }
            set
            {
                this.lblHeading.Text = value;
            }
        }

        public String ToolTip
        {
            set
            {
                this.toolTip.SetToolTip(this, value);
                this.toolTip.SetToolTip(this.lblHeading, value);
            }
        }

        public delegate void OnClose(object sender, EventArgs e);
        public event OnClose Close;

        public DocumentHeading()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Close != null) this.Close(sender, e);
        }

        private void lblHeading_TextChanged(object sender, EventArgs e)
        {
            //this.Width = this.lblHeading.Width + 23;
        }

        private void lblHeading_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

    }

}
