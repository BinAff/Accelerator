using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Lodge.Component.Room
{

    public class Validator : Product.Component.Validator
    {

        public Validator(Data data) 
            : base(data) 
        { 

        }

        protected override List<Message> Validate()
        {            
            List<Message> retMsg = base.Validate();
            Data data = (Data)base.Data;

            if (ValidationRule.IsNullOrEmpty(data.Building) || (data.Building.Id == 0))
                retMsg.Add(new Message("Building cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Floor) || (data.Floor.Id == 0))
                retMsg.Add(new Message("Building floor cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Type) || (data.Type.Id == 0))
                retMsg.Add(new Message("Type cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Category) || (data.Category.Id == 0))
                retMsg.Add(new Message("Category cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.Status) || (data.Status.Id == 0))
                retMsg.Add(new Message("Room status cannot be empty.", Message.Type.Error));
           
            return retMsg;
        }

    }

}
