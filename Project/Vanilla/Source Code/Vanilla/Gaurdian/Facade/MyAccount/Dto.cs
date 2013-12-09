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

    }

}
