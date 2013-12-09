using System;

using BinAff.Core;

namespace Vanilla.Guardian.Facade.SecurityAnswer
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Table SecurityQuestion { get; set; }

        public String Answer { get; set; }

    }

}
