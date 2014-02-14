using System;

namespace Vanilla.Guardian.Facade.LoginHistory
{

    public class Dto : BinAff.Facade.Library.Dto
    {
        public DateTime LoginStamp { get; set; }
        public DateTime LogoutStamp { get; set; }
    }

}
