
using System.Collections.Generic;
using BinAff.Core;

using CrystalNavigator = Crystal.Navigator.Component;


namespace Retinue.Lodge.Component.Room.CheckIn.Navigator.Artifact
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
