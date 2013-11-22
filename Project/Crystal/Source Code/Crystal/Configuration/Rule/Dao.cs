using System;
using System.Data;

namespace Crystal.Configuration.Rule
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Configuration.RuleInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Configuration.RuleRead";
            //base.ReadStoredProcedure = "RuleConfigurationRead";
            base.UpdateStoredProcedure = "RuleConfigurationUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@DateFormat", DbType.String, ((Data)this.Data).DateFormat);            
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.DateFormat = Convert.IsDBNull(row["DateFormat"]) ? String.Empty : row["DateFormat"].ToString();                
            }
            return dt;
        }
    }
}
