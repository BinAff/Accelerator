using System;
using System.Data;

namespace Crystal.Report.Component.Navigator.Artifact
{

    public abstract class Dao : Crystal.Navigator.Component.Artifact.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected abstract override BinAff.Core.Data CreateDataObject(long id, Crystal.Navigator.Component.Artifact.Category category);

        protected override Boolean CreateComponentLink()
        {
            Boolean status = true;

            Data artifactData = Data as Data;
            base.CreateCommand(this.CreateComponentLinkSPName);
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

        protected override Boolean ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand(this.ReadComponentLinkSPName);
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Int64 reportId = Convert.IsDBNull(ds.Tables[0].Rows[0]["ReportId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["ReportId"]);
                if (reportId > 0)
                {
                    (this.Data as Data).ComponentData = this.GetComponentData(reportId);
                }
            }
            return true;
        }

    }

}
