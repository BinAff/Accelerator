using System;
using System.Data;
using System.Collections.Generic;

using GuardianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public abstract class Dao : BinAff.Core.Dao
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
            if (data.Path == null)
            {
                base.AddInParameter("@Path", DbType.String, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@Path", DbType.String, data.Path);
            }
            if (data.ParentId == null)
            {
                base.AddInParameter("@ParentId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@ParentId", DbType.Int64, data.ParentId);
            }
            if (data.Id == 0) //Insert, so only created information
            {
                base.AddInParameter("@CreatedByUserId", DbType.Int64, data.CreatedBy.Id);
                base.AddInParameter("@Style", DbType.Int64, (Int32)data.Style);
            }
            else //Update, so modification information
            {
                base.AddInParameter("@ModifiedByUserId", DbType.Int64, data.ModifiedBy.Id);
            }
            
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = (Data)data;
            dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
            dt.FileName = Convert.IsDBNull(dr["FileName"]) ? String.Empty : Convert.ToString(dr["FileName"]);
            //dt.Path = Convert.IsDBNull(dr["Path"]) ? String.Empty : Convert.ToString(dr["Path"]);
            dt.Style = Convert.IsDBNull(dr["Style"]) ? Artifact.Type.Directory : (Artifact.Type)(Convert.ToInt32(dr["Style"]));
            dt.Version = Convert.IsDBNull(dr["Version"]) ? 0 : Convert.ToInt32(dr["Version"]);
            dt.CreatedBy = new GuardianAcc.Data
            {
                Id = Convert.IsDBNull(dr["CreatedByUserId"]) ? 0 : Convert.ToInt64(dr["CreatedByUserId"])
            };
            if (!Convert.IsDBNull(dr["ModifiedByUserId"]) && Convert.ToInt64(dr["ModifiedByUserId"]) > 0)
            {
                dt.ModifiedBy = new GuardianAcc.Data
                {
                    Id = Convert.IsDBNull(dr["ModifiedByUserId"]) ? 0 : Convert.ToInt64(dr["ModifiedByUserId"])
                };
            }
            dt.CreatedAt = Convert.IsDBNull(dr["CreatedAt"]) ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedAt"]);
            dt.ModifiedAt = Convert.IsDBNull(dr["ModifiedAt"]) ? DateTime.MinValue : Convert.ToDateTime(dr["ModifiedAt"]);
            dt.ParentId = Convert.IsDBNull(dr["ParentId"]) ? 0 : Convert.ToInt64(dr["ParentId"]);

            return dt;
        }

        internal List<BinAff.Core.Data> ReadArtifactListForMudule()
        {
            this.CreateCommand("Navigator.ArtifactModuleLinkReadForModule");
            this.AddInParameter("@ModuleId", DbType.Int64, (this.Data as Data).ModuleDefinition.Id);
            this.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> artifactList = new List<BinAff.Core.Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(row["ArtifactId"]))
                    {
                        artifactList.Add(this.CreateDataObject(Convert.ToInt64(row["ArtifactId"]), (this.Data as Data).Category));
                    }
                }
            }
            return artifactList;
        }

        protected abstract BinAff.Core.Data CreateDataObject(Int64 id, Category category);

        protected override bool CreateAfter()
        {
            bool status = true;
            Data artifactData = Data as Data;

            //avoiding insert during update
            if (artifactData.ModifiedBy == null)
            {
                base.CreateCommand("[Navigator].[ArtifactModuleLinkInsertForModule]");
                base.AddInParameter("@ArtifactId", DbType.Int64, Data.Id);
                base.AddInParameter("@ModuleId", DbType.String, artifactData.ModuleDefinition.Id);
                base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
                Int32 ret = base.ExecuteNonQuery();

                if (ret == -2146232060) status = false;//Foreign key violation

                if (status)
                    status = this.CreateAfterModuleArtifactLink();
            }

            return status;
        }

        protected virtual bool CreateAfterModuleArtifactLink()
        {
            return true;
        }       
    }

}
