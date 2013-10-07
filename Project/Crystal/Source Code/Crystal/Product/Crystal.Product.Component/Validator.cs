using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Product.Component
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
                retMsg.Add(new Message("Room name cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Number))
                retMsg.Add(new Message("Room number cannot be empty.", Message.Type.Error));

            return retMsg;
        }

    }

}
