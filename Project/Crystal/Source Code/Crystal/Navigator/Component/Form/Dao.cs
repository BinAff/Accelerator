using System.Data;
using System;

namespace Crystal.Navigator.Component.Form
{

    public abstract class Dao : Artifact.Dao
    {

        public Dao(Data data) 
            : base(data)
        {
            
        }

        protected override abstract void Compose();

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
            base.CreateDataObject(dr, data);
            Data dt = data as Data;
            Int64 moduleDataId = Convert.IsDBNull(dr["ModuleId"]) ? 0 : Convert.ToInt64(dr["ModuleId"]);
            if (moduleDataId != 0)
            {
                dt.ModuleData = this.InstantiateModuleDataObject();
                dt.ModuleData.Id = moduleDataId;
            }
            return data;
        }

        protected abstract BinAff.Core.Data InstantiateModuleDataObject();

    }

}
