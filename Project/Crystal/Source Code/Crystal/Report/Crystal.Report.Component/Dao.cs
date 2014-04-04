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
            base.AddInParameter("@From", DbType.DateTime, ((Data)this.Data).FromDate);
            base.AddInParameter("@To", DbType.DateTime, ((Data)this.Data).ToDate);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                dt.Id = data.Id;
                dt.FromDate = Convert.IsDBNull(row["Start"]) ? DateTime.MinValue : Convert.ToDateTime(row["Start"]);
                dt.ToDate = Convert.IsDBNull(row["End"]) ? DateTime.MinValue : Convert.ToDateTime(row["End"]);
            }
            return dt;
        }

        protected override List<BinAff.Core.Data> CreateDataObjectList(DataSet ds)
        {
            List<BinAff.Core.Data> ret = new List<BinAff.Core.Data>();
            return ret;
        }
    }
}
