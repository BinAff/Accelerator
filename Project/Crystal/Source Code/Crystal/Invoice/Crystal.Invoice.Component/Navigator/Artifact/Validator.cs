using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CrystalNavigator = Crystal.Navigator.Component;
using BinAff.Core;

namespace Crystal.Invoice.Component.Navigator.Artifact
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
