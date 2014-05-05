//using System.Windows.Forms;

namespace Vanilla.Utility.WinForm
{

    public partial class Open : System.Windows.Forms.Form
    {
        
        public Vanilla.Utility.Facade.Artifact.Category Category { get; set; }

        public Open()
        {
            InitializeComponent();
        }

        private void Open_Load(object sender, System.EventArgs e)
        {
            this.ucRegister.Category = this.Category;
            this.ucRegister.Show();
            this.ucRegister.LoadForm();
            this.cboExtension.SelectedIndex = 1;
        }

    }

}
