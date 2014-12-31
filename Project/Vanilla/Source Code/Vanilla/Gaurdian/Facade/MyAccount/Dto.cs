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
            dto.Profile = this.Profile.Clone() as Profile.Dto;
            dto.SecurityAnswer = this.SecurityAnswer.Clone() as SecurityAnswer.Dto;
            dto.Extension = this.Extension.Clone();
            return dto;
        }

    }

}
