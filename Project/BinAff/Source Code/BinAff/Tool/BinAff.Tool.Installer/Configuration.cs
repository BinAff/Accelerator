using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;

using BinAff.SqlServerUtil;
using BinAff.Presentation.Library.Extension;
using BinAff.Tool.SecurityHandler;

namespace BinAff.Tool.Installer
{

    public partial class Configuration : Wizard
    {

        public Configuration()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            this.Credential.InstanceName = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name;
            this.Credential.DatabaseName = this.Credential.ProductName;
            if (this.optSQLServer.Checked)
            {
                this.Credential.UserName = this.txtUserName.Text.Trim();
                this.Credential.Password = this.txtPassword.Text.Trim();
            }

            return new Installation
            {
                Credential = this.Credential,
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtPath.Text))
            {
                MessageBox.Show("Application path is not defined.");
                return;
            }
            if (String.IsNullOrEmpty(this.txtLicsFilePath.Text))
            {
                MessageBox.Show("License file is not provided.");
                return;
            }
            if (!this.IsConected())
            {
                MessageBox.Show("Connection failed.");
            }
            else
            {
                base.Next();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.Back();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            this.folderBrowserDialog.ShowDialog(this);
            this.txtPath.Text = this.folderBrowserDialog.SelectedPath;
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
            this.btnNext.Enabled = this.IsConected();
            MessageBox.Show(this.btnNext.Enabled ? "Successfully connected." : "Connection failed.");
        }

        private Boolean IsConected()
        {
            if (this.cboSqlServerInstanceList.SelectedItem == null)
            {
                MessageBox.Show("Select server instance and database from list.");
                return false;
            }
            String instance = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name;
            return this.optWindows.Checked ?
                Handler.TestDbConnection(instance, "master") :
                Handler.TestDbConnection(instance, "master", this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim());
        }

        private void btnBrowseLicsFile_Click(object sender, EventArgs e)
        {
            this.dlgOpenLicenseFile.Filter = "License files (*.lic)|*.lic|All files (*.*)|*.*";
            this.dlgOpenLicenseFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.dlgOpenLicenseFile.Multiselect = false;
            this.dlgOpenLicenseFile.ShowDialog();
        }

        private void dlgOpenLicenseFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.txtLicsFilePath.Text = this.dlgOpenLicenseFile.FileName;
            //Read license file
            SecurityHandler.License lic = LicenseFileHandler.Read(this.dlgOpenLicenseFile.FileName);
            this.Credential.ProductName = lic.ProductName;
            this.Credential.CompanyName = ConfigurationManager.AppSettings["CompanyName"];
            this.Credential.licenseFilePath = this.txtLicsFilePath.Text;
            this.Credential.LicenseNumber = lic.LicenseNumber;
            this.Credential.LicensedModuleList = new List<string>();
            foreach (String module in lic.ModuleList)
            {
                this.Credential.LicensedModuleList.Add(module.Split(':')[1]);
            }
        }

    }

}
