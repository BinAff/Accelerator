using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Report.Component.Category
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.ReadStoredProcedure = "Report.CategoryRead";
            base.ReadAllStoredProcedure = "Report.CategoryReadAll";
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
                        Extension = Convert.IsDBNull(row["Extension"]) ? String.Empty : Convert.ToString(row["Extension"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                    });
                }
            }
            return ret;
        }

    }

}
