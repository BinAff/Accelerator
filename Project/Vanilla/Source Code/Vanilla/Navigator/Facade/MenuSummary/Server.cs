using BinAffLib = BinAff.Facade.Library;

namespace Vanilla.Navigator.Facade.MenuSummary
{

    public class Server : BinAffLib.Server
    {

        public delegate void ChangePath(MenuSummary.Dto sender);
        public event ChangePath PathChanged;

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        protected override void LoadForm()
        {
            throw new System.NotImplementedException();
        }

        public override void ConvertToDto()
        {
            throw new System.NotImplementedException();
        }

        public override void ConvertFromDto()
        {
            throw new System.NotImplementedException();
        }

    }

}
