using System;
using CrystalNavigator = Crystal.Navigator.Component;
using System.Data;

namespace Crystal.Invoice.Component.Report.Navigator.Artifact
{
    public class Dao : CrystalNavigator.Artifact.Dao
    {
        private String DeleteArtifactLinkSPName;

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            this.DeleteArtifactLinkSPName = "[Invoice].[DeleteInvoiceReportForArtifact]";
        }

        protected override Boolean ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand("[Invoice].[ReadInvoiceReportForArtifact]");
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);
            base.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Int64 reportId = Convert.IsDBNull(ds.Tables[0].Rows[0]["ReportId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["ReportId"]);
                if (reportId > 0)
                {
                    (this.Data as Data).ComponentData = new Invoice.Component.Report.Data
                    {
                        Id = reportId
                    };
                }
            }
            return true;
        }

        protected override BinAff.Core.Data CreateDataObject(long id, CrystalNavigator.Artifact.Category category)
        {
            return new Data
            {
                Id = id,
                Category = category,
            };
        }

        protected override Boolean CreateAfterModuleArtifactLink()
        {
            Boolean status = true;

            Data artifactData = Data as Data;
            base.CreateCommand("[Invoice].[InsertInvoiceReportForArtifact]");
            if (artifactData.ComponentData.Id == 0)
            {
                base.AddInParameter("@ReportId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@ReportId", DbType.Int64, artifactData.ComponentData.Id);
            }
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            return status;
        }

        protected override bool DeleteBefore()
        {
            return this.DeleteArtifactLink();
        }

        public bool DeleteArtifactLink()
        {
            Boolean status = true;
            base.CreateCommand(this.DeleteArtifactLinkSPName);
            base.AddInParameter("@Id", DbType.Int64, this.Data.Id);

            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            base.CloseConnection();

            return status;

        }
    }
}
