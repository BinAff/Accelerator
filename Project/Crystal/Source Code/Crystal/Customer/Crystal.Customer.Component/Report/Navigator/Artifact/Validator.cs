using System.Collections.Generic;

using CrystalNavigator = Crystal.Navigator.Component;
using BinAff.Core;

namespace Crystal.Customer.Component.Report.Navigator.Artifact
{
    public class Validator : CrystalNavigator.Artifact.Validator
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
