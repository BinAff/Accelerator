using System;

using BinAff.SqlServerUtil;

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
            return new Configuration();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.Back();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(Handler.CheckSqlExpressInstance());
            //Test SQL Server is installed or not
            //Test dot net framework is installed or not
        }

    }

}
