
using System;
using System.Data;

using CrystalNavigator = Crystal.Navigator.Component;

namespace Crystal.Lodge.Component.Room.CheckIn.Navigator.Artifact
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
            this.DeleteArtifactLinkSPName = "[Lodge].[DeleteCheckInFormForArtifact]";
        }

        protected override bool ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand("[Lodge].[ReadCheckInFormForArtifact]");
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);
            base.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();

            Int64 custId = Convert.IsDBNull(ds.Tables[0].Rows[0]["CheckInId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["CheckInId"]);
            if (custId > 0)
            {
                (this.Data as Data).ModuleData = new Crystal.Lodge.Component.Room.CheckIn.Data
                {
                    Id = custId
                };
            }
            return true;
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, Crystal.Navigator.Component.Artifact.Category category)
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
            base.CreateCommand("[Lodge].[InsertCheckInFormForArtifact]");
            if (artifactData.ModuleData.Id == 0)
            {
                base.AddInParameter("@CheckInId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@CheckInId", DbType.Int64, artifactData.ModuleData.Id);
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
