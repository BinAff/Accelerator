using BinAff.Core;

using VanAcc = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Report.Facade.Container
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            throw new System.NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            throw new System.NotImplementedException();
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            new VanAcc.Server(new VanAcc.FormDto()).Logout();
        }

    }

}
