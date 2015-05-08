using System.Collections.Generic;
using BinAff.Core;

namespace Crystal.Accountant.Component.Payment
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
            Data data = base.Data as Data;

            if (data.LineItemList == null || data.LineItemList.Count == 0)
            {
                retMsg.Add(new Message("List of payment cannot be empty.", Message.Type.Error));
            }

            return retMsg;
        }

    }

}
