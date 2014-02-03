using System;
using System.Collections.Generic;

using BinAff.SqlServerUtil;
using BinAff.Tool.SecurityHandler;

namespace BinAff.Tool.License.Facade.FingurePrintManager
{

    public class Server
    {

        public String SourceLicenseFolder { get; set; }
        public String ApplicationFolder { get; set; }
        public String LicenseFileName { get; set; }
        public String InstanceName { get; set; }
        public String DatabaseName { get; set; }

        public List<Handler.InstanceInfo> GetSqlServerInstances(Boolean isLocal)
        {
            return Handler.GetSqlServerInstances(isLocal);
        }

        public List<String> GetSqlServerDatabases()
        {
            return Handler.GetSqlServerDatabaseNames(this.InstanceName);
        }

        public Boolean TestDbConnection()
        {
            return Handler.TestDbConnection(this.InstanceName, this.DatabaseName);
        }

        public Int16 Stamp(Boolean isForceOverwrite)
        {
            SecurityHandler.License lic = LicenseFileHandler.Read(this.SourceLicenseFolder + "\\" + this.LicenseFileName);
            if (lic == null) return 100; //License file tampered
            lic.FingurePrint = FingurePrintHandler.Generate(); //Assign fingure print
            lic.RegistrationDate = DateTime.Today;

            if (!isForceOverwrite && System.IO.File.Exists(this.ApplicationFolder + "\\" + this.LicenseFileName))
            {
                return 1; //Ask for overwrite
            }
            System.IO.File.Copy(this.SourceLicenseFolder + "\\" + this.LicenseFileName, this.ApplicationFolder + "\\" + this.LicenseFileName, isForceOverwrite);
            LicenseFileHandler.Append(lic.LicenseNumber, lic.RegistrationDate, this.ApplicationFolder + "\\" + this.LicenseFileName);

            //License file in System folder
            if (!isForceOverwrite && System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + this.LicenseFileName))
            {
                return 1; //Ask for overwrite
            }
            System.IO.File.Copy(this.SourceLicenseFolder + "\\" + this.LicenseFileName, Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + this.LicenseFileName, isForceOverwrite);
            LicenseFileHandler.Append(lic.LicenseNumber, lic.RegistrationDate, Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + this.LicenseFileName);

            RegistryHandler.Write(lic);

            return ProductDatabaseHandler.Write(lic, this.InstanceName,this.DatabaseName);
        }

    }

}
