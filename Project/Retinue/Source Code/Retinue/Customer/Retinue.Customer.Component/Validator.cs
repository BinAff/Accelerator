using System.Collections.Generic;

using BinAff.Core;

namespace Retinue.Customer.Component
{

    public class Validator : Crystal.Customer.Component.Validator
    {

        public Validator(Data data)
            : base(data)
        {

        }

        protected override List<Message> Validate()
        {
            return base.Validate();            
        }

    }

}
