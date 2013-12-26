using Microsoft.Win32;
using System;

namespace BinAff.Tool.SecurityHandler
{

    public static class RegistryHandler
    {

        public static void Write(String productId, String productName, String licenseNo, String licenseDate, String registrationDate, String fingurePrint)
        {
            RegistryKey softwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey binAffKey = GetKey(softwareKey, "BinAff");
            softwareKey.Close();
            RegistryKey productKey = GetKey(binAffKey, productName);
            binAffKey.Close();
            productKey.SetValue("Id", productId);
            productKey.SetValue("License Number", licenseNo);
            productKey.SetValue("License Date", licenseDate);
            productKey.SetValue("Fingure Print", fingurePrint);
            productKey.SetValue("Registration Date", registrationDate);
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
