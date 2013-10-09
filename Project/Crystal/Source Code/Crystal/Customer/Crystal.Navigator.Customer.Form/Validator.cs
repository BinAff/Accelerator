using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Navigator.Form.Customer
{

    public class Validator : Crystal.Navigator.Component.Form.Validator
    {

        public Validator(Data data)
            :base(data)
        {
            
        }

        protected override List<Message> Validate()
        {
            //Data data = (Data)base.Data;
            //List<Message> retMsg = base.Validate();
            
            //if (ValidationRule.IsNullOrEmpty(data.ModuleData))
            //    retMsg.Add(new Message("Customer cannot be empty.", Message.Type.Error));
            //return retMsg;
            return base.Validate();
        }

    }

}
