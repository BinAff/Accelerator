using System.Collections.Generic;
using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Organization.Component
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
                retMsg.Add(new Message("Name cannot be empty.", Message.Type.Error));

            if (data.ContactNumberList == null || data.ContactNumberList.Count == 0)
                retMsg.Add(new Message("Contact number cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Address))
                retMsg.Add(new Message("Address cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.City))
                retMsg.Add(new Message("City cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Pin))
                retMsg.Add(new Message("Pin code cannot be empty.", Message.Type.Error));

            if (!ValidationRule.IsNullOrEmpty(data.Pin) && !ValidationRule.IsPinCode(data.Pin.ToString()))
                retMsg.Add(new Message("Pin code is not valid.", Message.Type.Error));

            if (!ValidationRule.IsNullOrEmpty(data.Tan) && !ValidationRule.IsTANNumber(data.Tan))
                retMsg.Add(new Message("Tan number is not valid.", Message.Type.Error));

            return retMsg;
        }
    }
}
