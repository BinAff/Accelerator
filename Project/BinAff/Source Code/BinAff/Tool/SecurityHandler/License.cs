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

        public Boolean Compare(License val)
        {
            if (!this.CompareWithoutModule(val)) return false;

            if (this.ModuleList == null && val.ModuleList == null) return true;
            if (this.ModuleList != null && val.ModuleList == null) return false;
            if (this.ModuleList == null && val.ModuleList != null) return false;
            if ((this.ModuleList.Count != val.ModuleList.Count)) return false; //Here both list will be not null.
            foreach (String module in this.ModuleList) //Here count of both list is same
            {
                if (String.IsNullOrEmpty(val.ModuleList.Find((p) => String.Compare(p, module) == 0))) return false;
            }

            return true;
        }

        public Boolean CompareWithoutModule(License val)
        {
            if (val == null) return false;

            if (this.ProductId != val.ProductId) return false;
            if (this.ProductName != val.ProductName) return false;
            if (this.LicenseNumber != val.LicenseNumber) return false;
            if (this.LicenseDate != val.LicenseDate) return false;
            if (this.FingurePrint != val.FingurePrint) return false;
            if (this.RegistrationDate != val.RegistrationDate) return false;

            return true;
        }

    }

}
