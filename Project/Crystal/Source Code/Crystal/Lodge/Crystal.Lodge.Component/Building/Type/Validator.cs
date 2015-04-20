using System.Collections.Generic;

using BinAff.Utility;
using BinAff.Core;

namespace Crystal.Lodge.Component.Building.Type
{

    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data) 
            : base(data) 
        {

        }

        protected override List<BinAff.Core.Message> Validate()
        {
            List<BinAff.Core.Message> retMsg = new List<BinAff.Core.Message>();
            Data data = base.Data as Data;

            if (ValidationRule.IsNullOrEmpty(data.Name))
            {
                retMsg.Add(new Message("Building type cannot be empty.", Message.Type.Error));
            }

            return retMsg;
        }

    }

}
