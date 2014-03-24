using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.License.Component
{

    internal class Validator : BinAff.Core.Validator
    {

        internal Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = base.Data as Data;

            if (ValidationRule.IsNullOrEmpty(data.Name))
            {
                retMsg.Add(new Message("Module name cannot be null.", Message.Type.Error));
            }
            else if (!ValidationRule.IsAlphaNumeric(data.Name))
            {
                retMsg.Add(new Message("Module name can be only alphabet or number.", Message.Type.Error));
            }
            else if(this.IsExist())
            {
                retMsg.Add(new Message("Duplicate record.", Message.Type.Error));
            }

            if (ValidationRule.IsNullOrEmpty(data.Description))
            {
                retMsg.Add(new Message("Description cannot be null.", Message.Type.Error));
            }

            return retMsg;
        }

        internal Boolean IsExist()
        {
            return this.Server.DataAccess.Read() != null;
        }

    }

}
