using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinAff.Tool.Installer
{

    public partial class ApplicationConfiguration : Wizard
    {

        public ApplicationConfiguration()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Binary Affairs\Splash";
            this.folderBrowserDialog.ShowDialog(this);
        }

    }

}
