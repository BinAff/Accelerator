using System;
using System.Data;
using System.Collections.Generic;

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
            base.ReadStoredProcedure = "Navigator.ArtifactRead";
            base.ReadAllStoredProcedure = "Navigator.ArtifactReadAll";
            base.UpdateStoredProcedure = "Navigator.ArtifactUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Navigator.ArtifactDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(String procedureName)
        {
            Data data = this.Data as Data;
            base.AssignParameter(procedureName);
            base.AddInParameter("@FileName", DbType.String, data.FileName);
            base.AddInParameter("@ParentId", DbType.Int64, data.ParentId);
            if (data.Id == 0) //Insert, so only created information
            {
                base.AddInParameter("@CreatedByUserId", DbType.Int64, data.CreatedBy.Id);
                base.AddInParameter("@CreatedAt", DbType.DateTime, data.CreatedAt);
            }
            else //Update, so modification information
            {
                base.AddInParameter("@ModifiedByUserId", DbType.Int64, data.ModifiedBy.Id);
                base.AddInParameter("@ModifiedAt", DbType.DateTime, data.ModifiedAt);
            }
            base.AddInParameter("@Style", DbType.Int64, data.Style);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.FileName = Convert.IsDBNull(dr["FileName"]) ? String.Empty : Convert.ToString(dr["FileName"]);
            //dt.Path = Convert.IsDBNull(dr["Path"]) ? String.Empty : Convert.ToString(dr["Path"]);
            dt.Style = Convert.IsDBNull(dr["Style"]) ? Artifact.Type.Directory : (Artifact.Type)(Convert.ToInt32(dr["Style"]));
            dt.Version = Convert.IsDBNull(dr["Version"]) ? 0 : Convert.ToInt32(dr["Version"]);
            dt.CreatedBy = new GaurdianAcc.Data
            {
                Id = Convert.IsDBNull(dr["CreatedByUserId"]) ? 0 : Convert.ToInt64(dr["CreatedByUserId"])
            };
            if (!Convert.IsDBNull(dr["ModifiedByUserId"]) && Convert.ToInt64(dr["ModifiedByUserId"]) > 0)
            {
                dt.ModifiedBy = new GaurdianAcc.Data
                {
                    Id = Convert.IsDBNull(dr["ModifiedByUserId"]) ? 0 : Convert.ToInt64(dr["ModifiedByUserId"])
                };
            }
            dt.CreatedAt = Convert.IsDBNull(dr["CreatedAt"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedAt"]);
            dt.ModifiedAt = Convert.IsDBNull(dr["ModifiedAt"]) ? DateTime.MinValue : Convert.ToDateTime(dr["ModifiedAt"]);
            dt.ParentId = Convert.IsDBNull(dr["ParentId"]) ? 0 : Convert.ToInt64(dr["ParentId"]);

            return dt;
        }
       
    }

}
