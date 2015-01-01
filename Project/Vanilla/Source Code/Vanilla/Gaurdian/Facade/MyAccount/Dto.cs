using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.MyAccount
{

    public class Dto : BinAff.Facade.Library.Dto
    {
        
        public Profile.Dto Profile { get; set; }

        public String Password { get; set; }

        /// <summary>
        /// Answer for security question
        /// </summary>
        public SecurityAnswer.Dto SecurityAnswer { get; set; }

        public BinAff.Facade.Library.Dto Extension { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (dto.Profile != null) dto.Profile = this.Profile.Clone() as Profile.Dto;
            if (dto.SecurityAnswer != null) dto.SecurityAnswer = this.SecurityAnswer.Clone() as SecurityAnswer.Dto;
            if (dto.Extension != null) dto.Extension = this.Extension.Clone();
            return dto;
        }

    }

}