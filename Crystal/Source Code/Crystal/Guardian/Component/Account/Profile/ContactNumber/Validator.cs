using BinAff.Core;
using System.Collections.Generic;

namespace Crystal.Guardian.Component.Account.Profile.ContactNumber
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

            return retMsg;
        }

    }

}
