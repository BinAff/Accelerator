using System;
using System.Collections.Generic;
using System.Data;

namespace Crystal.Navigator.Component.Form
{

    public abstract class Dao : Artifact.Dao
    {

        public Dao(Data data) 
            : base(data)
        {
            
        }

        protected override sealed void AssignParameter(string procedureName)
        {
            base.AssignParameter(procedureName);
            if ((this.Data as Data).ModuleData != null)
            {
                base.AddInParameter("@ModuleId", DbType.String, (this.Data as Data).ModuleData.Id);
            }
        }

        protected override sealed BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            return base.CreateDataObject(dr, data);
        }

        protected internal override List<BinAff.Core.Data> ReadArtifactListForMudule()
        {
            this.CreateCommand("Navigator.FormModuleLinkReadForModule");
            this.AddInParameter("@ModuleId", DbType.Int64, (this.Data as Data).ModuleData.Id);

            DataSet ds = this.ExecuteDataSet();
            List<BinAff.Core.Data> artifactList = new List<BinAff.Core.Data>();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (!Convert.IsDBNull(row["ArtifactId"]))
                    {
                        artifactList.Add(this.CreateDataObject(Convert.ToInt64(row["ArtifactId"])));
                    }
                }
            }
            return artifactList;
        }

        protected abstract BinAff.Core.Data CreateDataObject(Int64 id);

    }

}
