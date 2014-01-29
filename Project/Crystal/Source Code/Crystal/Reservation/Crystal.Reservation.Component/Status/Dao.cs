using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Reservation.Component.Status
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Reservation].[StatusInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[RoomReservationStatusRead]";
            base.ReadAllStoredProcedure = "[Lodge].[RoomReservationStatusReadAll]";
            base.UpdateStoredProcedure = "[Reservation].[StatusUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Reservation].[StatusDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
            }
            return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ret.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"])
                    });
                }
            }
            return ret;
        }
       
    }

}
