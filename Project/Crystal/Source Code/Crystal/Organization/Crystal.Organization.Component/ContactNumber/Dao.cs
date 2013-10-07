using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Organization.Component.ContactNumber
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Organization].[ContactNumberInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Organization].[ContactNumberRead]";
            base.ReadForParentStoredProcedure = "[Organization].[ContactNumberReadForParent]";
            base.ReadAllStoredProcedure = "ContactNumberReadAll";
            base.UpdateStoredProcedure = "ContactNumberUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Organization].[ContactNumberDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);

            base.AddInParameter("@OrganizationId", DbType.Int64, this.ParentData.Id);
            base.AddInParameter("@ContactNumber", DbType.String, ((Data)this.Data).ContactNumber);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.ContactNumber = Convert.IsDBNull(row["ContactNumber"]) ? String.Empty : Convert.ToString(row["ContactNumber"]);
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
                        ContactNumber = Convert.IsDBNull(row["ContactNumber"]) ? String.Empty : Convert.ToString(row["ContactNumber"])

                    });
                }
            }
            return ret;
        }

        protected override void AttachChildDataToParent()
        {
            ((Organization.Component.Data)this.ParentData).ContactNumberList = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Organization.Component.Data)this.ParentData).ContactNumberList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Organization.Component.Data)this.ParentData).ContactNumberList.Add((Data)data);
                }
            }

        }
    }
}
