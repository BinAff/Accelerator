using System.Collections.Generic;

using BinAff.Core;

using CrystalArtifact = Crystal.Customer.Component.Navigator.Artifact;

namespace Autotourism.Component.Customer.Navigator.Artifact
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
