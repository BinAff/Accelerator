using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Organization.Component.Unit.Status
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
            Data data = (Data)base.Data;

            if (ValidationRule.IsNullOrEmpty(data.Name))
                retMsg.Add(new Message("Status cannot be empty.", Message.Type.Error));

            return retMsg;
        }

    }

}
