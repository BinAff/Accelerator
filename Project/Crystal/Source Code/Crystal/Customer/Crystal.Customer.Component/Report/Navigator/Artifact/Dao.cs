using System;
using ArtfComp = Crystal.Navigator.Component.Artifact;

namespace Crystal.Customer.Component.Report.Navigator.Artifact
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
            base.CreateComponentLinkSPName = "Customer.CustomerReportArtifactInsertLink";
            base.ReadComponentLinkSPName = "Customer.ReadCustomerReportForArtifact";
            base.DeleteComponentLinkSPName = "Customer.DeleteCustomerReportForArtifact";
        }

        protected override BinAff.Core.Data GetComponentData(Int64 reportId)
        {
            return new Customer.Component.Report.Data
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
