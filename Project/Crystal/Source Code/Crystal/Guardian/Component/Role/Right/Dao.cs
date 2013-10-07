using System;
using System.Data;
using System.Collections.Generic;

namespace Crystal.Guardian.Component.Role.Right
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data)
        {

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "UserRightInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "UserRightRead";
            base.UpdateStoredProcedure = "UserRightUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "UserRightDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            base.AddInParameter("@Name", DbType.String, ((Data)this.Data).Name);
            base.AddInParameter("@Module", DbType.String, ((Data)this.Data).Module);
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
                        Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]),
                        Module = Convert.IsDBNull(row["Module"]) ? String.Empty : Convert.ToString(row["Module"]),
                    });
                }
            }
            return ret;
        }

    }

}
