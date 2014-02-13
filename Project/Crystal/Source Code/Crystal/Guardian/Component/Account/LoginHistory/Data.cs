using System;

namespace Crystal.Guardian.Component.Account.LoginHistory
{

    public class Data : BinAff.Core.Data
    {

        public DateTime LoginStamp { get; set; }
        public DateTime LogoutStamp { get; set; }

    }

}
