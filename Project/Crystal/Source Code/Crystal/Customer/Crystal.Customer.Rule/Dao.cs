using System;
using System.Data;

namespace Crystal.Customer.Rule
{
    public class Dao : BinAff.Core.Dao
    {
        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Customer.RuleInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Customer.RuleRead";
            base.UpdateStoredProcedure = "Customer.RuleUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            base.AddInParameter("@IsPinNumber", DbType.Boolean, ((Data)this.Data).IsPinNumber);
            base.AddInParameter("@IsAlternateContactNumber", DbType.Boolean, ((Data)this.Data).IsAlternateContactNumber);
            base.AddInParameter("@IsEmail", DbType.Boolean, ((Data)this.Data).IsEmail);
            base.AddInParameter("@IsIdentityProof", DbType.Boolean, ((Data)this.Data).IsIdentityProof);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                dt.IsPinNumber = Convert.IsDBNull(row["IsPinNo"]) ? false : Convert.ToBoolean(row["IsPinNo"]);
                dt.IsAlternateContactNumber = Convert.IsDBNull(row["IsAlternateContactNo"]) ? false : Convert.ToBoolean(row["IsAlternateContactNo"]);
                dt.IsEmail = Convert.IsDBNull(row["IsEmail"]) ? false : Convert.ToBoolean(row["IsEmail"]);
                dt.IsIdentityProof = Convert.IsDBNull(row["IsIdentityProof"]) ? false : Convert.ToBoolean(row["IsIdentityProof"]);
            }
            return dt;
        }
    }
}
