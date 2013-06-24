using BinAff.Core;

namespace Crystal.Guardian.Component.Account.SecurityAnswer
{

    public interface ISecurityAnswer
    {

        ReturnObject<BinAff.Core.Data> GetLoggedInUserSecurityAnswer();

    }

}
