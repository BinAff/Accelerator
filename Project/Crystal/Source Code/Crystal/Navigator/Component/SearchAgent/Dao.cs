using System;
using System.Collections.Generic;
using System.Data;

using GuardianAcc = Crystal.Guardian.Component.Account;

namespace Crystal.Navigator.Component.SearchAgent
{

    internal class Dao : Artifact.Dao
    {

        internal Dao(Artifact.Data data)
            : base(data)
        {

        }

        internal List<BinAff.Core.Data> Search()
        {
            Data data = base.Data as Data;
            base.CreateCommand("[Navigator].[ArtifactSearchByName]");
            base.AddInParameter("@FileName", DbType.Int64, (this.Data as Artifact.Data).FileName);
            DataSet ds = base.ExecuteDataSet();
            return base.CreateDataObjectList(ds);
        }

        protected override BinAff.Core.Data CreateDataObject(Int64 id, Artifact.Category category)
        {
            throw new NotImplementedException();
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Artifact.Data dt = (Artifact.Data)data;
            dt = base.CreateDataObject(dr, data) as Artifact.Data;
            dt.CreatedBy.Profile = new GuardianAcc.Profile.Data
            {
                FirstName = Convert.IsDBNull(dr["CreatedByFirstName"]) ? String.Empty : Convert.ToString(dr["CreatedByFirstName"]),
                MiddleName = Convert.IsDBNull(dr["CreatedByMiddleName"]) ? String.Empty : Convert.ToString(dr["CreatedByMiddleName"]),
                LastName = Convert.IsDBNull(dr["CreatedByLastName"]) ? String.Empty : Convert.ToString(dr["CreatedByLastName"]),
            };
            if (dt.ModifiedBy != null)
            {
                dt.ModifiedBy.Profile = new GuardianAcc.Profile.Data
                {
                    FirstName = Convert.IsDBNull(dr["ModifiedByFirstName"]) ? String.Empty : Convert.ToString(dr["ModifiedByFirstName"]),
                    MiddleName = Convert.IsDBNull(dr["ModifiedByMiddleName"]) ? String.Empty : Convert.ToString(dr["ModifiedByMiddleName"]),
                    LastName = Convert.IsDBNull(dr["ModifiedByLastName"]) ? String.Empty : Convert.ToString(dr["ModifiedByLastName"]),
                };
            }
            dt.ComponentDefinition = new License.Component.Data
            {
                Id = Convert.IsDBNull(dr["ModuleId"]) ? 0 : Convert.ToInt64(dr["ModuleId"]),
                Code = Convert.IsDBNull(dr["ModuleCode"]) ? String.Empty : Convert.ToString(dr["ModuleCode"]),
                Name = Convert.IsDBNull(dr["ModuleName"]) ? String.Empty : Convert.ToString(dr["ModuleName"]),
            };
            switch (Convert.IsDBNull(dr["Category"]) ? 0 : Convert.ToInt64(dr["Category"]))
            {
                case 0:
                case 1:
                    dt.Category = Artifact.Category.Form;
                    break;
                case 2:
                    dt.Category = Artifact.Category.Catelogue;
                    break;
                case 3:
                    dt.Category = Artifact.Category.Report;
                    break;
            }
            return dt;
        }

        protected override BinAff.Core.Data GetComponentData(long componentId)
        {
            throw new NotImplementedException();
        }

    }

}
