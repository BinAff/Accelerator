using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using System;

namespace Crystal.Diary.Component.Appointment.Importance
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
            {
                retMsg.Add(new Message("Importance cannot be empty.", Message.Type.Error));
            }
            else if (data.Name.Length > 50)
            {
                retMsg.Add(new Message("Importance cannot be more than 50 characters.", Message.Type.Error));
            }
            else if (this.IsExist())
            {
                retMsg.Add(new Message("Same Importance already exists.", Message.Type.Error));
            }

            return retMsg;
        }

        private Boolean IsExist()
        {
            return new Dao(this.Data as Data).ReadDuplicate();
        }

    }

}
