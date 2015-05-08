using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Customer.Facade
{

    public class Dto : Vanilla.Form.Facade.Document.Dto
    {

        //public Table Initial { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public Table State { get; set; }
        public String City { get; set; }
        public Int32 Pin { get; set; }
        public Table Country { get; set; }
        public String Email { get; set; }
        public Table IdentityProofType { get; set; }
        public String IdentityProofName { get; set; }
           
        public List<Table> ContactNumberList { get; set; }
        public String ArtifactPath { get; set; } // why required? Need to validate - Arpan

        /// <summary>
        /// Get full name
        /// </summary>
        public String Name
        {
            get
            {
                String name = String.Empty;
                name += (name == String.Empty) ? (this.FirstName == null ? String.Empty : this.FirstName) : " " + (this.FirstName == null ? String.Empty : this.FirstName);
                name += (name == String.Empty) ? (this.MiddleName == null ? String.Empty : this.MiddleName) : " " + (this.MiddleName == null ? String.Empty : this.MiddleName);
                name += (name == String.Empty) ? (this.LastName == null ? String.Empty : this.LastName) : " " + (this.LastName == null ? String.Empty : this.LastName);
                return name;
            }
        }

        /// <summary>
        /// Get complete address
        /// </summary>
        public String FullAddress
        {
            get
            {
                String adds = this.Address;
                if (!String.IsNullOrEmpty(this.City)) adds += Environment.NewLine + this.City;
                if (this.State != null && !String.IsNullOrEmpty(this.State.Name)) adds += Environment.NewLine + this.State;
                if (this.Pin != 0) adds += Environment.NewLine + "Pin : " + this.Pin;
                if (this.Country != null && !String.IsNullOrEmpty(this.Country.Name)) adds += Environment.NewLine + this.Country;
                return adds;
            }
        }

        /// <summary>
        /// Get formated identity proof
        /// </summary>
        public String IdentityProof
        {
            get
            {
                return this.IdentityProofType.Name + " - " + this.IdentityProofName;
            }
        }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.ContactNumberList != null)
            {
                dto.ContactNumberList = new List<Table>();
                foreach (Table contactNumber in this.ContactNumberList)
                {
                    dto.ContactNumberList.Add((contactNumber != null) ? contactNumber.Clone() : null);
                }
            }
            if (this.Country != null) dto.Country = this.Country.Clone();
            if (this.IdentityProofType != null) dto.IdentityProofType = this.IdentityProofType.Clone();
            if (this.State != null) dto.State = this.State.Clone();
            return dto;
        }
        
    }

}
