using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Guardian.Component.Account.SecurityAnswer
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

            if (ValidationRule.IsNullOrEmpty(data.Answer))
                retMsg.Add(new Message("Security answer cannot be empty.", Message.Type.Error));

            if(data.Question == null || data.Question.Id <= 0)
                retMsg.Add(new Message("Security question cannot be empty.", Message.Type.Error));

            return retMsg;
        }

    }

}
