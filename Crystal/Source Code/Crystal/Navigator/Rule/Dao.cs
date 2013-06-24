using System;
using System.Data;

namespace Crystal.Navigator.Rule
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "NavigatorRuleInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "NavigatorRuleRead";
            base.UpdateStoredProcedure = "NavigatorRuleUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@ModuleSeperator", DbType.String, ((Data)this.Data).ModuleSeperator);
            base.AddInParameter("@PathSeperator", DbType.String, ((Data)this.Data).PathSeperator);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.ModuleSeperator = Convert.IsDBNull(row["ModuleSeperator"]) ? String.Empty : Convert.ToString(row["ModuleSeperator"]);
                dt.PathSeperator = Convert.IsDBNull(row["PathSeperator"]) ? String.Empty : Convert.ToString(row["PathSeperator"]);  
            }
            return dt;
        }
   
    }

}
