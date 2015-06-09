using System.Collections.Generic;
using ContFac = Vanilla.Utility.Facade.Container;

namespace Vanilla.Form.Facade.Container
{

    public class FormDto : ContFac.FormDto
    {

        public Document.FormDto DocumentFormDto { get; set; }

    }

}