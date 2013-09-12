using System;

namespace Vanilla.Navigator.Facade.Container
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            :base(formDto)
        {

        }

        public override void LoadForm()
        {
            Crystal.License.Data data = new Crystal.License.Data();
            Crystal.License.ILicense server = new Crystal.License.Server(data);
            server.Get();
        }

        public override void ConvertToDto()
        {
            throw new NotImplementedException();
        }

        public override void ConvertFromDto()
        {
            throw new NotImplementedException();
        }

    }

}
