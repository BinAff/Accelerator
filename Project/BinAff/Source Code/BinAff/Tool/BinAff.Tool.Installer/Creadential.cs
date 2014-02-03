using System;
using System.Collections.Generic;

namespace BinAff.Tool.Installer
{

    public class Creadential
    {

        public String CompanyName { get; set; }
        public String ProductName { get; set; }

        public String ApplicationFolder { get; set; }
        public String ApplicationPath
        {
            get
            {
                return this.ApplicationFolder + "\\" + this.CompanyName + "\\" + this.ProductName;
            }
        }

        public String InstanceName { get; set; }
        public String DatabaseName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

        public String licenseFilePath { get; set; }
        public String LicenseNumber { get; set; }
        public List<String> LicensedModuleList { get; set; }

    }

}
