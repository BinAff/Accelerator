using System;
using System.Collections.Generic;

using BinAff.Core;

namespace Vanilla.Guardian.Facade.Profile
{

    public class Dto : BinAff.Facade.Library.Dto
    {
        
        public BinAff.Core.Table Initial { get; set; }

        public String Name
        {
            get
            {
                return this.FirstName
                    + (String.IsNullOrEmpty(this.MiddleName) ? "" : " " + this.MiddleName)
                    + (String.IsNullOrEmpty(this.LastName) ? "" : " " + this.LastName);
            }
        }

        /// <summary>
        /// First name of user
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// Middle name of user
        /// </summary>
        public String MiddleName { get; set; }

        /// <summary>
        /// Last name of user
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// Date of birth of user
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// List of contact numbers of user
        /// </summary>
        public List<Table> ContactNumberList { get; set; }

        public BinAff.Facade.Library.Dto Extension { get; set; }

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
            dto.Extension = this.Extension.Clone();
            return dto;
        }

    }

}
