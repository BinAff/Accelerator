using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Report.Component
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
            base.AddInParameter("@Date", DbType.DateTime, ((Data)this.Data).Date);
            base.AddInParameter("@CategoryId", DbType.Int64, ((Data)this.Data).Category.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.Date = Convert.IsDBNull(row["Date"]) ? DateTime.MinValue : Convert.ToDateTime(row["Date"]);
                dt.Category = Convert.IsDBNull(row["ReportCategoryId"]) ? null : new Category.Data { Id = Convert.ToInt64(row["ReportCategoryId"]) };                
            }
            return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();
            return ret;
        }

        public abstract List<BinAff.Core.Data> GetData(DateTime fromDate, DateTime toDate);

    }

}
