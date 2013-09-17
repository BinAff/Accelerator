using System;
using System.Collections.Generic;
using System.Data;

using GaurdianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data) 
            : base(data)
        {
            
        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Navigator.ArtifactInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "ArtifactRead";
            base.ReadAllStoredProcedure = "ArtifactReadAll";
            base.UpdateStoredProcedure = "ArtifactUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "ArtifactDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            Data data = this.Data as Data;
            base.AssignParameter(procedureName);
            //base.AddInParameter("@Question", DbType.String,data.Name;
            //base.AddInParameter("@Question", DbType.String, ((Data)this.Data).Question);
        }

        protected override BinAff.Core.Data CreateDataObject(DataSet ds, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            DataRow row;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                row = ds.Tables[0].Rows[0];
                
                dt.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt64(row["Id"]);
                dt.Name = Convert.IsDBNull(row["Name"]) ? String.Empty : Convert.ToString(row["Name"]);
                dt.FileName = Convert.IsDBNull(row["FileName"]) ? String.Empty : Convert.ToString(row["FileName"]);
                dt.Path = Convert.IsDBNull(row["Path"]) ? String.Empty : Convert.ToString(row["Path"]);
                dt.Style = Convert.IsDBNull(row["Style"]) ? Artifact.Data.Type.Directory : (Artifact.Data.Type)(row["Style"]);
                dt.Version = Convert.IsDBNull(row["Version"]) ? 0 : Convert.ToInt32(row["Version"]);
                dt.CreatedBy = new GaurdianAcc.Data
                {
                    Id = Convert.IsDBNull(row["CreatedByUserId"]) ? 0 : Convert.ToInt64(row["CreatedByUserId"])
                };
                dt.ModifiedBy = new GaurdianAcc.Data
                {
                    Id = Convert.IsDBNull(row["ModifiedByUserId"]) ? 0 : Convert.ToInt64(row["ModifiedByUserId"])
                };
                dt.CreatedAt = Convert.IsDBNull(row["CreatedAt"]) ? DateTime.MinValue : Convert.ToDateTime(row["CreatedAt"]);
                dt.ModifiedAt = Convert.IsDBNull(row["ModifiedAt"]) ? DateTime.MinValue : Convert.ToDateTime(row["ModifiedAt"]);
                dt.ParentId = Convert.IsDBNull(row["ParentId"]) ? 0 : Convert.ToInt64(row["ParentId"]);
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
                        //Question = Convert.IsDBNull(row["Question"]) ? String.Empty : Convert.ToString(row["Question"])
                    });
                }
            }
            return ret;
        }
       
    }

}
