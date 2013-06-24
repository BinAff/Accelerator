using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Guardian.Component.SecurityQuestion
{

    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            :base(data)
        {
            
        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = (Data)base.Data;

            if (ValidationRule.IsNullOrEmpty(data.Question))
                retMsg.Add(new Message("Security question cannot be empty.", Message.Type.Error));

            return retMsg;
        }

    }

}
