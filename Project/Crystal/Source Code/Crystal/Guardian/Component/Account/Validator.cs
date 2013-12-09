using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Guardian.Component.Account
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

            if (ValidationRule.IsNullOrEmpty(data.LoginId))
            {
                retMsg.Add(new Message("Login Id cannot be null", Message.Type.Error));
            }

            if (ValidationRule.IsNullOrEmpty(data.Password))
            {
                retMsg.Add(new Message("Password cannot be empty.", Message.Type.Error));
            }

            if (this.Data.Id != new Dao(data).GetUserByLoginId().Id)
            {
                retMsg.Add(new Message("Duplicate login id is not allowed.", Message.Type.Error));
            }

            return retMsg;
        }

    }

}
