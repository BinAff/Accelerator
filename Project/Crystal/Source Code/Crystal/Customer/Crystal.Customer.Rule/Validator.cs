using System.Collections.Generic;
using BinAff.Core;

namespace Crystal.Customer.Rule

{
    public class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            return new List<Message>();
        }

    }

}
