using System;
using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Lodge.Component.CheckInReport.Navigator.Artifact
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
            base.CreateComponentLinkSPName = "[Lodge].[InsertCheckInReportForArtifact]";
            base.ReadComponentLinkSPName = "[Lodge].[ReadCheckInReportForArtifact]";
            base.DeleteComponentLinkSPName = "[Lodge].[DeleteCheckInReportForArtifact]";
        }

        protected override BinAff.Core.Data GetComponentData(Int64 reportId)
        {
            return new Crystal.Lodge.Component.CheckInReport.Data
            {
                Id = reportId
            };
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, ArtfComp.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

    }

}
