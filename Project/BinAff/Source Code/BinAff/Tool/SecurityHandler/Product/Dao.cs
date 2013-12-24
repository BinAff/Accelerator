using System;
using System.Collections.Generic;
using System.Data;

namespace BinAff.Tool.SecurityHandler.Product
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            this.ReadStoredProcedure = "ProjectRead";
            this.ReadAllStoredProcedure = "ProjectReadAll";
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
                        Code = Convert.IsDBNull(row["Code"]) ? String.Empty : Convert.ToString(row["Code"]),
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Description = Convert.IsDBNull(row["Description"]) ? String.Empty : Convert.ToString(row["Description"]),
                    });
                }
            }
            return ret;
        }

        protected override Core.Data CreateDataObject(DataRow dr, Core.Data data)
        {
            Data dt = (Data)data;
            dt.Id = data.Id;
            dt.Code = Convert.IsDBNull(dr["Code"]) ? String.Empty : Convert.ToString(dr["Code"]);
            dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
            dt.Description = Convert.IsDBNull(dr["Description"]) ? String.Empty : Convert.ToString(dr["Description"]);
            return dt;
        }

    }

}
