using System;

using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact
{

    public class Dao : ArtfComp.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            base.CreateComponentLinkSPName = "Lodge.ReservationArtifactInsertLink";
            base.ReadComponentLinkSPName = "Lodge.RoomReservationArtifactReadLink";
            base.UpdateComponentLinkSPName = "Lodge.ReservationArtifactUpdateLink";
            this.DeleteComponentLinkSPName = "Lodge.ReservationArtifactDeleteLink";
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, ArtfComp.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

        protected override BinAff.Core.Data GetComponentData(Int64 componentId)
        {
            return new Room.Reservation.Data
            {
                Id = componentId
            };
        }

    }

}
