using BinAff.SqlServerUtil;
using BinAff.Tool.SecurityHandler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace BinAff.Tool.License.Facade.FingurePrintManager
{

    public class Server
    {

        public String SourceLicenseFolder { get; set; }
        public String ApplicationFolder { get; set; }
        public String LicenseFileName { get; set; }
        public String InstanceName { get; set; }
        public String DatabaseName { get; set; }

        //private String[] modules;
        //private String unencryptedLicenseNo;
        //private String licenseNo;
        //private String licenseDate;
        //private String fingurePrint;
        //private DateTime registrationDate;
        //private String encryptedRegistrationDate;
        //private String encryptedLicenseDate;
        //private String productId;
        //private String productName;
        
        public Server()
        {

        }

        public List<String> GetSqlServerInstances(Boolean isLocal)
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

            return this.InsertInProductDB(lic);
        }

        //private Boolean ReadLicenseFile()
        //{
        //    this.AssignLicenseKey();
        //    using (FileStream fileStream = new FileStream(this.SourceLicenseFolder + "\\" + this.LicenseFileName, FileMode.Open))
        //    {
        //        using (BinaryReader reader = new BinaryReader(fileStream))
        //        {
        //            BinAff.Utility.Cryptography.Server svr = new BinAff.Utility.Cryptography.ManagedAes
        //            {
        //                EncryptionKey = this.unencryptedLicenseNo,
        //            };
        //            reader.ReadString(); //Ignore unencrypted product name
        //            this.productName = svr.Decrypt(reader.ReadString());
        //            this.productId = svr.Decrypt(reader.ReadString());
        //            if (this.productId == null) return false;
        //            this.licenseDate = svr.Decrypt(reader.ReadString());
        //            if (this.licenseDate == null) return false;
        //            reader.ReadString(); //Ignore license
        //            Int16 i = 0;
        //            while (reader.BaseStream.Position < reader.BaseStream.Length)
        //            {
        //                this.modules[i] = svr.Decrypt(reader.ReadString());
        //                if (this.modules[i++] == null) return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //private String AssignLicenseKey()
        //{
        //    using (FileStream fileStream = new FileStream(this.SourceLicenseFolder + "\\" + this.LicenseFileName, FileMode.Open))
        //    {
        //        using (BinaryReader reader = new BinaryReader(fileStream))
        //        {
        //            reader.ReadString(); //Ignore unencrypted product name
        //            reader.ReadString(); //Ignore product name
        //            reader.ReadString(); //Ignore product id
        //            reader.ReadString(); //Ignore License Date
        //            this.unencryptedLicenseNo = new Utility.Cryptography.ManagedAes
        //            {
        //                EncryptionKey = "B1n@ry@ff@1r5",
        //            }.Decrypt(reader.ReadString());
        //            this.licenseNo = this.unencryptedLicenseNo;
        //            Int16 i = 0;
        //            while (reader.BaseStream.Position < reader.BaseStream.Length)
        //            {
        //                reader.ReadString(); i++;
        //            }
        //            this.modules = new String[i];
        //        }
        //    }
        //    return this.licenseNo;
        //}

        private Int16 InsertInProductDB(SecurityHandler.License license)
        {
            Utility.Cryptography.ManagedAes encryptor = new Utility.Cryptography.ManagedAes
            {
                EncryptionKey = license.LicenseNumber,
            };

            System.Data.SqlClient.SqlConnection conn = Handler.GetConnectionObject(this.InstanceName, this.DatabaseName);
            conn.Open();
            System.Data.SqlClient.SqlTransaction trans = conn.BeginTransaction();

            if (!Handler.CreateSchema(trans, "BinAff")) return 500;
            if (!Handler.CreateTable(trans, "BinAff", "Stamp", new List<Handler.ColumnDefinition>
            {
                { new Handler.ColumnDefinition { ColumnName = "FingurePrint", Type = "VarChar(Max)" } },
                { new Handler.ColumnDefinition { ColumnName = "LicenseDate", Type = "VarChar(Max)" } },
                { new Handler.ColumnDefinition { ColumnName = "RegistrationDate", Type = "VarChar(Max)" } },
            })) return 501;

            //Overwrite FingurePrint
            Handler.InsertOrUpdate(trans, "BinAff", "Stamp", new Dictionary<String, String>
            {
                { "FingurePrint", "'" + encryptor.Encrypt(license.FingurePrint) + "'" },
                { "LicenseDate", "'" + encryptor.Encrypt(license.LicenseDate.ToShortDateString()) + "'" },
                { "RegistrationDate", "'" + encryptor.Encrypt(license.RegistrationDate.ToShortDateString()) + "'" },
            }, null);

            //Overwrite module list
            if (!Handler.CreateSchema(trans, "License")) return 600;
            if (!Handler.CreateTable(trans, "License", "Module", new List<Handler.ColumnDefinition>
            {
                { new Handler.ColumnDefinition { ColumnName = "Id", Type = "Numeric(10, 0)", IsAutoNumber = true } },
                { new Handler.ColumnDefinition { ColumnName = "Code", Type = "Char(4)" } },
                { new Handler.ColumnDefinition { ColumnName = "Name", Type = "VarChar(50)" } },
                { new Handler.ColumnDefinition { ColumnName = "Description", Type = "VarChar(50)", IsNull = true } },
                { new Handler.ColumnDefinition { ColumnName = "IsForm", Type = "Bit", IsNull = true } },
                { new Handler.ColumnDefinition { ColumnName = "IsReport", Type = "Bit", IsNull = true } },
                { new Handler.ColumnDefinition { ColumnName = "IsCatalogue", Type = "Bit", IsNull = true } },
            })) return 601;
            Int32 count = license.ModuleList.Count;
            List<KeyValuePair<String, String>> codeList = new List<KeyValuePair<String, String>>();
            for (Int32 i = 0; i < count; i++)
            {
                String[] tokens = license.ModuleList[i].Split(':');
                Handler.InsertOrUpdate(trans, "License", "Module", new Dictionary<String, String>
                {
                    { "Code", "'" + tokens[0] + "'" },
                    { "Name", "'" + tokens[1] + "'" },
                    { "Description", "'" + tokens[2] + "'" },
                    { "IsForm", "'" + tokens[3] + "'" },
                    { "IsCatalogue", "'" + tokens[4] + "'" },
                    { "IsReport", "'" + tokens[5] + "'" },

                }, new List<KeyValuePair<String, String>>
                {
                    new KeyValuePair<String, String>("Code", "'" + tokens[0] + "'"),
                });
                codeList.Add(new KeyValuePair<String, String>("Code", "'" + tokens[0] + "'"));
            }
            Handler.DeleteOther(trans, "License", "Module", codeList);
            trans.Commit();
            conn.Close();
            return 0;
        }

    }

}
