using System;
using System.IO;
using System.Security.AccessControl;

using BinAff.SqlServerUtil;
using BinAff.Tool.SecurityHandler;
using BinAff.Presentation.Library.Extension;
using System.Windows.Forms;

namespace BinAff.Tool.Installer
{

    public partial class Installation : Wizard
    {

        public Installation()
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            base.Back();
        }

        private void Installation_Load(object sender, EventArgs e)
        {
            this.txtProductName.Text = this.Credential.ProductName;
            this.txtServerName.Text = this.Credential.InstanceName;
            this.txtDatabaseName.Text = this.Credential.DatabaseName;
            this.txtAppPath.Text = this.Credential.ApplicationFolder + "\\" + this.Credential.CompanyName + "\\" + this.Credential.ProductName;
            this.txtLicenseNumber.Text = this.Credential.LicenseNumber;
            this.lstModuleList.Bind<String>(this.Credential.LicensedModuleList);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            this.Install();
            this.btnNext.Enabled = true;
        }

        private void Install()
        {
            String curentMessage;
            if (!String.IsNullOrEmpty(curentMessage = this.CreateFolders()))
            {
                MessageBox.Show(curentMessage);
                return;
            }
            if (!String.IsNullOrEmpty(curentMessage = this.RunDatabaseScript()))
            {
                MessageBox.Show(curentMessage);
                return;
            }
            if (!String.IsNullOrEmpty(curentMessage = this.CopyApplicationFiles()))
            {
                MessageBox.Show(curentMessage);
                return;
            }
            if (!String.IsNullOrEmpty(curentMessage = this.AssignDatabaseCredential()))
            {
                MessageBox.Show(curentMessage);
                return;
            }
            if (!String.IsNullOrEmpty(curentMessage = this.RegisterMachine()))
            {
                MessageBox.Show(curentMessage);
                return;
            }
            this.lblStatus.Text = "Installation completed.";
        }

        private String CreateFolders()
        {
            this.lblStatus.Text = "Creating file system...";

            this.progressBar.Value = 0;
            try
            {
                if (!Directory.Exists(this.Credential.ApplicationFolder + "\\" + this.Credential.CompanyName))
                {
                    Directory.CreateDirectory(this.Credential.ApplicationFolder + "\\" + this.Credential.CompanyName);
                }
                if (!Directory.Exists(this.Credential.ApplicationPath))
                {
                    Directory.CreateDirectory(this.Credential.ApplicationPath);
                }
            }
            catch (Exception ex)
            {
                return base.GenerateErrorMessage("Application folder creation failed.", ex);
            }
            this.progressBar.Value = 2;

            try
            {
                if (!Directory.Exists(this.Credential.ApplicationPath + "\\Database"))
                {
                    Directory.CreateDirectory(this.Credential.ApplicationPath + "\\Database");
                }
                this.AddDirectorySecurity(this.Credential.ApplicationPath + "\\Database");
            }
            catch (Exception ex)
            {
                return base.GenerateErrorMessage("Database folder creation failed.", ex);
            }
            this.progressBar.Value = 4;

            try
            {
                if (!Directory.Exists(this.Credential.ApplicationPath + "\\Log"))
                {
                    Directory.CreateDirectory(this.Credential.ApplicationPath + "\\Log");
                }
            }
            catch (Exception ex)
            {
                return base.GenerateErrorMessage("Log folder creation failed.", ex);
            }
            this.progressBar.Value = 5;

            return String.Empty;
        }

        private void AddDirectorySecurity(String folderName)
        {
            String[] arr = this.Credential.InstanceName.Split('\\');
            String s =String.Empty;
            for (Int16 i = 0; i < arr.Length; i++)
            {
                s += arr[i];
                if (i < arr.Length - 1) s += "$";
            }
            String Account = "SQLServerMSSQLUser$" + s;

            DirectoryInfo dInfo = new DirectoryInfo(folderName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();//Get current permissions

            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account, FileSystemRights.FullControl, AccessControlType.Allow));

            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);
        }

        private String RunDatabaseScript()
        {
            String applicationPath = this.Credential.ApplicationFolder + "\\" + this.Credential.CompanyName + "\\" + this.Credential.ProductName;
            this.lblStatus.Text = "Configuring database...";
            this.progressBar.Value = 5;
            Boolean createStatus;
            createStatus = String.IsNullOrEmpty(this.Credential.UserName) ?
                Handler.CreateDatabase(this.Credential.InstanceName, this.Credential.DatabaseName, applicationPath + "\\Database") :
                Handler.CreateDatabase(this.Credential.InstanceName, this.Credential.DatabaseName, this.Credential.UserName, this.Credential.Password, applicationPath + "\\Database");
            if (!createStatus)
            {
                return "Database creation failed.";
            }
            this.progressBar.Value = 10;

            //Create Schema depending on license
            this.progressBar.Value = 20;
            //Create Tables depending on license
            this.progressBar.Value = 30;
            //Create Stored Procedures depending on license
            this.progressBar.Value = 40;
            return String.Empty;
        }

        private String CopyApplicationFiles()
        {
            this.lblStatus.Text = "Copying files...";
            this.progressBar.Value = 40;
            String[] fileList = Directory.GetFiles("Resources");
            for (Int16 i = 0; i < fileList.Length; i++)
            {
                String[] filePath = fileList[i].Split('\\');
                File.Copy(fileList[i], this.Credential.ApplicationPath + "\\" + filePath[filePath.Length - 1], true);
            }
            //
            this.progressBar.Value = 55;
            //
            this.progressBar.Value = 60;
            //
            this.progressBar.Value = 70;
            //
            this.progressBar.Value = 75;
            return String.Empty;
        }

        private String AssignDatabaseCredential()
        {
            this.lblStatus.Text = "Assigning database credential...";
            this.progressBar.Value = 75;
            DatabaseCredential dbCread = new DatabaseCredential
            {
                InstanceName = this.Credential.InstanceName,
                DatabaseName = this.Credential.DatabaseName,
            };
            if (!String.IsNullOrEmpty(this.Credential.UserName))
            {
                dbCread.UserName = this.Credential.UserName;
                dbCread.Password = this.Credential.Password;
            }
            RegistryHandler.Write(this.Credential.ProductName, dbCread);
            this.progressBar.Value = 80;
            ProductDatabaseHandler.CreateSecuritySchema(this.Credential.ProductName);
            this.progressBar.Value = 85;
            ProductDatabaseHandler.Write(dbCread, DateTime.Now);
            this.progressBar.Value = 90;
            return String.Empty;
        }

        private String RegisterMachine()
        {
            this.lblStatus.Text = "Registering machine...";
            this.progressBar.Value = 90;
            String[] FileNameTokens = this.Credential.licenseFilePath.Split('\\');
            DatabaseCredential dbCred = RegistryHandler.Read("Splash");
            this.progressBar.Value = 95;
            BinAff.Tool.License.Facade.FingurePrintManager.Server server = new BinAff.Tool.License.Facade.FingurePrintManager.Server
            {
                SourceLicenseFolder = System.IO.Directory.GetParent(this.Credential.licenseFilePath).FullName,
                ApplicationFolder = this.Credential.ApplicationFolder,
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
                            return String.Empty;
                        }
                    }
                    return "Machine registration failed.";
                case 100:
                    return "Machine registration failed. License file tampered.";
                case 500:
                    return "Machine registration failed. License schema creation failed.";
                case 501:
                    return "Machine registration failed. License table creation failed.";
                case 600:
                    return "Machine registration failed. Licensed module schema creation failed.";
                case 601:
                    return "Machine registration failed. Licensed module table creation failed.";
                default:
                    return "Machine registration failed. Unknown error.";
            }
            this.progressBar.Value = 100;
            return String.Empty;
        }

    }

}
