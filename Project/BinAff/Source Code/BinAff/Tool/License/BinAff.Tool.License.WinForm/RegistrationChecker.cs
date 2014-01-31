using System;
using System.IO;
using System.Windows.Forms;

using BinAff.Presentation.Library.Extension;
using BinAff.SqlServerUtil;

namespace BinAff.Tool.License
{

    public partial class RegistrationChecker : Form
    {

        public RegistrationChecker()
        {
            InitializeComponent();
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
            this.btnTestConnection.Enabled = true;
        }

        private void optLocal_CheckedChanged(object sender, EventArgs e)
        {
            this.cboSqlServerInstanceList.DisplayMember = "Name";
            this.cboSqlServerInstanceList.Bind<Handler.InstanceInfo>(new Facade.FingurePrintManager.Server().GetSqlServerInstances(true));
        }

        private void optRemote_CheckedChanged(object sender, EventArgs e)
        {
            this.cboSqlServerInstanceList.DisplayMember = "Name";
            this.cboSqlServerInstanceList.Bind<Handler.InstanceInfo>(new Facade.FingurePrintManager.Server().GetSqlServerInstances(false));
        }

        private void cboSqlServerInstanceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSqlServerInstanceList.SelectedItem != null)
            {
                this.lstDatabaseList.Bind<String>(new Facade.FingurePrintManager.Server
                {
                    InstanceName = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name,
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
                InstanceName = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name,
                DatabaseName = this.lstDatabaseList.SelectedItem.ToString(),
            }.TestDbConnection())
            {
                MessageBox.Show("Successfully connected.");
                this.btnTest.Enabled = true;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Int16 result = new Facade.RegistrationChecker.Server
            {
                ProductName = this.txtProductName.Text.Trim(),
                Folder = Directory.GetParent(this.dlgOpenApplicationFile.FileName).FullName,
                InstanceName = (this.cboSqlServerInstanceList.SelectedItem as Handler.InstanceInfo).Name,
                DatabaseName = this.lstDatabaseList.SelectedItem.ToString(),
            }.Authenticate();
            switch (result)
            {
                case 0:
                    MessageBox.Show("Machine is licensed for this software.");
                    break;
                case 1:
                    MessageBox.Show("License file tampered. Software cannot be used.");
                    break;
                case 2:
                    MessageBox.Show("Machine is not registered for this software. Software cannot be used.");
                    break;
                case 5:
                    MessageBox.Show("Database tampered. Software cannot be used.");
                    break;
                default:
                    MessageBox.Show("Machine is not licensed for this software.");
                    break;
            }
        }

    }

}
