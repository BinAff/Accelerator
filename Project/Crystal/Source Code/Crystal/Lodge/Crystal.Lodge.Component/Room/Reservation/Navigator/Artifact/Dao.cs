using System;
using System.Data;

using BinAff.Core;

using ArtfCrys = Crystal.Navigator.Component.Artifact;

namespace Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact
{

    public class Dao : ArtfCrys.Dao
    {

        private String deleteArtifactLinkSPName;

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            this.deleteArtifactLinkSPName = "[Lodge].[DeleteReservationFormForArtifact]";
        }

        protected override Boolean ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand("[Lodge].[ReadReservationFormForArtifact]");
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);
            base.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();

            Int64 custId = Convert.IsDBNull(ds.Tables[0].Rows[0]["RoomReservationId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["RoomReservationId"]);
            if (custId > 0)
            {
                (this.Data as Data).ComponentData = new Room.Reservation.Data
                {
                    Id = custId
                };
            }
            return true;
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, ArtfCrys.Category category)
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
            base.CreateCommand("[Lodge].[InsertReservationFormForArtifact]");
            if (artifactData.ComponentData.Id == 0)
            {
                base.AddInParameter("@ReservationId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@ReservationId", DbType.Int64, artifactData.ComponentData.Id);
            }
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            return status;
        }

        protected override Boolean DeleteBefore()
        {
            return this.DeleteArtifactLink();
        }

        public Boolean DeleteArtifactLink()
        {
            Boolean status = true;
            base.CreateCommand(this.deleteArtifactLinkSPName);
            base.AddInParameter("@Id", DbType.Int64, this.Data.Id);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation
            base.CloseConnection();
            return status;
        }

        protected override ReturnObject<Boolean> UpdateArtifactModuleLink()
        {
            Boolean status = true;
            Data artifactData = Data as Data;

            base.CreateCommand("[Lodge].[UpdateReservationFormForArtifact]");
            base.AddInParameter("@ReservationId", DbType.Int64, artifactData.ComponentData.Id);
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            return new ReturnObject<Boolean> { Value = status };
        }

    }

}
