using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Accountant.Component.Payment.LineItem
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

            if (ValidationRule.IsNullOrEmpty(data.Type))
            {
                retMsg.Add(new Message("Payment Type cannot be empty.", Message.Type.Error));
            }
            if(!ValidationRule.IsPositive(data.Amount))
            {
                retMsg.Add(new Message("Payment amount cannot be zero or negetive.", Message.Type.Error));
            }

            return retMsg;
        }

    }

}
