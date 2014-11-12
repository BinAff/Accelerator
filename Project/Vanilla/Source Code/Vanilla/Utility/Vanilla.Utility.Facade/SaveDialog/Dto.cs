using System;

namespace Vanilla.Utility.Facade.SaveDialog
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String DocumentName { get; set; }
        public Artifact.Dto Parent { get; set; }
    
    }

}