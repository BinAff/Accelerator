using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Guardian.Component.Account.LoginHistory
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Guardian.LoginHistoryInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Guardian.LoginHistoryRead";
            base.ReadForParentStoredProcedure = "Guardian.LoginHistoryReadForParent";
            base.UpdateStoredProcedure = "Guardian.LoginHistoryUpdate";
            base.NumberOfRowsAffectedInUpdate = 1;
        }

        protected override void AssignParameter(string procedureName)
        {
            if (base.Data.Id == 0)
            {
                base.AddInParameter("@AccountId", DbType.String, this.ParentData.Id);
            }
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                    dt.LoginStamp = Convert.IsDBNull(row["LoginStamp"]) ? DateTime.MinValue : Convert.ToDateTime(row["LoginStamp"]);
                    dt.LogoutStamp = Convert.IsDBNull(row["LogoutStamp"]) ? DateTime.MinValue : Convert.ToDateTime(row["LogoutStamp"]);
                }
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
                        LoginStamp = Convert.IsDBNull(row["LoginStamp"]) ? DateTime.MinValue : Convert.ToDateTime(row["LoginStamp"]),
                        LogoutStamp = Convert.IsDBNull(row["LogoutStamp"]) ? DateTime.MinValue : Convert.ToDateTime(row["LogoutStamp"]),
                    });
                }
            }
            return ret;
        }

        protected override void AttachChildDataToParent()
        {
            (this.ParentData as Account.Data).LoginHistory = new List<BinAff.Core.Data> { this.Data as Data };
        }

        protected override void AttachChildrenDataToParent(List<BinAff.Core.Data> dataList)
        {
            if (dataList.Count > 0)
            {
                (this.ParentData as Account.Data).LoginHistory = new List<BinAff.Core.Data>();
                foreach (BinAff.Core.Data data in dataList)
                {
                    (this.ParentData as Account.Data).LoginHistory.Add(data as Data);
                }
            }
        }

    }

}
