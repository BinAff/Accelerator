using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;

namespace Crystal.Navigator.Component.Form
{

    public class Validator : Artifact.Validator
    {

        public Validator(Data data)
            :base(data)
        {
            
        }

        protected override List<Message> Validate()
        {
            return base.Validate();
        }

    }

}
