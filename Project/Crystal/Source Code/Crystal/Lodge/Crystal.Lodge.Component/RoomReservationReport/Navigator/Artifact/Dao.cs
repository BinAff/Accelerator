using System;
using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Lodge.Component.RoomReservationReport.Navigator.Artifact
{

    public class Dao : Crystal.Report.Component.Navigator.Artifact.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            base.CreateComponentLinkSPName = "[Lodge].[InsertRoomReservationReportForArtifact]";
            base.ReadComponentLinkSPName = "[Lodge].[ReadRoomReservationReportForArtifact]";
            base.DeleteComponentLinkSPName = "[Lodge].[DeleteRoomReservationReportForArtifact]";
        }

        protected override BinAff.Core.Data GetComponentData(Int64 reportId)
        {
            return new Crystal.Lodge.Component.RoomReservationReport.Data
            {
                Id = reportId
            };
        }

        protected override BinAff.Core.Data CreateDataObject(long id, ArtfComp.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

    }

}
