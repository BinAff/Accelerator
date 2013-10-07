using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Customer.Component.Action
{

    public abstract class Validator : BinAff.Core.Validator
    {

        public Validator(Data data)
            : base(data)
        {

        }

        protected abstract override List<Message> Validate();

    }

}
