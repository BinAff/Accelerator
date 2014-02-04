using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Customer.Component.Action.Status
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
            {
                retMsg.Add(new Message("Action status name cannot be empty.", Message.Type.Error));
            }

            return retMsg;
        }

    }

}
