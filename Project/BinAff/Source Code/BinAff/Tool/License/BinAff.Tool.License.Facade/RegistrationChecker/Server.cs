using BinAff.SqlServerUtil;
using BinAff.Tool.SecurityHandler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace BinAff.Tool.License.Facade.RegistrationChecker
{

    public class Server
    {

        /// <summary>
        /// Installation folder of the application
        /// </summary>
        public String Folder { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public String ProductName { get; set; }

        /// <summary>
        /// SQL server instance name
        /// </summary>
        public String InstanceName { get; set; }

        /// <summary>
        /// Database name where application is installed
        /// </summary>
        public String DatabaseName { get; set; }

        public Int16 Authenticate()
        {
            SecurityHandler.License appLic = LicenseFileHandler.Read(this.Folder + "\\" + this.ProductName + ".lic"); //Find license file from application folder
            if (appLic == null) return 1; //License file tampered
            SecurityHandler.License license = appLic;

            SecurityHandler.License sysLic = LicenseFileHandler.Read(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + this.ProductName + ".lic"); //Find license file from system folder
            if (sysLic == null) return 1; //License file tampered

            if (license.CompareAll(sysLic) > 0) return 1; //License file tampered. The error is not shown; it can be used for internal purpose.

            SecurityHandler.License regLic = RegistryHandler.Read(appLic.LicenseNumber, this.ProductName); //Find license information from registry
            if (String.Compare(FingurePrintHandler.Generate(), regLic.FingurePrint) != 0) return 2; //Invalid machine
            if (license.CompareWithoutModule(regLic) > 0) return 1;

            //Find information from product database
            return (Int16)((license.CompareAll(this.ValidateWithProductDatabase(license)) > 0)? 5 : 0);
        }

        private SecurityHandler.License ValidateWithProductDatabase(SecurityHandler.License license)
        {

            SecurityHandler.License lics;
            System.Data.SqlClient.SqlConnection conn = Handler.GetConnectionObject(this.InstanceName, this.DatabaseName);
            conn.Open();
            System.Data.SqlClient.SqlTransaction trans = conn.BeginTransaction();

            System.Data.DataRow stamp = Handler.ReadRow(trans, "BinAff", "Stamp");

            Utility.Cryptography.ManagedAes decryptor = new Utility.Cryptography.ManagedAes
            {
                EncryptionKey = license.LicenseNumber,
            };

            lics = new SecurityHandler.License
            {
                LicenseNumber = license.LicenseNumber,
                FingurePrint = decryptor.Decrypt(stamp["FingurePrint"].ToString()),
                LicenseDate = Convert.ToDateTime(decryptor.Decrypt(stamp["FingurePrint"].ToString())),
                RegistrationDate = Convert.ToDateTime(decryptor.Decrypt(stamp["RegistrationDate"].ToString())),
            };

            System.Data.DataTable dt = Handler.Read(trans, "License", "Module");
            lics.ModuleList = new List<String>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                lics.ModuleList.Add(dr["Code"].ToString());
                //if (license.ModuleList.Find((p) => 
                //{
                //    return p.Split(':')[0] == dr["Code"].ToString(); 
                //}).Length == 0) return 10;
            }
            trans.Commit();
            conn.Close();
            return lics;
        }
        
    }

}
