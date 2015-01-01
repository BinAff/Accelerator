using System;
using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.Register
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String LoginId { get; set; }

        public String Password { get; set; }

        public List<Role.Dto> RoleList { get; set; }

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
            return dto;
        }

    }

}