using System;
using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Accountant.Component.Tax
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
                retMsg.Add(new Message("Taxation name cannot be empty.", Message.Type.Error));
            else if (data.Name.Length > 50)
                retMsg.Add(new Message("Taxation name cannot be more than 50 characters.", Message.Type.Error));
            
            if (Convert.ToDouble(data.Amount) <= 0 )
                retMsg.Add(new Message("Taxation amount cannot be 0 or negative.", Message.Type.Error));
            
            if (this.IsExist(data))
                retMsg.Add(new Message("Same Taxation name already exists.", Message.Type.Error));

            return retMsg;
        }

        private Boolean IsExist(Data data)
        {
            return new Dao(data).ReadDuplicate();
        }

    }

}
