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

        public List<AttachmentSummery> AttachmentSummeryList { get; set; }

    }

    public struct AttachmentSummery
    {
        public String Path { get; set; }
        public String Action { get; set; }
    }

}
