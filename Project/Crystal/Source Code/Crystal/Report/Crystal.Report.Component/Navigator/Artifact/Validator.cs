using System.Collections.Generic;

using BinAff.Core;

namespace Crystal.Report.Component.Navigator.Artifact
{

    public class Validator : Crystal.Navigator.Component.Artifact.Validator
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
