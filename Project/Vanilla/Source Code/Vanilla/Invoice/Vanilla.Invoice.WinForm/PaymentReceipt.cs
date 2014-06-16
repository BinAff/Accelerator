
namespace Vanilla.Invoice.WinForm
{
    public partial class PaymentReceipt : System.Windows.Forms.Form
    {
        public PaymentReceipt()
        {
            InitializeComponent();
        }

        private void PaymentReceipt_Load(object sender, System.EventArgs e)
        {

            this.rvReceipt.RefreshReport();
        }
    }
}
