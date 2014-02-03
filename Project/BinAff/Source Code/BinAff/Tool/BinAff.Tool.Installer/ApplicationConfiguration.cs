using System;
using System.IO;
using System.Windows.Forms;

using BinAff.SqlServerUtil;
using BinAff.Presentation.Library.Extension;

namespace BinAff.Tool.Installer
{

    public partial class ApplicationConfiguration : Wizard
    {

        public ApplicationConfiguration()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new DatabaseConfiguration
            {
                Credential = this.Credential,
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.Back();
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {   
            this.folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            this.folderBrowserDialog.ShowDialog(this);
            this.txtPath.Text = this.folderBrowserDialog.SelectedPath + String.Format("\\{0}\\{1}", this.Credential.CompanyName, this.Credential.ProductName);
            this.Credential.ApplicationFolder = this.folderBrowserDialog.SelectedPath;
            this.btnNext.Enabled = true;
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
            if (this.cboSqlServerInstanceList.SelectedItem == null)
            {
                MessageBox.Show("Select server instance and database from list.");
                return;
            }
            String instance = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name;

            Boolean isConnected = this.optWindows.Checked ?
                Handler.TestDbConnection(instance, "master") :
                Handler.TestDbConnection(instance, "master", this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim());
            if (isConnected)
            {
                MessageBox.Show("Successfully connected.");
                this.btnNext.Enabled = true;
            }
        }

    }

}
