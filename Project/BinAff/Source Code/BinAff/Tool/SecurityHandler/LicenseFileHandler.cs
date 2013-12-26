using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinAff.Tool.SecurityHandler
{

    public class LicenseFileHandler
    {

        public static void Write(Product.Data product, List<Module.Data> moduleList, String targetPath)
        {
            using (FileStream fileStream = new FileStream(targetPath, FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    String licenseNo = GenerateUniqueId();
                    binaryWriter.Write(product.Name);
                    Utility.Cryptography.Server svr = new Utility.Cryptography.ManagedAes
                    {
                        EncryptionKey = licenseNo,
                    };
                    binaryWriter.Write(svr.Encrypt(product.Name));
                    binaryWriter.Write(svr.Encrypt(product.Code));
                    binaryWriter.Write(svr.Encrypt(DateTime.Today.ToShortDateString())); //Write date of license
                    binaryWriter.Write(new Utility.Cryptography.ManagedAes
                    {
                        EncryptionKey = "B1n@ry@ff@1r5",
                    }.Encrypt(licenseNo)); //Write license number
                    foreach (SecurityHandler.Module.Data module in moduleList)
                    {
                        binaryWriter.Write(svr.Encrypt(module.Code + ":" + module.Name + ":" + module.Description + ":"
                            + module.IsForm + ":" + module.IsCatalogue + ":" + module.IsReport));
                    }
                }
            }
        }

        private static String GenerateUniqueId()
        {
            StringBuilder sb = new StringBuilder();

            DateTime current = DateTime.Now;
            if (current.Millisecond < 10)
            {
                sb.Append("00" + current.Millisecond);
            }
            else if (current.Millisecond < 100)
            {
                sb.Append("0" + current.Millisecond);
            }
            else
            {
                sb.Append(current.Millisecond);
            }
            sb.Append(ConvertToCode(current.Month));
            sb.Append(ConvertToCode(current.Day));
            sb.Append((current.Year % 100) % 10); //Last digit of year
            sb.Append(ConvertToCode(current.Hour));
            sb.Append(ConvertToCode(current.Minute));
            sb.Append(ConvertToCode(current.Year / 100)); //First 2 digit of year
            sb.Append(ConvertToCode(current.Second));
            sb.Append((current.Year % 100) / 10); //Third digit of year

            return sb.ToString();
        }

        private static Char ConvertToCode(Int32 no)
        {
            Char code;
            switch (no)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    code = (char)(no + '0'); //0 to 9
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                    code = (char)('A' + no - 10); //A to Z
                    break;
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                case 61:
                    code = (char)('a' + no - 36); //a to z
                    break;
                default: code = '0';
                    break;
            }
            return code;
        }

        public static License Read(String folderPath, String productName)
        {
            String licenseNo = AssignLicenseKey(folderPath, productName);
            if (String.IsNullOrEmpty(licenseNo))
            {
                return null;
            }
            License lic = new License();
            using (FileStream fileStream = new FileStream(folderPath + "\\" + productName + ".lic", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    BinAff.Utility.Cryptography.Server svr = new BinAff.Utility.Cryptography.ManagedAes
                    {
                        EncryptionKey = licenseNo,
                    };
                    lic.LicenseNumber = licenseNo;
                    reader.ReadString(); //Ignore unencrypted product name
                    lic.ProductName = svr.Decrypt(reader.ReadString());
                    lic.ProductId = svr.Decrypt(reader.ReadString());
                    if (lic.ProductId == null) return null;
                    String data = reader.ReadString();
                    lic.LicenseDate = Convert.ToDateTime(svr.Decrypt(data));
                    if (lic.LicenseDate == null) return null;
                    reader.ReadString(); //Ignore license
                    lic.ModuleList = new List<String>();
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        String module = svr.Decrypt(reader.ReadString());
                        lic.ModuleList.Add(module);
                        if (module == null) return null;
                    }
                }
            }
            return lic;
        }

        private static String AssignLicenseKey(String folderPath, String productName)
        {
            String licenseNo;
            using (FileStream fileStream = new FileStream(folderPath + "\\" + productName + ".lic", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    reader.ReadString(); //Ignore unencrypted product name
                    reader.ReadString(); //Ignore product name
                    reader.ReadString(); //Ignore product id
                    reader.ReadString(); //Ignore License Date
                    licenseNo = new Utility.Cryptography.ManagedAes
                    {
                        EncryptionKey = "B1n@ry@ff@1r5",
                    }.Decrypt(reader.ReadString());
                    if (licenseNo.Length != 11) return null;
                }
            }
            return licenseNo;
        }        

    }

}
