using System.Collections.Generic;
using BinAff.Utility;
using BinAff.Core;

namespace Retinue.Lodge.Component.Room.Status
{
    public class Validator : BinAff.Core.Validator
    {
        public Validator(Data data) 
            : base(data) 
        { 
        }

        protected override List<BinAff.Core.Message> Validate()
        {
            List<BinAff.Core.Message> retMsg = new List<BinAff.Core.Message>();
            Data data = (Data)base.Data;

            if (ValidationRule.IsNullOrEmpty(data.Name))
                retMsg.Add(new Message("Room status name cannot be empty.", BinAff.Core.Message.Type.Error));

            return retMsg;
        }
    }
}
