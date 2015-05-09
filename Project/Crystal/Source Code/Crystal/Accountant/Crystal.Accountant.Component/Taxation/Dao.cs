using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Accountant.Component.Tax
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Accountant.TaxInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Accountant.TaxRead";
            base.ReadAllStoredProcedure = "Accountant.TaxReadAll";
            base.UpdateStoredProcedure = "Accountant.TaxUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Accountant.TaxDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        { 
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@Amount", DbType.Double, ((Data)this.Data).Amount);
            base.AddInParameter("@IsPercentage", DbType.Boolean, ((Data)this.Data).IsPercentage);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
                dt.Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]);
                dt.IsPercentage = Convert.IsDBNull(row["isPercentage"]) ? false : Convert.ToBoolean(row["isPercentage"]);               
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
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDouble(row["Amount"]),
                        IsPercentage = Convert.IsDBNull(row["isPercentage"]) ? false : Convert.ToBoolean(row["isPercentage"])
                    });
                }
            }
            return ret;
        }

        internal Boolean ReadDuplicate()
        {
            Data data = (Data)this.Data;
            this.CreateConnection();
            this.CreateCommand("Accountant.TaxReadDuplicate");
            this.AddInParameter("@Name", DbType.String, data.Name);

            DataSet ds = this.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(dr["Id"]) && Convert.ToInt64(dr["Id"]) != this.Data.Id) return true;
                }
            }

            return false;
        }
    }

}
