using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Organization.Component.Fax
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Organization].[FaxInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Organization].[FaxRead]";
            base.ReadForParentStoredProcedure = "[Organization].[FaxReadForParent]";
            base.ReadAllStoredProcedure = "FaxReadAll";
            base.UpdateStoredProcedure = "FaxUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Organization].[FaxDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);

            base.AddInParameter("@OrganizationId", DbType.Int64, this.ParentData.Id);
            base.AddInParameter("@Fax", DbType.String, ((Data)this.Data).Fax);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Fax = Convert.IsDBNull(row["Fax"]) ? String.Empty : Convert.ToString(row["Fax"]);
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
                        Fax = Convert.IsDBNull(row["Fax"]) ? String.Empty : Convert.ToString(row["Fax"])

                    });
                }
            }
            return ret;
        }

        protected override void AttachChildDataToParent()
        {
            ((Organization.Component.Data)this.ParentData).FaxList = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Organization.Component.Data)this.ParentData).FaxList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Organization.Component.Data)this.ParentData).FaxList.Add((Data)data);
                }
            }

        }
    }
}
