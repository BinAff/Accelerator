using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vanilla.Navigator.Facade.Module
{

    public class Server : BinAff.Facade.Library.Server
    {

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
