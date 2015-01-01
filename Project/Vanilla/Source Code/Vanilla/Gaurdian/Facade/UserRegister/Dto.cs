using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.UserRegister
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String LoginId { get; set; }
        public List<Role.Dto> RoleList { get; set; }
        public List<LoginHistory.Dto> LoginHistory { get; set; } //Componet not created for login history

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.RoleList != null)
            {
                dto.RoleList = new List<Role.Dto>();
                foreach (Role.Dto role in this.RoleList)
                {
                    dto.RoleList.Add((role != null) ? role.Clone() as Role.Dto : null);
                }
            }
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
