using System;
using System.ComponentModel;
using System.Windows.Forms;

using BinAff.Tool.SecurityHandler;

namespace BinAff.Tool.Installer
{
    public partial class LicenseManager : Wizard
    {

        internal String ApplicationFolder { get; set; }

        public LicenseManager()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new Validator
            {
                Credential = this.Credential,
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtLicsFilePath.Text))
            {
                MessageBox.Show("Please choose license file.");
                this.btnBrowseLicsFile.Focus();
                return;
            }
            String[] FileNameTokens = this.dlgOpenLicenseFile.FileName.Split('\\');
            DatabaseCredential dbCred =  RegistryHandler.Read("Splash");
            BinAff.Tool.License.Facade.FingurePrintManager.Server server = new BinAff.Tool.License.Facade.FingurePrintManager.Server
            {
                SourceLicenseFolder = System.IO.Directory.GetParent(this.dlgOpenLicenseFile.FileName).FullName,
                ApplicationFolder = this.ApplicationFolder,
                LicenseFileName = FileNameTokens[FileNameTokens.Length - 1],
                InstanceName = dbCred.InstanceName,
                DatabaseName = dbCred.DatabaseName,
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

        private void btnBrowseLicsFile_Click(object sender, EventArgs e)
        {
            this.dlgOpenLicenseFile.Filter = "License files (*.lic)|*.lic|All files (*.*)|*.*";
            this.dlgOpenLicenseFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.dlgOpenLicenseFile.Multiselect = false;
            this.dlgOpenLicenseFile.ShowDialog();
        }

        private void dlgOpenLicenseFile_FileOk(object sender, CancelEventArgs e)
        {
            this.txtLicsFilePath.Text = this.dlgOpenLicenseFile.FileName;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.Back();
        }

        private void txtLicsFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
