using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Reservation.Component.Status
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
                retMsg.Add(new Message("Reservation status name cannot be empty.", Message.Type.Error));

            return retMsg;
        }

    }

}
