using System.Collections.Generic;

namespace Vanilla.Guardian.Facade.UserRegister
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }
        public List<Account.Dto> DtoList { get; set; }
        public List<Role.Dto> RoleList { get; set; }
        public Rule.Dto Rule { get; set; }

    }

}
