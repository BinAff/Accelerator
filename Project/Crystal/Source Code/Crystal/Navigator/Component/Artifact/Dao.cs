using System;
using System.Data;
using System.Collections.Generic;

using GuardianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.Artifact
{

    public abstract class Dao : BinAff.Core.Dao
    {

        protected String CreateComponentLinkSPName { get; set; }

        protected String UpdateComponentLinkSPName { get; set; }

        protected String DeleteComponentLinkSPName { get; set; }

        protected String ReadComponentLinkSPName { get; set; }

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
            if (data.ParentId == null || data.ParentId == 0)
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
                if (data.Style == Type.Directory || data.Extension == null)
                {
                    base.AddInParameter("@Extension", DbType.String, DBNull.Value);
                }
                else
                {
                    base.AddInParameter("@Extension", DbType.String, data.Extension);
                }
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
            dt.Extension = Convert.IsDBNull(dr["Extension"]) ? String.Empty : Convert.ToString(dr["Extension"]);
            dt.Path = Convert.IsDBNull(dr["Path"]) ? String.Empty : Convert.ToString(dr["Path"]);
            dt.Style = Convert.IsDBNull(dr["Style"]) ? Artifact.Type.Directory : (Artifact.Type)(Convert.ToInt32(dr["Style"]));
            dt.Version = Convert.IsDBNull(dr["Version"]) ? 0 : Convert.ToInt32(dr["Version"]);
            dt.Path = Convert.IsDBNull(dr["Path"]) ? String.Empty : Convert.ToString(dr["Path"]);
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
            if (Convert.IsDBNull(dr["ParentId"]))
            {
                dt.ParentId = null;
            }
            else
            {
                dt.ParentId = Convert.ToInt64(dr["ParentId"]);
            }
            
            return dt;
        }

        protected abstract BinAff.Core.Data CreateDataObject(Int64 id, Category category);        

        public override BinAff.Core.Data Read()
        {
            if (this.Data != null &&
                !String.IsNullOrEmpty((this.Data as Data).Path) && (this.Data as Data).CreatedBy == null)
            {
                this.CreateConnection();
                this.CreateCommand("Navigator.ArtifactReadForPath");
                this.AddInParameter("@Path", DbType.String, (this.Data as Data).Path);

                DataSet ds = this.ExecuteDataSet();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    this.Data.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
                }
                
                this.CloseConnection();
            }
            return base.Read();
        }

        protected override Boolean ReadBefore()
        {
            base.CreateConnection();
            base.CreateCommand(this.ReadComponentLinkSPName);
            base.AddInParameter("@ArtifactId", DbType.Int64, this.Data.Id);

            DataSet ds = this.ExecuteDataSet();
            this.CloseConnection();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Int64 reportId = Convert.IsDBNull(ds.Tables[0].Rows[0]["ComponentId"]) ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["ComponentId"]);
                if (reportId > 0)
                {
                    (this.Data as Data).ComponentData = this.GetComponentData(reportId);
                }
            }
            return true;
        }

        protected abstract BinAff.Core.Data GetComponentData(Int64 componentId);

        protected override Boolean CreateAfter()
        {
            Boolean status = true;
            Data artifactData = Data as Data;

            //avoiding insert during update
            if (artifactData.ModifiedBy == null)
            {
                base.CreateCommand("[Navigator].[ArtifactModuleLinkInsertForModule]");
                base.AddInParameter("@ArtifactId", DbType.Int64, Data.Id);
                base.AddInParameter("@ModuleId", DbType.String, artifactData.ComponentDefinition.Id);
                base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
                Int32 ret = base.ExecuteNonQuery();

                if (ret == -2146232060) status = false;//Foreign key violation

                if (status)
                    status = this.CreateComponentLink();
            }

            return status;
        }

        protected override Boolean DeleteBefore()
        {
            return this.DeleteComponentLink();
        }

        public Boolean DeleteComponentLink()
        {
            Boolean status = true;
            base.CreateCommand(this.DeleteComponentLinkSPName);
            base.AddInParameter("@Id", DbType.Int64, this.Data.Id);

            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            base.CloseConnection();

            return status;
        }

        internal List<BinAff.Core.Data> ReadArtifactListForMudule()
        {
            this.CreateCommand("Navigator.ArtifactModuleLinkReadForModule");
            this.AddInParameter("@ModuleId", DbType.Int64, (this.Data as Data).ComponentDefinition.Id);
            this.AddInParameter("@Category", DbType.Int64, (this.Data as Data).Category);

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> artifactList = new List<BinAff.Core.Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(row["Id"]))
                    {
                        Data artf = this.CreateDataObject(row, this.CreateDataObject(Convert.ToInt64(row["Id"]), (this.Data as Data).Category)) as Data;
                        artf.CreatedBy = new GuardianAcc.Data
                        {
                            Id = Convert.ToInt64(row["CreatedByUserId"]),
                            Profile = new GuardianAcc.Profile.Data
                            {
                                FirstName = Convert.ToString(row["CreatedByFirstName"]),
                                MiddleName = Convert.ToString(row["CreatedByMiddleName"]),
                                LastName = Convert.ToString(row["CreatedByLastName"])
                            }
                        };
                        if (!Convert.IsDBNull(row["ModifiedByUserId"]))
                        {
                            artf.ModifiedBy = new GuardianAcc.Data
                            {
                                Id = Convert.ToInt64(row["ModifiedByUserId"]),
                                Profile = new GuardianAcc.Profile.Data
                                {
                                    FirstName = Convert.ToString(row["ModifiedByFirstName"]),
                                    MiddleName = Convert.ToString(row["ModifiedByMiddleName"]),
                                    LastName = Convert.ToString(row["ModifiedByLastName"])
                                }
                            };
                        }
                        artf.ComponentDefinition = new License.Component.Data
                        {
                            Id = Convert.ToInt64(row["ComponentId"]),
                            Code = Convert.IsDBNull(row["ComponentCode"]) ? String.Empty : Convert.ToString(row["ComponentCode"]),
                            Name = Convert.IsDBNull(row["ComponentName"]) ? String.Empty : Convert.ToString(row["ComponentName"]),
                        };
                        artifactList.Add(artf);
                    }
                }
            }
            return artifactList;
        }

        protected virtual Boolean CreateComponentLink()
        {
            Boolean status = true;

            Data artifactData = base.Data as Data;
            base.CreateCommand(this.CreateComponentLinkSPName);
            if (artifactData.ComponentData.Id == 0)
            {
                base.AddInParameter("@ComponentId", DbType.Int64, DBNull.Value);
            }
            else
            {
                base.AddInParameter("@ComponentId", DbType.Int64, artifactData.ComponentData.Id);
            }
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            base.AddInParameter("@Category", DbType.Int64, artifactData.Category);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation
            return status;
        }

        protected internal virtual Boolean UpdateComponentLink()
        {
            Boolean status = true;
            Data artifactData = base.Data as Data;

            base.CreateCommand(this.UpdateComponentLinkSPName);
            base.AddInParameter("@ComponentId", DbType.Int64, artifactData.ComponentData.Id);
            base.AddInParameter("@ArtifactId", DbType.String, artifactData.Id);
            Int32 ret = base.ExecuteNonQuery();
            if (ret == -2146232060) status = false;//Foreign key violation

            return status;
        }

    }

}
