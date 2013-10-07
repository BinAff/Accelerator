using System;
using System.Data;

namespace Crystal.Guardian.Rule
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "RuleUserInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "RuleUserRead";            
            base.UpdateStoredProcedure = "RuleUserUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@DefaultUserPwd", DbType.String, ((Data)this.Data).DefaultUserPassword);            
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.DefaultUserPassword = Convert.IsDBNull(row["DefaultPassword"]) ? String.Empty : Convert.ToString(row["DefaultPassword"]);              
            }
            return dt;
        }
   
    }

}
