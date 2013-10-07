using BinAff.Core;
using System;

namespace Vanilla.Navigator.Facade.Module
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {
        }

        public override void LoadForm()
        {
            Crystal.Navigator.Component.Artifact.Data artifact = new Crystal.Navigator.Component.Artifact.Data();
            (new Crystal.Navigator.Component.Artifact.Server(artifact) as ICrud).Read();
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
