using System.Collections.Generic;

using BinAff.Core;

using CrystalArtifact = Crystal.Customer.Component.Navigator.Artifact;

namespace Retinue.Customer.Component.Navigator.Artifact
{

    public class Validator : CrystalArtifact.Validator
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
