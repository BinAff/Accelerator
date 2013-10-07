using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Product.Component
{

    public abstract class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected abstract override void Compose();

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Number", DbType.String, ((Data)this.Data).Number);
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@Description", DbType.String, ((Data)this.Data).Description);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Number = Convert.IsDBNull(row["Number"]) ? String.Empty : Convert.ToString(row["Number"]);
                dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
                dt.Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]);
            }
            return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        //Data data = this.CreateDataObject();
            //        //data.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
            //        //data.Product = this.BindItem(Convert.IsDBNull(row["ItemId"]) ? 0 : Convert.ToInt32(row["ItemId"]));
            //        //data.StartDate = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]);
            //        //data.EndDate = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"]);
            //        //data.Rate = Convert.IsDBNull(row["Rate"]) ? 0 : Convert.ToDouble(row["Rate"]);
            //        ret.Add(data);
            //    }
            //}
            return ret;
        }

        //protected abstract Product.Component.Data BindItem(Int64 itemId);
        //protected abstract Data CreateDataObject();

    }

}
