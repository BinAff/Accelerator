using System.Collections.Generic;

using BinAff.Core;

using CrystalForm = Crystal.Customer.Component.Navigator.Form;

namespace Autotourism.Component.Customer.Navigator.Form
{

    public class Validator : CrystalForm.Validator
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
