using System;

namespace Vanilla.Invoice.WinForm
{

    public partial class AdvancePaymentReceipt : System.Windows.Forms.Form
    {

        public AdvancePaymentReceipt()
        {
            InitializeComponent();
        }

        private void AdvancePaymentReceipt_Load(object sender, EventArgs e)
        {

            this.rvReceipt.RefreshReport();
        }

    }

}
