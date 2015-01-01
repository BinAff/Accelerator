using System;

using BinAff.Core;

namespace Vanilla.Guardian.Facade.SecurityAnswer
{

    public class Dto : BinAff.Facade.Library.Dto
    {

        public Table SecurityQuestion { get; set; }

        public String Answer { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (dto.SecurityQuestion != null) dto.SecurityQuestion = this.SecurityQuestion.Clone();
            return dto;
        }

    }

}