using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinAff.Tool.SecurityHandler
{

    public class LicenseFileHandler
    {

        //public static void Write(Product.Data product, List<BinAff.Tool.SecurityHandler.Component.Data> componentList, String targetPath)
        public static void Write(Product.Data product, String targetPath)
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
                    binaryWriter.Write(new Utility.Cryptography.ManagedAes().Encrypt(licenseNo)); //Write license number with default encryption

                    binaryWriter.Write(svr.Encrypt(product.ModuleList.Count.ToString())); //Write number of modules
                    foreach (Module.Data module in product.ModuleList)
                    {
                        binaryWriter.Write(svr.Encrypt(module.Code + ":" + module.Name + ":" + module.Description + ":"
                            + module.IsMandatory));
                    }

                    List<Component.Data> componentList = GetComponentList(product);
                    binaryWriter.Write(svr.Encrypt(componentList.Count.ToString())); //Write number of components
                    foreach (Component.Data component in componentList)
                    {
                        binaryWriter.Write(svr.Encrypt(component.Code + ":" + component.Name + ":" + component.Description + ":"
                            + component.IsForm + ":" + component.IsCatalogue + ":" + component.IsReport));
                    }
                }
            }
        }

        private static List<Component.Data> GetComponentList(Product.Data product)
        {
            List<Component.Data> componentList = new List<Component.Data>();
            foreach (Module.Data module in product.ModuleList)
            {
                if (module.ComponentList != null)
                {
                    foreach (Component.Data component in module.ComponentList)
                    {
                        componentList.Add(component);
                    }
                }
            }
            return componentList;
        }

        public static void Append(String licenseNo, DateTime registrationDate, String targetPath)
        {
            using (FileStream fileStream = new FileStream(targetPath, FileMode.Append))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    Utility.Cryptography.Server svr = new Utility.Cryptography.ManagedAes
                    {
                        EncryptionKey = licenseNo,
                    };
                    binaryWriter.Write(svr.Encrypt(FingurePrintHandler.Generate())); //Write fingure print
                    binaryWriter.Write(svr.Encrypt(registrationDate.ToShortDateString())); //Write registration time
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

        //public static License Read(String filePath)
        //{
        //    String licenseNo = AssignLicenseKey(filePath);
        //    if (String.IsNullOrEmpty(licenseNo))
        //    {
        //        return null;
        //    }
        //    License lic = new License();
        //    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        //    {
        //        using (BinaryReader reader = new BinaryReader(fileStream))
        //        {
        //            BinAff.Utility.Cryptography.Server svr = new BinAff.Utility.Cryptography.ManagedAes
        //            {
        //                EncryptionKey = licenseNo,
        //            };
        //            lic.LicenseNumber = licenseNo;
        //            reader.ReadString(); //Ignore unencrypted product name
        //            lic.ProductName = svr.Decrypt(reader.ReadString());
        //            lic.ProductId = svr.Decrypt(reader.ReadString());
        //            if (lic.ProductId == null) return null;
        //            String data = reader.ReadString();
        //            lic.LicenseDate = Convert.ToDateTime(svr.Decrypt(data));
        //            if (lic.LicenseDate == null) return null;
        //            reader.ReadString(); //Ignore license
        //            lic.ModuleList = new List<String>();
        //            while (reader.BaseStream.Position < reader.BaseStream.Length)
        //            {
        //                String module = svr.Decrypt(reader.ReadString());
        //                lic.ModuleList.Add(module);
        //                if (module == null) return null;
        //            }
        //        }
        //    }
        //    return lic;
        //}

        public static License Read(String filePath)
        {
            String licenseNo = AssignLicenseKey(filePath);
            if (String.IsNullOrEmpty(licenseNo))
            {
                return null;
            }
            License lic = new License();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
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
                    if (lic.LicenseDate == null || lic.LicenseDate == DateTime.MinValue) return null;
                    reader.ReadString(); //Ignore license
                    Int16 moduleCount = Convert.ToInt16(svr.Decrypt(reader.ReadString()));
                    lic.ModuleList = new List<String>();
                    while (moduleCount-- > 0)
                    {
                        String module = svr.Decrypt(reader.ReadString());
                        lic.ModuleList.Add(module);
                        if (module == null) return null;
                    }
                    Int16 componentCount = Convert.ToInt16(svr.Decrypt(reader.ReadString()));
                    lic.ComponentList = new List<String>();
                    while (componentCount-- > 0)
                    {
                        String component = svr.Decrypt(reader.ReadString());
                        lic.ComponentList.Add(component);
                        if (component == null) return null;
                    }

                    if (reader.BaseStream.Position < reader.BaseStream.Length) //This part is optional
                    {
                        lic.FingurePrint = svr.Decrypt(reader.ReadString());
                        if (lic.FingurePrint == null) return null;
                        lic.RegistrationDate = Convert.ToDateTime(svr.Decrypt(reader.ReadString()));
                        if (lic.RegistrationDate == null || lic.RegistrationDate == DateTime.MinValue) return null;
                    }
                }
            }
            return lic;
        }

        private static String AssignLicenseKey(String filePath)
        {
            String licenseNo;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
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
                    if (licenseNo == null || licenseNo.Length != 11) return null;
                }
            }
            return licenseNo;
        }

    }

}
