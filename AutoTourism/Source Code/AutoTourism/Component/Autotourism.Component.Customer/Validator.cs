using System.Collections.Generic;
using BinAff.Core;

namespace Autotourism.Component.Customer
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
