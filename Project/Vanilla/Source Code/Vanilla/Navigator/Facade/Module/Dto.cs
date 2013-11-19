using System;
using System.Collections.Generic;

namespace Vanilla.Navigator.Facade.Module
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }
        public String Code { get; set; }

        public Artifact.Dto Artifact { get; set; }

    }

}
