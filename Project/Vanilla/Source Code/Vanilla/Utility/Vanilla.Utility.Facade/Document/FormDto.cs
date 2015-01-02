using System;
using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Document
{

    public class FormDto : BinAff.Facade.Library.FormDto
    {

        public Dto Dto { get; set; }

        public Artifact.Dto Document { get; set; }

        public String DocumentName
        {
            get
            {
                if (this.Document != null)
                {
                    return this.Document.FullFileName;
                }
                return String.Empty;
            }
        }

        public String DocumentPath
        {
            get
            {
                if (this.Document != null)
                {
                    return this.Document.Path + "." + this.Document.Extension;
                }
                return String.Empty;
            }
        }

    }

}
