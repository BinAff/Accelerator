using System;

using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact
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
            base.CreateComponentLinkSPName = "Lodge.CheckInArtifactInsertLink";
            base.ReadComponentLinkSPName = "Lodge.CheckInArtifactReadLink";
            base.UpdateComponentLinkSPName = "Lodge.CheckInArtifactUpdateLink";
            this.DeleteComponentLinkSPName = "Lodge.CheckInArtifactDeleteLink";
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
            return new Room.CheckIn.Data
            {
                Id = componentId
            };
        }

    }

}
