
using System.Collections.Generic;
using BinAff.Core;

using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact
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
