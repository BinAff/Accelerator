using System;
using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class Loading : Form
    {

        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            this.MoveToCenter();
        }

        private void Loading_Resize(object sender, EventArgs e)
        {
            this.MoveToCenter();
        }        

        private void MoveToCenter()
        {
            this.picLoading.Top = this.Height / 2 - this.picLoading.Height / 2;
            this.picLoading.Left = this.Width / 2 - this.picLoading.Width / 2;
        }

    }

}
