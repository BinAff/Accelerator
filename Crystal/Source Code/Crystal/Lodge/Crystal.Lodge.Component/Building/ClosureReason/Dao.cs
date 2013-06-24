using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Lodge.Component.Building.ClosureReason
{
    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Lodge].[BuildingClosureReasonInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[BuildingClosureReasonRead]";
            base.ReadForParentStoredProcedure = "[Lodge].[BuildingClosureReasonReadForParent]";
            base.UpdateStoredProcedure = "[Lodge].[BuildingClosureReasonUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Lodge].[BuildingClosureReasonDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Reason", System.Data.DbType.String, ((Data)this.Data).Reason);
            base.AddInParameter("@BuildingId", System.Data.DbType.String, this.ParentData.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            System.Data.DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Reason = Convert.IsDBNull(row["Reason"]) ? String.Empty : Convert.ToString(row["Reason"]);
                dt.ClosedDate = Convert.IsDBNull(row["ClosedDate"]) ? DateTime.MaxValue : Convert.ToDateTime(row["ClosedDate"]);  
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
                        Reason = Convert.IsDBNull(row["Reason"]) ? String.Empty : Convert.ToString(row["Reason"]),
                        ClosedDate = Convert.IsDBNull(row["ClosedDate"]) ? DateTime.MaxValue : Convert.ToDateTime(row["ClosedDate"])
                    });
                }
            }
            return ret;
        }

        public override List<BinAff.Core.Data> ReadAll()
        {
            this.CreateConnection();
            this.CreateCommand("[Lodge].[BuildingClosureReasonReadAll]");

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> dataList = CreateDataObjectList(ds);
            this.CloseConnection();

            return dataList;
        }

        protected override void AttachChildDataToParent()
        {
            ((Lodge.Component.Building.Data)this.ParentData).ClosureReasonList = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Lodge.Component.Building.Data)this.ParentData).ClosureReasonList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Lodge.Component.Building.Data)this.ParentData).ClosureReasonList.Add((Data)data);
                }
            }

        }

    }
}
