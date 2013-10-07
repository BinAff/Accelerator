using System.Collections.Generic;
using BinAff.Utility;
using BinAff.Core;

namespace Crystal.Lodge.Component.Room.ClosureReason
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

            if (ValidationRule.IsNullOrEmpty(data.Reason))
                retMsg.Add(new Message("Room closure reason cannot be empty.", BinAff.Core.Message.Type.Error));

            //if (ValidationRule.IsDateLessThanToday(data.ClosedDate))
            //    retMsg.Add(new Message("Closure date cannot be less than today.", Message.Type.Error));

            return retMsg;
        }
    }
}
