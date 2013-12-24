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
            binAffKey.DeleteSubKeyTree(productName);
            RegistryKey productKey = binAffKey.CreateSubKey(productName);
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

    }

}
