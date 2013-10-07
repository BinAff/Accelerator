using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Guardian.Component.Account.Profile
{

    /// <summary>
    /// Validation class of User Profile 
    /// </summary>
    /// <remarks>
    /// Profile is depended on User component
    /// </remarks>
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

            if (ValidationRule.IsNullOrEmpty(data.DateOfBirth))
                retMsg.Add(new Message("Date of birth cannot be null", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.FirstName))
                retMsg.Add(new Message("First name cannot be empty.", Message.Type.Error));

            if (ValidationRule.IsNullOrEmpty(data.LastName))
                retMsg.Add(new Message("Last name cannot be empty.", Message.Type.Error));
            
            return retMsg;
        }

    }

}
