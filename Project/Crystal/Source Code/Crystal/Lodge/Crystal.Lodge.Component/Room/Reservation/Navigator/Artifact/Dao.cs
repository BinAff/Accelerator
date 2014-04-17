using System;
using System.Data;

namespace Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact
{

    public class Dao : Crystal.Navigator.Component.Artifact.Dao
    {

        private String DeleteArtifactLinkSPName;

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.Compose();
            this.DeleteArtifactLinkSPName = "[Lodge].[DeleteReservationFormForArtifact]";
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
