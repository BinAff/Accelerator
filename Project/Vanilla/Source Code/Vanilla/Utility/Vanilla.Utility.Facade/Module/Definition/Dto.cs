﻿using System;

namespace Vanilla.Utility.Facade.Module.Definition
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public String Name { get; set; }

        public String Code { get; set; }

        public String ComponentFormType { get; set; }

        public BinAff.Facade.Library.Dto ComponentFormDto { get; set; }

    }

}
