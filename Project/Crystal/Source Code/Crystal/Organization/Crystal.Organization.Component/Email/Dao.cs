using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Organization.Component.Email
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Organization].[EmailInsert]";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Organization].[EmailRead]";
            base.ReadForParentStoredProcedure = "[Organization].[EmailReadForParent]";
            base.ReadAllStoredProcedure = "EmailReadAll";
            base.UpdateStoredProcedure = "EmailUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Organization].[EmailDelete]";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);

            base.AddInParameter("@OrganizationId", DbType.Int64, this.ParentData.Id);
            base.AddInParameter("@Email", DbType.String, ((Data)this.Data).Email);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Email = Convert.IsDBNull(row["Email"]) ? String.Empty : Convert.ToString(row["Email"]);                
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
                        Email = Convert.IsDBNull(row["Email"]) ? String.Empty : Convert.ToString(row["Email"])

                    });
                }
            }
            return ret;
        }

        protected override void AttachChildDataToParent()
        {           
            ((Organization.Component.Data)this.ParentData).EmailList = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Organization.Component.Data)this.ParentData).EmailList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Organization.Component.Data)this.ParentData).EmailList.Add((Data)data);
                }
            }

        }
    }
}
