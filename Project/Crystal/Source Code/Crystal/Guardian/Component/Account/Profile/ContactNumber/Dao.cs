using System;
using System.Data;
using System.Collections.Generic;

namespace Crystal.Guardian.Component.Account.Profile.ContactNumber
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Guardian.ProfileContactNumberInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Guardian.ProfileContactNumberRead";
            base.ReadForParentStoredProcedure = "Guardian.ProfileContactNumberRead";
            base.UpdateStoredProcedure = "Guardian.ProfileContactNumberUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Guardian.ProfileContactNumberDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AssignParameter(procedureName);

            base.AddInParameter("@UserId", DbType.Int64, ((Data)this.Data).UserId);           
            base.AddInParameter("@ContactNumber", DbType.String, ((Data)this.Data).ContactNumber);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = this.ParentData.Id;
                dt.UserId = Convert.IsDBNull(row["UserId"]) ? 0 : Convert.ToInt64(row["UserId"]); ;
                dt.ContactNumber = Convert.IsDBNull(row["ContactNumber"]) ? String.Empty : Convert.ToString(row["ContactNumber"]);
               
            }
            this.Data = dt;
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
                        UserId = Convert.IsDBNull(row["UserId"]) ? 0 : Convert.ToInt64(row["UserId"]),
                        ContactNumber = Convert.IsDBNull(row["ContactNumber"]) ? String.Empty : Convert.ToString(row["ContactNumber"])
                    
                    });
                }
            }
            return ret;
        }
        
        protected override void AttachChildDataToParent()
        {
            ((Profile.Data)this.ParentData).ContactNumberList = new List<BinAff.Core.Data> { (Data)this.Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                ((Profile.Data)this.ParentData).ContactNumberList = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    ((Profile.Data)this.ParentData).ContactNumberList.Add((Data)data);
                }
            }

        }

    }

}
