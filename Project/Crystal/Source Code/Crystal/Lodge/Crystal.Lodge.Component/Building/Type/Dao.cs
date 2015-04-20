using System;
using System.Data;

namespace Crystal.Lodge.Component.Building.Type
{

    public class Dao : BinAff.Core.Dao
    {

        public Dao(Data data)
            : base(data) 
        { 

        }

        protected override void Compose()
        {
            base.CreateStoredProcedure = "Lodge.BuildingTypeInsert";
            base.NumberOfRowsAffectedInCreate = 1;
            base.ReadStoredProcedure = "Lodge.BuildingTypeRead";
            base.ReadAllStoredProcedure = "Lodge.BuildingTypeReadAll";
            base.UpdateStoredProcedure = "Lodge.BuildingTypeUpdate";
            base.NumberOfRowsAffectedInUpdate = -1;
            base.DeleteStoredProcedure = "Lodge.BuildingTypeDelete";
            base.NumberOfRowsAffectedInDelete = -1;
        }

        protected override void AssignParameter(string procedureName)
        {
            base.AddInParameter("@Name", System.Data.DbType.String, (this.Data as Data).Name);
        }

        protected override BinAff.Core.Data CreateDataObject(DataRow dr, BinAff.Core.Data data)
        {
            Data dt = data as Data;
            if (dr != null)
            {
                dt.Id = Convert.IsDBNull(dr["Id"]) ? 0 : Convert.ToInt64(dr["Id"]);
                dt.Name = Convert.IsDBNull(dr["Name"]) ? String.Empty : Convert.ToString(dr["Name"]);
            }
            return dt;
        }

    }

}