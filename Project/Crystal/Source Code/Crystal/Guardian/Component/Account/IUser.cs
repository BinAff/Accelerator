using System;

using BinAff.Core;

namespace Crystal.Guardian.Component.Account
{

    public interface IUser
    {

        ReturnObject<BinAff.Core.Data> Login();
        ReturnObject<Boolean> ChangePassword();
        ReturnObject<Boolean> ChangeRole();
        ReturnObject<Boolean> ChangeLoginId();

        void Logout();

    }

}
