using System;

namespace Vanilla.Utility.Facade.SaveDialog
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String DocumentName { get; set; }
        public Artifact.Dto Parent { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            dto.Parent = this.Parent.Clone() as Artifact.Dto;
            return dto;
        }
    
    }

}