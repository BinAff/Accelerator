using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.Account
{
    
    public class Dto : BinAff.Facade.Library.Dto
    {

        /// <summary>
        /// User log in identifier
        /// </summary>
        public String LoginId { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public String Password { get; set; }

        public Profile.Dto Profile { get; set; }

        /// <summary>
        /// Original list of roles
        /// </summary>
        public List<Role.Dto> RoleList { get; set; }

        /// <summary>
        /// Answer for security question
        /// </summary>
        public SecurityAnswer.Dto SecurityAnswer { get; set; }

        public BinAff.Facade.Library.Dto Extension { get; set; }

        public LoginHistory.Dto LoginInfo { get; set; }

        public List<LoginHistory.Dto> LoginHistory { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if(dto.Profile != null) dto.Profile = this.Profile.Clone() as Profile.Dto;
            if (this.RoleList != null)
            {
                dto.RoleList = new List<Role.Dto>();
                foreach (Role.Dto login in this.RoleList)
                {
                    if (login != null) dto.RoleList.Add(login.Clone() as Role.Dto);
                }
            }
            if (dto.SecurityAnswer != null) dto.SecurityAnswer = this.SecurityAnswer.Clone() as SecurityAnswer.Dto;
            if (dto.Extension != null) dto.Extension = this.Extension.Clone();
            if (dto.LoginInfo != null) dto.LoginInfo = this.LoginInfo.Clone() as LoginHistory.Dto;
            if (this.LoginHistory != null)
            {
                dto.LoginHistory = new List<LoginHistory.Dto>();
                foreach (LoginHistory.Dto login in this.LoginHistory)
                {
                    dto.LoginHistory.Add((login != null) ? login.Clone() as LoginHistory.Dto : null);
                }
            }
            return dto;
        }

    }

}