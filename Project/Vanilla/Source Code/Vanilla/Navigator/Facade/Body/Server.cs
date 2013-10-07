using BinAffLib = BinAff.Facade.Library;

namespace Vanilla.Navigator.Facade.Body
{

    public class Server : BinAffLib.Server
    {

        public delegate void ChangePath(MenuSummary.Dto sender);
        public event ChangePath PathChanged;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

    }

}
