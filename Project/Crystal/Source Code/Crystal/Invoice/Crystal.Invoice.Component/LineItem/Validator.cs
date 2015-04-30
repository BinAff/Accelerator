using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Invoice.Component.LineItem
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


            //need to discuss:: not looking logical
            //if (!ValidationRule.IsNullOrEmpty(data.Start) && ValidationRule.IsDateGreaterThanToday(data.Start.Date))
            //    retMsg.Add(new Message("Start date cannot be greater than today.", Message.Type.Error));

            //if (!ValidationRule.IsNullOrEmpty(data.End) && ValidationRule.IsDateGreaterThanToday(data.End.Date))
            //    retMsg.Add(new Message("End date cannot be greater than today.", Message.Type.Error));

            if (!ValidationRule.IsNullOrEmpty(data.Start) && !ValidationRule.IsNullOrEmpty(data.End))
            {
                if (ValidationRule.IsDateLess(data.End, data.Start))
                    retMsg.Add(new Message("End date cannot be less than start date.", Message.Type.Error));
            }
            
            //if (ValidationRule.IsNullOrEmpty(data.Description))
            //    retMsg.Add(new Message("Item description cannot be empty.", Message.Type.Error));
            //else  

            if(!ValidationRule.IsNullOrEmpty(data.Description) && data.Description.Length > 250)
                retMsg.Add(new Message("Item description length cannot be more than 250 characters.", Message.Type.Error));

            if (data.UnitRate <= 0)
                retMsg.Add(new Message("Unit rate cannot be 0 or -ve.", Message.Type.Error));

            if (data.Count <= 0)
                retMsg.Add(new Message("Item count cannot be 0 or -ve.", Message.Type.Error));

            return retMsg;
        }
        
    }

}
