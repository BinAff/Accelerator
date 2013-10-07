using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Guardian.Rule
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
            return retMsg;
        }

    }

}
