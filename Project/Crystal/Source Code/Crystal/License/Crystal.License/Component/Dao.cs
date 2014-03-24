using System;
using System.Data;

namespace Crystal.License.Component
{

    internal class Dao : BinAff.Core.Dao
    {

        internal Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "License.ComponentInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "License.ComponentRead";
            base.ReadAllStoredProcedure = "License.ComponentReadAll";
            base.UpdateStoredProcedure = "License.ComponentUpdate";
            base.NumberOfRowsAffectedInUpdate = 1;
            base.DeleteStoredProcedure = "License.ComponentDelete";
            base.NumberOfRowsAffectedInDelete = 1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@Code", DbType.String, ((Data)this.Data).Code);
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@Description", DbType.String, ((Data)this.Data).Description);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = (Data)data;

            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.Code = Convert.IsDBNull(dr["Code"]) ? String.Empty : Convert.ToString(dr["Code"]);
            dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
            dt.Description = Convert.IsDBNull(dr["Description"]) ? String.Empty : Convert.ToString(dr["Description"]);
            dt.IsForm = Convert.IsDBNull(dr["IsForm"]) ? false : Convert.ToBoolean(dr["IsForm"]);
            dt.IsReport = Convert.IsDBNull(dr["IsReport"]) ? false : Convert.ToBoolean(dr["IsReport"]);
            dt.IsCatalogue = Convert.IsDBNull(dr["IsCatalogue"]) ? false : Convert.ToBoolean(dr["IsCatalogue"]);
            return data;
        }
        
        //protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        //{
        //    Data dt = (Data)data;
        //    DataRow row;
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        row = ds.Tables[0].Rows[0];
        //        dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
        //        dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
        //        dt.Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]);  
        //    }
        //    return dt;
        //}

    }

}
