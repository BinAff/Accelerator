using System;
using System.Data;
using System.Collections.Generic;

using UnitCrys = Crystal.Organization.Component.Unit;

namespace Retinue.Lodge.Component.Building
{

    public class Dao : Crystal.Organization.Component.Unit.Dao
    {

        public Dao(Data data)
            : base(data) 
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Lodge].[BuildingInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Lodge].[BuildingRead]";
            base.ReadAllStoredProcedure = "[Lodge].[BuildingReadAll]";
            base.UpdateStoredProcedure = "[Lodge].[BuildingUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Lodge].[BuildingDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        public override List<UnitCrys.Data> IsStatusDeletable(UnitCrys.Status.Data status)
        {
            List<UnitCrys.Data> dataList = new List<UnitCrys.Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsBuildingStatusDeletable]");
            this.AddInParameter("@StatusId", DbType.Int64, status.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Status = new UnitCrys.Status.Data()
                        {
                            Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"]),
                        }
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public override List<UnitCrys.Data> IsTypeDeletable(UnitCrys.Type.Data type)
        {
            List<UnitCrys.Data> dataList = new List<UnitCrys.Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsBuildingTypeDeletable]");
            this.AddInParameter("@TypeId", DbType.Int64, type.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"])
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public override List<UnitCrys.Data> IsOrganizationDeletable(Crystal.Organization.Component.Data organization)
        {
            List<UnitCrys.Data> dataList = new List<UnitCrys.Data>();
            this.CreateConnection();
            this.CreateCommand("[Lodge].[IsBuildingDeletable]");
            this.AddInParameter("@OrganizationId", DbType.Int64, organization.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Status = new UnitCrys.Status.Data
                        {
                            Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"]),
                        }
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public override Boolean ModifyStatus(Int64 StatusId)
        {
            Boolean retVal = true;
            Data data = (Data)this.Data;

            base.CreateConnection();
            this.CreateCommand("[Lodge].[BuildingModifyStatus]");
            this.AddInParameter("@Id", DbType.Int64, this.Data.Id);
            this.AddInParameter("@StatusId", DbType.Int64, StatusId);
            Int32 ret = this.ExecuteNonQuery();
            base.CloseConnection();

            if (ret == -2146232060)
                retVal = false;//Foreign key violation
            else
                retVal = ret == this.NumberOfRowsAffectedInDelete || this.NumberOfRowsAffectedInDelete == -1;

            return retVal;
        }
        
    }

}