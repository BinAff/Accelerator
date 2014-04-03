using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Diary.Component
{

    public class Dao // : BinAff.Core.Dao
    {

        //public Dao(Data data)
        //    : base(data) 
        //{ 

        //}

        //protected override void Compose()
        //{
        //    base.CreateStoredProcedure = "Utility.DiaryInsert";
        //    base.NumberOfRowsAffectedInCreate = -1;
        //    base.ReadStoredProcedure = "Utility.DiaryRead";
        //    base.ReadAllStoredProcedure = "Utility.DiaryReadAll";
        //    base.UpdateStoredProcedure = "Utility.DiaryUpdate";
        //    base.NumberOfRowsAffectedInUpdate = -1;
        //    base.DeleteStoredProcedure = "Utility.DiaryDelete";
        //    base.NumberOfRowsAffectedInDelete = -1;
        //}

        //protected override void AssignParameter(string procedureName)
        //{
        //    base.AddInParameter("@UserId", DbType.String, ((Data)this.Data).User.Id);
        //}

        //protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        //{
        //    Data dt = (Data)data;
        //    DataRow row;
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        row = ds.Tables[0].Rows[0];

        //        dt.Id = data.Id;
        //        dt.User = new Guardian.Component.Account.Data
        //        {
        //            Id = Convert.IsDBNull(row["UserId"]) ? 0 : Convert.ToInt64(row["UserId"])
        //        };
        //    }
        //    return dt;
        //}

        //protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        //{
        //    List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            ret.Add(new Data
        //            {
        //                Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
        //                User = new Guardian.Component.Account.Data
        //                {
        //                    Id = Convert.IsDBNull(row["UserId"]) ? 0 : Convert.ToInt64(row["UserId"])
        //                },
        //            });
        //        }
        //    }
        //    return ret;
        //}

        //internal Boolean ReadDuplicate()
        //{
        //    Data data = (Data)this.Data;
        //    this.CreateConnection();
        //    this.CreateCommand("[Configuration].IdentityProofTypeReadDuplicate");
        //    this.AddInParameter("@Name", DbType.String, data.Name);

        //    DataSet ds = this.ExecuteDataSet();           

        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            if (!Convert.IsDBNull(dr["Id"]) && Convert.ToInt64(dr["Id"]) != this.Data.Id) return true;
        //        }
        //    }

        //    return false;
        //}

    }

}
