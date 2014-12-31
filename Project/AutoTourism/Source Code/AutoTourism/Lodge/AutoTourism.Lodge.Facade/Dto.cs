using System;
using System.Collections.Generic;

using BinAff.Core;

namespace AutoTourism.Lodge.Facade
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public Byte[] logo { get; set; }
        public String LicenceNumber { get; set; }
        public String Tan { get; set; }

        public String LuxuryTaxNumber { get; set; }
        public String ServiceTaxNumber { get; set; }

        public String Address { get; set; }
        public String City { get; set; }
        public Table State { get; set; }
        public Int64 Pin { get; set; }
        public String ContactName { get; set; }

        public List<Table> ContactNumberList { get; set; }
        public List<Table> FaxList { get; set; }
        public List<Table> EmailList { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;

            if (this.ContactNumberList != null)
            {
                dto.ContactNumberList = new List<Table>();
                foreach (Table contactNumber in this.ContactNumberList)
                {
                    dto.ContactNumberList.Add(contactNumber.Clone());
                }
            }
            if (this.FaxList != null)
            {
                dto.FaxList = new List<Table>();
                foreach (Table fax in this.FaxList)
                {
                    dto.FaxList.Add(fax.Clone());
                }
            }
            if (this.EmailList != null)
            {
                dto.EmailList = new List<Table>();
                foreach (Table email in this.EmailList)
                {
                    dto.EmailList.Add(email.Clone());
                }
            }
            return dto;
        }

    }

}
