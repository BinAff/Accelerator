using System.Collections.Generic;

using CrystalNavigator = Crystal.Navigator.Component;
using BinAff.Core;

namespace Crystal.Lodge.Component.RoomReservationReport.Navigator.Artifact
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
