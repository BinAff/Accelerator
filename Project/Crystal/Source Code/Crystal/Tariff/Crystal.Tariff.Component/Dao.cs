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

        protected override void AssignParameter(String procedureName)
        {
            Data data = this.Data as Data;
            base.AddInParameter("@StartDate", DbType.DateTime, (data).StartDate);
            base.AddInParameter("@EndDate", DbType.DateTime, (data).EndDate);
            base.AddInParameter("@IsExtra", DbType.Boolean, (data).IsExtra);
            base.AddInParameter("@Rate", DbType.Int64, (data).Rate);

            if (data.Product != null)
            {
                base.AddInParameter("@ItemId", DbType.Int64, data.Product.Id);
            }
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            //dt.Product = this.BindItem(Convert.IsDBNull(dr["ItemId"]) ? 0 : Convert.ToInt32(dr["ItemId"]));
            dt.StartDate = Convert.IsDBNull(dr["StartDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["StartDate"]);
            dt.EndDate = Convert.IsDBNull(dr["EndDate"]) ? DateTime.MinValue : Convert.ToDateTime(dr["EndDate"]);
            dt.IsExtra = Convert.IsDBNull(dr["IsExtra"]) ? false : Convert.ToBoolean(dr["IsExtra"]);
            dt.Rate = Convert.IsDBNull(dr["Rate"]) ? 0 : Convert.ToDouble(dr["Rate"]);
            return dt;
        }

        protected abstract Product.Component.Data BindItem(Int64 itemId);

        public abstract List<Data> IsProductDeletable(BinAff.Core.Data subject);

    }

}