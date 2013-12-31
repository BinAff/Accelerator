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

    public partial class Prerequisite : Wizard
    {

        public Prerequisite()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new ApplicationConfiguration(); 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.Back();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

    }

}
