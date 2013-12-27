using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using BinAff.SqlServerUtil;
using BinAff.Utility.Cryptography;

namespace BinAff.Tool.SecurityHandler
{

    public static class ProductDatabaseHandler
    {

        public static Int16 Write(License license, String instanceName, String databaseName)
        {
            ManagedAes encryptor = new ManagedAes
            {
                EncryptionKey = license.LicenseNumber,
            };

            SqlConnection conn = Handler.GetConnectionObject(instanceName, databaseName);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            if (!Handler.CreateSchema(trans, "BinAff")) return 500;
            if (!Handler.CreateTable(trans, "BinAff", "Stamp", new List<Handler.ColumnDefinition>
            {
                { new Handler.ColumnDefinition { ColumnName = "ProductId", Type = "VarChar(Max)" } },
                { new Handler.ColumnDefinition { ColumnName = "ProductName", Type = "VarChar(Max)" } },
                { new Handler.ColumnDefinition { ColumnName = "FingurePrint", Type = "VarChar(Max)" } },
                { new Handler.ColumnDefinition { ColumnName = "LicenseDate", Type = "VarChar(Max)" } },
                { new Handler.ColumnDefinition { ColumnName = "RegistrationDate", Type = "VarChar(Max)" } },
            })) return 501;

            //Overwrite FingurePrint
            Handler.InsertOrUpdate(trans, "BinAff", "Stamp", new Dictionary<String, String>
            {
                { "ProductId", "'" + license.ProductId + "'" },
                { "ProductName", "'" + license.ProductName + "'" },
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

        public static License Read(String licenseNo, String instanceName, String databaseName)
        {
            License lics;
            SqlConnection conn = Handler.GetConnectionObject(instanceName, databaseName);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            System.Data.DataRow stamp = Handler.ReadRow(trans, "BinAff", "Stamp");

            ManagedAes decryptor = new ManagedAes
            {
                EncryptionKey = licenseNo,
            };

            lics = new SecurityHandler.License
            {
                ProductId = stamp["ProductId"].ToString(),
                ProductName = stamp["ProductName"].ToString(),
                LicenseNumber = licenseNo,
                FingurePrint = decryptor.Decrypt(stamp["FingurePrint"].ToString()),
                LicenseDate = Convert.ToDateTime(decryptor.Decrypt(stamp["LicenseDate"].ToString())),
                RegistrationDate = Convert.ToDateTime(decryptor.Decrypt(stamp["RegistrationDate"].ToString())),
            };

            DataTable dt = Handler.Read(trans, "License", "Module");
            lics.ModuleList = new List<String>();
            foreach (DataRow dr in dt.Rows)
            {
                lics.ModuleList.Add(String.Format("{0}:{1}:{2}:{3}:{4}:{5}",
                    dr["Code"].ToString(), dr["Name"].ToString(), dr["Description"].ToString(),
                    dr["IsForm"].ToString(), dr["IsCatalogue"].ToString(), dr["IsReport"].ToString()));
            }
            trans.Commit();
            conn.Close();
            return lics;
        }

    }

}
