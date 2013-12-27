using System;
using System.Windows.Forms;
using System.Collections.Generic;

using BinAff.Presentation.Library.Extension;

namespace BinAff.Tool.License
{
    
    internal partial class FingurePrintManager : Form
    {

        internal FingurePrintManager()
        {
            InitializeComponent();
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
        }

        private void btnBrowseAppFolder_Click(object sender, EventArgs e)
        {
            this.dlgOpenApplicationFile.Filter = "Application (*.exe)|*.exe|All files (*.*)|*.*";
            this.dlgOpenApplicationFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            this.dlgOpenApplicationFile.Multiselect = false;
            this.dlgOpenApplicationFile.ShowDialog();
        }

        private void dlgOpenApplicationFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.txtAppFolderPath.Text = this.dlgOpenApplicationFile.FileName;
        }

        private void optLocal_CheckedChanged(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.cboSqlServerInstanceList.Bind<String>(new Facade.FingurePrintManager.Server().GetSqlServerInstances(true));
            this.UseWaitCursor = false;
        }

        private void optRemote_CheckedChanged(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.cboSqlServerInstanceList.Bind<String>(new Facade.FingurePrintManager.Server().GetSqlServerInstances(false));
            this.UseWaitCursor = false;
        }

        private void cboSqlServerInstanceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem != null)
            {
                this.lstDatabaseList.Bind<String>(new Facade.FingurePrintManager.Server
                {
                    InstanceName = this.cboSqlServerInstanceList.SelectedItem.ToString(),
                }.GetSqlServerDatabases());
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem == null || this.lstDatabaseList.SelectedItem == null)
            {
                MessageBox.Show("Select server instance and database from list.");
                return;
            }
            if (new Facade.FingurePrintManager.Server
            {
                InstanceName = this.cboSqlServerInstanceList.SelectedItem.ToString(),
                DatabaseName = this.lstDatabaseList.SelectedItem.ToString(),
            }.TestDbConnection())
            {
                MessageBox.Show("Successfully connected.");
                this.btnLicenseMachine.Enabled = true;
            }
        }

        private void btnLicenseMachine_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtLicsFilePath.Text))
            {
                MessageBox.Show("Please choose license file.");
                this.btnBrowseLicsFile.Focus();
                return;
            }
            if (String.IsNullOrEmpty(this.txtAppFolderPath.Text))
            {
                MessageBox.Show("Please choose application.");
                this.btnBrowseAppFolder.Focus();
                return;
            }
            String[] FileNameTokens = this.dlgOpenLicenseFile.FileName.Split('\\');
            Facade.FingurePrintManager.Server server = new Facade.FingurePrintManager.Server
            {
                SourceLicenseFolder = System.IO.Directory.GetParent(this.dlgOpenLicenseFile.FileName).FullName,
                ApplicationFolder = System.IO.Directory.GetParent(this.dlgOpenApplicationFile.FileName).FullName,
                LicenseFileName = FileNameTokens[FileNameTokens.Length - 1],
                InstanceName = this.cboSqlServerInstanceList.SelectedItem.ToString(),
                DatabaseName = this.lstDatabaseList.SelectedItem.ToString(),
            };
            Int16 ret = server.Stamp(false);
            switch (ret)
            {
                case 0:
                    MessageBox.Show("Machine registration successful.");
                    break;
                case 1:
                    DialogResult result = MessageBox.Show("Machine is already registered. Do you want to overwrite?", "", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (server.Stamp(true) == 0)
                        {
                            MessageBox.Show("Machine registration successful.");
                            return;
                        }
                    }
                    MessageBox.Show("Machine registration failed.");
                    break;
                case 100:
                    MessageBox.Show("Machine registration failed. License file tampered.");
                    break;
                case 500:
                    MessageBox.Show("Machine registration failed. License schema creation failed.");
                    break;
                case 501:
                    MessageBox.Show("Machine registration failed. License table creation failed.");
                    break;
                case 600:
                    MessageBox.Show("Machine registration failed. Licensed module schema creation failed.");
                    break;
                case 601:
                    MessageBox.Show("Machine registration failed. Licensed module table creation failed.");
                    break;
                default:
                    MessageBox.Show("Machine registration failed. Unknown error.");
                    break;
            }
        }

    }

}
