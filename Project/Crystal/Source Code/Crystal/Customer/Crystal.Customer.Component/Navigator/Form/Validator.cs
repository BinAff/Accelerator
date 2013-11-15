using System.Collections.Generic;

using BinAff.Core;

using CrystalNavigatorForm = Crystal.Navigator.Component.Form;

namespace Crystal.Customer.Component.Navigator.Form
{

    public class Validator : CrystalNavigatorForm.Validator
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
