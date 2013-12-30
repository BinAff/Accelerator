using System;
using System.Windows.Forms;

using BinAff.Tool.SecurityHandler;
using BinAff.Presentation.Library.Extension;
using BinAff.SqlServerUtil;

namespace BinAff.Tool.Installer
{

    public partial class Installation : Form
    {

        public Installation()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RegistryHandler.Write("Splash", new DatabaseCredential());
        }

        private void optLocal_CheckedChanged(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.cboSqlServerInstanceList.Bind<String>(Handler.GetSqlServerInstances(true));
            this.UseWaitCursor = false;
        }

        private void optRemote_CheckedChanged(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.cboSqlServerInstanceList.Bind<String>(Handler.GetSqlServerInstances(false));
            this.UseWaitCursor = false;
        }

        private void cboSqlServerInstanceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem != null)
            {
                this.lstDatabaseList.Bind<String>(Handler.GetSqlServerDatabaseNames(this.cboSqlServerInstanceList.SelectedItem.ToString()));
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem == null || this.lstDatabaseList.SelectedItem == null)
            {
                MessageBox.Show("Select server instance and database from list.");
                return;
            }
            if (Handler.TestDbConnection(this.cboSqlServerInstanceList.SelectedItem.ToString(), this.lstDatabaseList.SelectedItem.ToString()))
            {
                MessageBox.Show("Successfully connected.");
                this.btnLicenseMachine.Enabled = true;
            }
        }

    }

}
