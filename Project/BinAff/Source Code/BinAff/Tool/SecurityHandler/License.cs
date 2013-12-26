using System;
using System.Collections.Generic;

namespace BinAff.Tool.SecurityHandler
{

    public class License
    {

        public String LicenseNumber { get; set; }
        public String ProductName { get; set; }
        public String ProductId { get; set; }
        public DateTime LicenseDate { get; set; }
        public String FingurePrint { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<String> ModuleList { get; set; }

        public Int16 CompareAll(License val)
        {
            Int16 ret = this.CompareWithoutModule(val);
            if (ret > 0) return ret;

            if (this.ModuleList == null && val.ModuleList == null) return 0;
            if (this.ModuleList != null && val.ModuleList == null) return 600;
            if (this.ModuleList == null && val.ModuleList != null) return 600;
            if ((this.ModuleList.Count != val.ModuleList.Count)) return 600; //Here both list will be not null.
            foreach (String module in this.ModuleList) //Here count of both list is same
            {
                if (String.IsNullOrEmpty(val.ModuleList.Find((p) => String.Compare(p, module) == 0))) return 601;
            }

            return 0;
        }

        public Int16 CompareWithoutModule(License val)
        {
            if (val == null) return 100;

            if (this.ProductId != val.ProductId) return 200;
            if (this.ProductName != val.ProductName) return 201;
            if (this.LicenseNumber != val.LicenseNumber) return 300;
            if (this.LicenseDate != val.LicenseDate) return 301;
            if (this.FingurePrint != val.FingurePrint) return 400;
            if (this.RegistrationDate != val.RegistrationDate) return 500;

            return 0;
        }

    }

}
