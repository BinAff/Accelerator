using System.Security.Cryptography;
using System.Text;

namespace BinAff.Tool.SecurityHandler.FingurePrint
{

    public static class Generator
    {

        public static string Value()
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
                s +=  (n1 > 9) ? ((char)(n1 - 10 + (int)'A')).ToString() : n1.ToString();
                if ((i + 1) != byteArray.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }

    }

}
