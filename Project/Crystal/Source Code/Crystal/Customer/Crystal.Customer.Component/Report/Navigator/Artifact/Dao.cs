using System;
using CrystalNavigator = Crystal.Navigator.Component;
using System.Data;

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
            this.CreateComponentLinkSPName = "Customer.InsertCustomerReportForArtifact";
            this.ReadComponentLinkSPName = "Customer.ReadCustomerReportForArtifact";
            this.DeleteComponentLinkSPName = "Customer.DeleteCustomerReportForArtifact";
        }

        protected override BinAff.Core.Data GetComponentData(Int64 reportId)
        {
            return new Customer.Component.Report.Data
            {
                Id = reportId
            };
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, CrystalNavigator.Artifact.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

    }

}
