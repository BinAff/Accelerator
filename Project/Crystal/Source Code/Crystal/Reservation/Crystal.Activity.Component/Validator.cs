﻿using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Activity.Component
{

    public class Validator : Crystal.Customer.Component.Action.Validator
    {

        public Validator(Data data) 
            : base(data) 
        { 

        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = new List<Message>();
            Data data = (Data)base.Data;
            
            if (ValidationRule.IsDateLessThanToday(data.ActivityDate))
                retMsg.Add(new Message("Activity date cannot be less than today.", Message.Type.Error));

            return retMsg;
        }

    }

}
