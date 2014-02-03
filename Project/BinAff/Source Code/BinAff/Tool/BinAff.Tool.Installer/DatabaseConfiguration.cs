using System;
using System.Windows.Forms;

using BinAff.Tool.SecurityHandler;
using BinAff.Presentation.Library.Extension;
using BinAff.SqlServerUtil;

namespace BinAff.Tool.Installer
{

    public partial class DatabaseConfiguration : Wizard
    {

        public DatabaseConfiguration()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new Installation
            {
                Credential = this.Credential,
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //DatabaseCredential dbCread = new DatabaseCredential
            //{
            //    InstanceName = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name,
            //    DatabaseName =  this.lstDatabaseList.SelectedItem.ToString(),
            //};
            //if (this.optSQLServer.Checked)
            //{
            //    dbCread.UserName = this.txtUserName.Text.Trim();
            //    dbCread.Password = this.txtPassword.Text.Trim();
            //}
            //RegistryHandler.Write("Splash", dbCread);
            //ProductDatabaseHandler.CreateSecuritySchema("Splash");
            //ProductDatabaseHandler.Write(dbCread, DateTime.Now);
            base.Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.Back();
        }

        private void optLocal_CheckedChanged(object sender, EventArgs e)
        {
            this.cboSqlServerInstanceList.DisplayMember = "Name";
            this.cboSqlServerInstanceList.Bind<Handler.InstanceInfo>(Handler.GetSqlServerInstances(true));
        }

        private void optRemote_CheckedChanged(object sender, EventArgs e)
        {
            this.cboSqlServerInstanceList.DisplayMember = "Name";
            this.cboSqlServerInstanceList.Bind<Handler.InstanceInfo>(Handler.GetSqlServerInstances(false));
            this.cboSqlServerInstanceList.Text = String.Empty;
            this.lstDatabaseList.Items.Clear();
        }

        private void cboSqlServerInstanceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem != null)
            {
                this.lstDatabaseList.Bind<String>(Handler.GetSqlServerDatabaseNames((this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name));
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
            String instance = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name;

            Boolean isConnected = this.optWindows.Checked ?
                Handler.TestDbConnection(instance, this.lstDatabaseList.SelectedItem.ToString()) :
                Handler.TestDbConnection(instance, this.lstDatabaseList.SelectedItem.ToString(), this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim());
            if (isConnected)
            {
                MessageBox.Show("Successfully connected.");
                this.btnNext.Enabled = true;
            }
        }

    }

}
