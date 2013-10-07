using System.Collections.Generic;
using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Organization.Component.Fax
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

            if (!ValidationRule.IsNullOrEmpty(data.Fax) && !ValidationRule.IsFaxNumber(data.Fax))
                retMsg.Add(new Message("Fax is not valid.", Message.Type.Error));

            return retMsg;
        }
    }
}
