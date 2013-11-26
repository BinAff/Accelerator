using System;

namespace Vanilla.Guardian.Facade.Login
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String UserId { get; set; }
        public String Password { get; set; }

    }

}
