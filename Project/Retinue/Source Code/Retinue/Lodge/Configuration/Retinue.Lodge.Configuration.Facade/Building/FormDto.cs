using System.Collections.Generic;

namespace Retinue.Lodge.Configuration.Facade.Building
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        /// <summary>
        /// Building data transfer object
        /// </summary>
        public Dto Dto { get; set; }

        /// <summary>
        /// List of building
        /// </summary>
        public List<Dto> DtoList { get; set; }

        /// <summary>
        /// List of building type
        /// </summary>
        public List<Type.Dto> TypeList { get; set; }

    }

}
