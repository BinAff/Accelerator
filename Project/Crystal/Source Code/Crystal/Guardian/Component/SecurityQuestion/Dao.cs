using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Guardian.Component.SecurityQuestion
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data) 
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "[Gaurdian].SecurityQuestionInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "[Gaurdian].SecurityQuestionRead";
            base.ReadAllStoredProcedure = "[Gaurdian].SecurityQuestionReadAll";
            base.UpdateStoredProcedure = "[Gaurdian].SecurityQuestionUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "[Gaurdian].SecurityQuestionDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@Question", DbType.String, ((Data)this.Data).Question);              
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];

                //dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Question = Convert.IsDBNull(row["Question"]) ? String.Empty : Convert.ToString(row["Question"]);
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
                    ret.Add(new Data
                    {
                        Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]),
                        Question = Convert.IsDBNull(row["Question"]) ? String.Empty : Convert.ToString(row["Question"])
                    });
                }
            }
            return ret;
        }

        internal Boolean ReadDuplicate()
        {
            Data data = (Data)this.Data;
            this.CreateConnection();
            this.CreateCommand("[Gaurdian].SecurityQuestionReadDuplicate");
            this.AddInParameter("@Name", DbType.String, data.Question);

            DataSet ds = this.ExecuteDataSet();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(dr["Id"]) && Convert.ToInt64(dr["Id"]) != this.Data.Id) return true;
                }
            }

            return false;
        }
    }

}
