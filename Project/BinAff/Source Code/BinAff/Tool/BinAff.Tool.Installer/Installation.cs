using System;
using System.Windows.Forms;

using BinAff.Tool.SecurityHandler;
using BinAff.Presentation.Library.Extension;
using BinAff.SqlServerUtil;

namespace BinAff.Tool.Installer
{

    public partial class DatabaseConfiguration : Form
    {

        public DatabaseConfiguration()
        {
            InitializeComponent();
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
            this.cboSqlServerInstanceList.Text = String.Empty;
            this.lstDatabaseList.Items.Clear();
            this.UseWaitCursor = false;
        }

        private void cboSqlServerInstanceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem != null)
            {
                this.lstDatabaseList.Bind<String>(Handler.GetSqlServerDatabaseNames(this.cboSqlServerInstanceList.SelectedItem.ToString()));
            }
        }

        private void optWindows_CheckedChanged(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = false;
            this.txtPassword.Enabled = false;
        }

        private void optSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = true;
            this.txtPassword.Enabled = true;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem == null || this.lstDatabaseList.SelectedItem == null)
            {
                MessageBox.Show("Select server instance and database from list.");
                return;
            }
            Boolean isConnected = this.optWindows.Checked ? 
                Handler.TestDbConnection(this.cboSqlServerInstanceList.SelectedItem.ToString(), this.lstDatabaseList.SelectedItem.ToString()) :
                Handler.TestDbConnection(this.cboSqlServerInstanceList.SelectedItem.ToString(), this.lstDatabaseList.SelectedItem.ToString(), this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim());
            if (isConnected)
            {
                MessageBox.Show("Successfully connected.");
                this.btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DatabaseCredential dbCread = new DatabaseCredential
            {
                InstanceName = this.cboSqlServerInstanceList.SelectedItem.ToString(),
                DatabaseName =  this.lstDatabaseList.SelectedItem.ToString(),
            };
            if (this.optSQLServer.Checked)
            {
                dbCread.UserName = this.txtUserName.Text.Trim();
                dbCread.Password = this.txtPassword.Text.Trim();
            }
            RegistryHandler.Write("Splash", dbCread);
            ProductDatabaseHandler.CreateSecuritySchema("Splash");
            ProductDatabaseHandler.Write(dbCread, DateTime.Now);
        }

    }

}
