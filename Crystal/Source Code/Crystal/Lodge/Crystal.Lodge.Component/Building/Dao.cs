using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Lodge.Component.Building
{

    public class Dao : BinAff.Core.Dao
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

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@TypeId", DbType.Int32, ((Data)this.Data).Type.Id);
            base.AddInParameter("@StatusId", DbType.Int32, ((Data)this.Data).Status == null ? 0 : ((Data)this.Data).Status.Id);
            //base.AddInParameter("@OrganizationId", DbType.Int32, ((Data)this.Data).Organization.Id);
            
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
                dt.Type = new Type.Data()
                {
                    Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt64(row["TypeId"])
                };
                dt.Status = new Status.Data()
                {
                    Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"])
                };
                //dt.Organization = new Organization.Component.Data()
                //{
                //    Id = Convert.IsDBNull(row["OrganizationId"]) ? 0 : Convert.ToInt64(row["OrganizationId"])
                //};
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
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Type = new Type.Data()
                        {
                            Id = Convert.IsDBNull(row["TypeId"]) ? 0 : Convert.ToInt64(row["TypeId"])
                        },
                        Status = new Status.Data()
                        {
                            Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"])
                        },
                        //Organization = new Organization.Component.Data()
                        //{
                        //    Id = Convert.IsDBNull(row["OrganizationId"]) ? 0 : Convert.ToInt64(row["OrganizationId"])
                        //},
                    });
                }
            }
            return ret;
        }

        public Boolean ModifyStatus(Int64 StatusId)
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
               
        public List<Data> IsOrganizationDeletable(Crystal.Organization.Component.Data organization)
        {
            List<Data> dataList = new List<Data>();
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
                        Status = new Status.Data(){
                            Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"]),
                        }                           
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> IsStatusDeletable(Crystal.Lodge.Component.Building.Status.Data status)
        {
            List<Data> dataList = new List<Data>();
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
                        Status = new Status.Data()
                        {
                            Id = Convert.IsDBNull(row["StatusId"]) ? 0 : Convert.ToInt64(row["StatusId"]),
                        }
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }

        public List<Data> IsTypeDeletable(Crystal.Lodge.Component.Building.Type.Data type)
        {
            List<Data> dataList = new List<Data>();
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
        
    }

}
