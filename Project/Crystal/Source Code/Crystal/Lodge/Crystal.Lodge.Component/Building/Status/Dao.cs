using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Lodge.Component.Building.Status
{
    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Lodge].[BuildingStatusInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[BuildingStatusRead]";
            base.UpdateStoredProcedure = "[Lodge].[BuildingStatusUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Lodge].[BuildingStatusDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Name", System.Data.DbType.String, ((Data)this.Data).Name);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            System.Data.DataRow row;
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

        public override List<BinAff.Core.Data> ReadAll()
        {
            this.CreateConnection();
            this.CreateCommand("[Lodge].[BuildingStatusReadAll]");

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> dataList = CreateDataObjectList(ds);
            this.CloseConnection();

            return dataList;
        }

    }
}
