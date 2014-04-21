using System.Windows.Forms;

namespace Vanilla.Report.WinForm
{

    public partial class Open : Form
    {

        public Open()
        {
            InitializeComponent();
        }

        private void Open_Load(object sender, System.EventArgs e)
        {
            this.ucRegister.Show();
            this.ucRegister.LoadForm();
        }

    }

}
