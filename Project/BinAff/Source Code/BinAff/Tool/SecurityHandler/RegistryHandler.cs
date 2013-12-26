﻿using Microsoft.Win32;
using System;

namespace BinAff.Tool.SecurityHandler
{

    public static class RegistryHandler
    {

        public static void Write(License license)
        {
            RegistryKey softwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey binAffKey = GetKey(softwareKey, "BinAff");
            softwareKey.Close();
            RegistryKey productKey = GetKey(binAffKey, license.ProductName);
            binAffKey.Close();
            Utility.Cryptography.ManagedAes encryptor = new Utility.Cryptography.ManagedAes
            {
                EncryptionKey = license.LicenseNumber,
            };
            productKey.SetValue("Id", license.ProductId);
            productKey.SetValue("License Number", encryptor.Encrypt(license.LicenseNumber));
            productKey.SetValue("License Date", encryptor.Encrypt(license.LicenseDate.ToShortDateString()));
            productKey.SetValue("Fingure Print", encryptor.Encrypt(license.FingurePrint));
            productKey.SetValue("Registration Date", encryptor.Encrypt(license.RegistrationDate.ToShortDateString()));
            productKey.Close();
        }

        private static RegistryKey GetKey(RegistryKey parent, String keyName)
        {
            String[] keys = parent.GetSubKeyNames();
            RegistryKey newKey = null;
            Boolean isNew = true;
            foreach (String key in keys)
            {
                if (String.Compare(key, keyName) == 0)
                {
                    newKey = parent.OpenSubKey(keyName, true);
                    isNew = false;
                    break;
                }
            }
            if (isNew) newKey = parent.CreateSubKey(keyName);
            return newKey;
        }

        public static License Read(String licenseNo, String productName)
        {
            Utility.Cryptography.ManagedAes decryptor = new Utility.Cryptography.ManagedAes
            {
                EncryptionKey = licenseNo,
            };
            RegistryKey softwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            if (softwareKey == null) return null;
            RegistryKey binAffKey = OpenKey(softwareKey, "BinAff");
            softwareKey.Close();
            if (binAffKey == null) return null;
            RegistryKey productKey = OpenKey(binAffKey, productName);
            binAffKey.Close();
            if (productKey == null) return null;
            License lic = new License
            {
                ProductId = Convert.ToString(productKey.GetValue("Id")),
                ProductName = productName,
                LicenseNumber = decryptor.Decrypt(Convert.ToString(productKey.GetValue("License Number"))),
                LicenseDate = Convert.ToDateTime(decryptor.Decrypt(Convert.ToString(productKey.GetValue("License Date")))),
                FingurePrint = decryptor.Decrypt(Convert.ToString(productKey.GetValue("Fingure Print"))),
                RegistrationDate = Convert.ToDateTime(decryptor.Decrypt(Convert.ToString(productKey.GetValue("Registration Date")))),
            };
            productKey.Close();
            return lic;
        }

        private static RegistryKey OpenKey(RegistryKey parent, String keyName)
        {
            String[] keyNames = parent.GetSubKeyNames();
            RegistryKey newKey = null;
            foreach (String key in keyNames)
            {
                if (String.Compare(key, keyName) == 0)
                {
                    newKey = parent.OpenSubKey(keyName, true);
                    break;
                }
            }
            return newKey;
        }

    }

}
