using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Tariff.Component
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

            //-- this validation will not be applicable for lodge [here tariff is not on room but combination of 
            // category, type and AC]
            //if (ValidationRule.IsNullOrEmpty(data.Product) || (data.Product.Id == 0))
            //    retMsg.Add(new Message("Product cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Rate) || (data.Rate <= 0))
                retMsg.Add(new Message("Rate cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsDateLessThanToday(data.StartDate) && this.Data.Id == 0)
                retMsg.Add(new Message("Start date cannot be less than today.", Message.Type.Error));

            if (ValidationRule.IsDateLess(data.EndDate,data.StartDate))
                retMsg.Add(new Message("End date cannot be less than start date.", Message.Type.Error));

            return retMsg;
        }

    }

}
