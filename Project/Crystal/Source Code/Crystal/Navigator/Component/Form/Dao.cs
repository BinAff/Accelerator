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

        //protected abstract BinAff.Core.Data InstantiateModuleDataObject();

    }

}
