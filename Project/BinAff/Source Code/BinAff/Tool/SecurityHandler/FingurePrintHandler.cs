using System;
using System.Security.Cryptography;
using System.Text;

namespace BinAff.Tool.SecurityHandler
{

    public static class FingurePrintHandler
    {

        public static string Generate()
        {
            string fingerPrint = GetHash("CPU >> " + BinAff.Utility.Hardware.Processor.Identifier
                    + "\nBIOS >> " + BinAff.Utility.Hardware.Bios.SerialNumber
                    + "\nBASE >> " + BinAff.Utility.Hardware.MotherBoard.SerialNumber);
            //+ "\nMAC >> " + BinAff.Utility.Hardware.NetworkCard.MacId);
            return fingerPrint;
        }

        private static string GetHash(string source)
        {
            return GetHexString(new MD5CryptoServiceProvider().ComputeHash(new ASCIIEncoding().GetBytes(source)));
        }

        private static string GetHexString(byte[] byteArray)
        {
            string s = string.Empty;
            for (int i = 0; i < byteArray.Length; i++)
            {
                byte b = byteArray[i];
                int n, n1, n2;
                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                s += (n2 > 9) ? ((char)(n2 - 10 + (int)'A')).ToString() : n2.ToString();
                s += (n1 > 9) ? ((char)(n1 - 10 + (int)'A')).ToString() : n1.ToString();
                if ((i + 1) != byteArray.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }

        public static Int16 Authenticate(String productName, String applicationFolder, String instanceName, String databaseName)
        {
            SecurityHandler.License appLic = LicenseFileHandler.Read(applicationFolder + "\\" + productName + ".lic"); //Find license file from application folder
            if (appLic == null) return 1; //License file tampered
            SecurityHandler.License license = appLic;

            SecurityHandler.License sysLic = LicenseFileHandler.Read(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\" + productName + ".lic"); //Find license file from system folder
            if (sysLic == null) return 1; //License file tampered

            if (license.CompareAll(sysLic) > 0) return 1; //License file tampered. The error is not shown; it can be used for internal purpose.

            SecurityHandler.License regLic = RegistryHandler.Read(appLic.LicenseNumber, productName); //Find license information from registry
            if (String.Compare(FingurePrintHandler.Generate(), regLic.FingurePrint) != 0) return 2; //Invalid machine
            if (license.CompareWithoutModule(regLic) > 0) return 1;

            return (Int16)((license.CompareAll(ProductDatabaseHandler.Read(license.LicenseNumber, instanceName, databaseName)) > 0) ? 5 : 0);
        }

    }

}
