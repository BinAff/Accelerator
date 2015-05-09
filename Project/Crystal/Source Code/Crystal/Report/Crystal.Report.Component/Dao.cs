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
            base.AddInParameter("@Date", DbType.DateTime, (this.Data as Data).Date);
            base.AddInParameter("@CategoryId", DbType.Int64, (this.Data as Data).Category.Id);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            dt.Id = data.Id;
            dt.Date = Convert.IsDBNull(dr["Date"]) ? DateTime.MinValue : Convert.ToDateTime(dr["Date"]);
            dt.Category = Convert.IsDBNull(dr["ReportCategoryId"]) ? null : new Category.Data { Id = Convert.ToInt64(dr["ReportCategoryId"]) };
            return dt;
        }

        public abstract List<BinAff.Core.Data> GetData(DateTime fromDate, DateTime toDate);

    }

}
