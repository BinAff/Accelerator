using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Tariff.Component
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
            base.AddInParameter("@Rate", DbType.Int64, ((Data)this.Data).Rate);
            base.AddInParameter("@StartDate", DbType.DateTime, ((Data)this.Data).StartDate);
            base.AddInParameter("@EndDate", DbType.DateTime, ((Data)this.Data).EndDate);

            if (((Data)this.Data).Product != null)
                base.AddInParameter("@ItemId", DbType.Int64, ((Data)this.Data).Product.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Product = this.BindItem(Convert.IsDBNull(row["ItemId"]) ? 0 : Convert.ToInt32(row["ItemId"]));                
                dt.StartDate = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]);
                dt.EndDate = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"]);
                dt.Rate = Convert.IsDBNull(row["Rate"]) ? 0 : Convert.ToDouble(row["Rate"]);
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
                    Data data = this.CreateDataObject();
                    data.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                    data.Product = this.BindItem(Convert.IsDBNull(row["ItemId"]) ? 0 : Convert.ToInt32(row["ItemId"]));
                    data.StartDate = Convert.IsDBNull(row["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["StartDate"]);
                    data.EndDate = Convert.IsDBNull(row["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["EndDate"]);
                    data.Rate = Convert.IsDBNull(row["Rate"]) ? 0 : Convert.ToDouble(row["Rate"]);
                    ret.Add(data);
                }
            }
            return ret;
        }

        protected abstract Product.Component.Data BindItem(Int64 itemId);
        protected abstract Data CreateDataObject();

        public abstract List<Data> IsProductDeletable(BinAff.Core.Data subject);

    }

}
