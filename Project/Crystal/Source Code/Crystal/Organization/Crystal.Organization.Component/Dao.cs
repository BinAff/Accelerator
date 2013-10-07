using System;
using System.Data;
using System.Collections.Generic;

namespace Crystal.Organization.Component
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Organization].[OrganizationInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Organization].[OrganizationRead]";
            base.ReadAllStoredProcedure = "OrganizationReadAll";
            base.UpdateStoredProcedure = "[Organization].[OrganizationUpdate]";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Organization].[OrganizationDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@Logo", DbType.Binary, (object)(((Data)this.Data).Logo));
            base.AddInParameter("@LicenceNumber", DbType.String, ((Data)this.Data).LicenceNumber);
            base.AddInParameter("@Tan", DbType.String, ((Data)this.Data).Tan);
            base.AddInParameter("@Address", DbType.String, ((Data)this.Data).Address);
            base.AddInParameter("@City", DbType.String, ((Data)this.Data).City);
            base.AddInParameter("@StateId", DbType.String, ((Data)this.Data).State.Id);
            base.AddInParameter("@Pin", DbType.Int32, ((Data)this.Data).Pin);
            base.AddInParameter("@ContactName", DbType.String, ((Data)this.Data).ContactName);
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
                dt.Logo = Convert.IsDBNull(row["Logo"]) ? null : (Byte[])row["Logo"];
                dt.LicenceNumber = Convert.IsDBNull(row["LicenceNumber"]) ? String.Empty : Convert.ToString(row["LicenceNumber"]);
                dt.Tan = Convert.IsDBNull(row["Tan"]) ? String.Empty : Convert.ToString(row["Tan"]);
                dt.Address = Convert.IsDBNull(row["Address"]) ? String.Empty : Convert.ToString(row["Address"]);
                dt.City = Convert.IsDBNull(row["City"]) ? String.Empty : Convert.ToString(row["City"]);
                dt.State = Convert.IsDBNull(row["StateId"]) ? null : new Crystal.Configuration.Component.State.Data
                {
                    Id = Convert.ToInt64(row["StateId"])
                };
                dt.Pin = Convert.IsDBNull(row["Pin"]) ? 0 : Convert.ToInt32(row["Pin"]);
                dt.ContactName = Convert.IsDBNull(row["ContactName"]) ? String.Empty : Convert.ToString(row["ContactName"]);
            }
            return dt;
        }

        internal List<Data> IsStateDeletable(Configuration.Component.State.Data state)
        {
            List<Data> dataList = new List<Data>();
            this.CreateConnection();
            this.CreateCommand("[Organization].[IsStateIdDeletable]");
            this.AddInParameter("@StateId", DbType.Int64, state.Id);
            DataSet ds = this.ExecuteDataSet();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataList.Add(new Data
                    {
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),                       
                    });
                }
            }

            this.CloseConnection();
            return dataList;
        }
    }
}
