using System;

namespace Vanilla.Utility.Facade.SaveDialog
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        /// <summary>
        /// Name of the current item
        /// </summary>
        public String DocumentName { get; set; }

        /// <summary>
        /// Parent of the current item
        /// </summary>
        public Artifact.Dto Parent { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.Parent != null) dto.Parent = this.Parent.Clone() as Artifact.Dto;
            return dto;
        }
    
    }

}