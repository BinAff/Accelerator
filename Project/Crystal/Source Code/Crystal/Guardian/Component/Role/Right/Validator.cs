using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Guardian.Component.Role.Right
{

    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            : base(data)
        {
            
        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = (Data)base.Data;

            if (ValidationRule.IsNullOrEmpty(data.Name))
                retMsg.Add(new Message("User right cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Module))
                retMsg.Add(new Message("Assigned module in user right cannot be empty.", Message.Type.Error));

            return retMsg;
        }

    }

}
