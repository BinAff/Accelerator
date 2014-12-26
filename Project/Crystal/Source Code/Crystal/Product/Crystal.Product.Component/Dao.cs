using System;
using System.Data;

namespace Crystal.Product.Component
{

    public abstract class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Number", DbType.String, ((Data)this.Data).Number);
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@Description", DbType.String, ((Data)this.Data).Description);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Number = Convert.IsDBNull(dr["Number"]) ? String.Empty : Convert.ToString(dr["Number"]);
            dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
            dt.Description = Convert.IsDBNull(dr["Description"]) ? String.Empty : Convert.ToString(dr["Description"]);
            return dt;
        }

    }

}
